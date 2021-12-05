using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.IO;
using System.Threading;



namespace db_info
{
    public partial class Gakuseki_import : Form
    {
        MySqlConnection conn;
        public String Set_Hostname, Set_Password, Set_User, Set_Database;

        string filePath;

        string cols0, cols1, cols2, cols3, cols4;

        MySqlCommand cmd;

        int all_count;
        int insert_count;

        public Gakuseki_import(String Set_Hostname, String Set_Password, String Set_User, String Set_Database)
        {

            InitializeComponent();

            this.Set_Hostname = Set_Hostname;
            this.Set_Password = Set_Password;
            this.Set_User = Set_User;
            this.Set_Database = Set_Database;
        }

        private void DBSetting_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;//全画面の設定
            this.WindowState = FormWindowState.Maximized;//全画面の設定２
            this.TopMost = true;//最前面

            DB_import.Enabled = false;
            Open_file.Enabled = false;

            Set_DB_textBox.Text = Set_Database;
            Set_Host_textBox.Text = Set_Hostname;
            Set_Pass_textBox.Text = Set_Password;
            Set_User_textBox.Text = Set_User;

            // カラム数を指定
            dataGridView_show.ColumnCount = 5;

            // カラム名を指定
            dataGridView_show.Columns[0].HeaderText = "学籍番号";
            dataGridView_show.Columns[1].HeaderText = "氏名";
            dataGridView_show.Columns[2].HeaderText = "科コード";
            dataGridView_show.Columns[3].HeaderText = "クラス";
            dataGridView_show.Columns[4].HeaderText = "学年";


            // カラム数を指定
            dataGridView_ng.ColumnCount = 6;

            // カラム名を指定
            dataGridView_ng.Columns[0].HeaderText = "学籍番号";
            dataGridView_ng.Columns[1].HeaderText = "氏名";
            dataGridView_ng.Columns[2].HeaderText = "科コード";
            dataGridView_ng.Columns[3].HeaderText = "クラス";
            dataGridView_ng.Columns[4].HeaderText = "学年";
            dataGridView_ng.Columns[5].HeaderText = "状況";

            // カラム数を指定
            dataGridView_ok.ColumnCount = 6;

            // カラム名を指定
            dataGridView_ok.Columns[0].HeaderText = "学籍番号";
            dataGridView_ok.Columns[1].HeaderText = "氏名";
            dataGridView_ok.Columns[2].HeaderText = "科コード";
            dataGridView_ok.Columns[3].HeaderText = "クラス";
            dataGridView_ok.Columns[4].HeaderText = "学年";
            dataGridView_ok.Columns[5].HeaderText = "状況";

            info.Text = "DB設定を入力後　テストを行って下さい";
        }

        private void Open_file_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = "gakuseki.csv";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            //ofd.InitialDirectory = @"C:\";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "csvファイル(*.csv)|*.csv";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 1;
            //タイトルを設定する
            ofd.Title = "ファイルを選択";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                file_show.Text = ofd.FileName;
                Console.WriteLine(ofd.FileName);



                string cols0, cols2;

                String fpass = ofd.FileName;

                filePath = @fpass;
                StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("shift_jis"));
                try
                {
                    all_count = 0;

                    dataGridView_show.Rows.Clear();
                    dataGridView_ok.Rows.Clear();
                    dataGridView_ng.Rows.Clear();


                    while (reader.Peek() >= 0)
                    {
                        string[] cols = reader.ReadLine().Split(',');
                        cols0 = cols[0].ToUpper();
                        cols2 = cols[2].ToUpper();
                        dataGridView_show.Rows.Add(cols0, cols[1], cols2, cols[3] ,cols[4]);

                        all_count++;
                    }


                    all_count_show.Text = all_count.ToString() + "人";

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = all_count;

                    DB_import.Enabled = true;

                    info.Text = "書き込みを開始してください";
                }
                catch (Exception)
                {
                    info.Text = "CSVファイルを確認してください";


                    all_count_show.Text = "---------";

                    DB_import.Enabled = false;
                }

                reader.Close();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void DB_import_Click(object sender, EventArgs e)
        {
            info.Text = "書き込み中";
            DB_import.Text = "書き込み中";
            Sleep_Millisecond(1000);
            Insert_DB();

            DB_import.Text = "DB書込";

        }

        private void Set_Pass_textBox_TextChanged(object sender, EventArgs e)
        {
            Set_Pass_textBox.PasswordChar = '*';
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Insert_DB()
        {
            try
            {
                insert_count = 0;

                DB_import.Enabled = false;
                String connStr = "server=" + Set_Host_textBox.Text + "; user id=" + Set_User_textBox.Text + "; password=" + Set_Pass_textBox.Text + "; database=" + Set_DB_textBox.Text + "; pooling=false";
                conn = new MySqlConnection(connStr);
                conn.Open();


                StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("shift_jis"));

                while (reader.Peek() >= 0)
                {
                    info.Text = "実行中";
                    try
                    {
                        string[] cols = reader.ReadLine().Split(',');
                        for (int n = 0; n < cols.Length; n++) Console.Write(cols[n] + "\t");

                        cols0 = cols[0];
                        cols1 = cols[1].ToUpper();
                        cols3 = cols[3];
                        cols2 = cols[2].ToUpper();
                        cols4 = cols[4];
                        Console.Write("を追加");
                        Console.WriteLine("");
                        string Insert_SQL = "INSERT INTO `" + Set_DB_textBox.Text + "`.`gakuseki` ( `gakuseki_no`,`name`,`department`,`class`,`grade` ) value ('" + cols0 + "','" + cols[1] + "','" + cols2 + "','" + cols[3] + "','" + cols4 + "')";

                        Console.Write(Insert_SQL + "を実行");
                        Console.WriteLine("");

                        cmd = new MySqlCommand(Insert_SQL, conn);
                        cmd.ExecuteNonQuery();

                        dataGridView_ok.Rows.Add(cols0, cols1, cols2, cols3, cols4,"新規登録");
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("Error : " + e.Message);
                        try
                        {
                            string Insert_SQL = "UPDATE `" + Set_DB_textBox.Text + "`.`gakuseki` SET `name` = '" + cols1 + "', `department` = '" + cols2 + "', `class` = " + cols3 + " ,`grade` = " + cols4 + " WHERE `gakuseki`.`gakuseki_no` = '" + cols0 + "';";

                            Console.Write(Insert_SQL + "を実行");
                            Console.WriteLine("");

                            cmd = new MySqlCommand(Insert_SQL, conn);
                            cmd.ExecuteNonQuery();

                            dataGridView_ok.Rows.Add(cols0, cols1, cols2, cols3, cols4, "上書き登録");
                        }
                        catch (Exception ee)
                        {
                            dataGridView_ng.Rows.Add(cols0, cols1, cols2, cols3, cols4, "登録失敗");

                            Console.WriteLine("Error : " + ee.Message);
                        }

                    }
                    insert_count++;
                    progressBar1.Value = insert_count;
                }
                reader.Close();

                info.Text = "書き込みを終了しました";

            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.Message);
                Console.WriteLine("エラーが発生しました、処理を中止します。");

                info.Text = "エラーが発生しました";
            }
        }

        private void updata()
        {

        }



        private void DB_Test_Button_Click(object sender, EventArgs e)
        {
            DB_connect_Button.Enabled = false;
            Open_file.Enabled = false;
            DB_Info_Show.Text = "接続試行中";


            String connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3};", Set_Host_textBox.Text, Set_DB_textBox.Text, Set_User_textBox.Text, Set_Pass_textBox.Text);

            try
            {
                Close_Button.Enabled = false;

                conn = new MySqlConnection(connectionString);
                conn.Open();

                string connect_send = "SELECT 'ホスト名:" + Environment.MachineName + "が接続テスト'";
                MySqlCommand cmd = new MySqlCommand(connect_send, conn);
                cmd.ExecuteNonQuery();


                DB_Info_Show.Text = "OK";


                info.Text = "CSVファイルを選択してください";

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["host"].Value = Set_Host_textBox.Text;
                config.AppSettings.Settings["pass"].Value = Set_Pass_textBox.Text;
                config.AppSettings.Settings["user"].Value = Set_User_textBox.Text;
                config.AppSettings.Settings["db"].Value = Set_DB_textBox.Text;
                config.Save();

                Close_Button.Enabled = true;

                Set_Host_textBox.Enabled = false;
                Set_DB_textBox.Enabled = false;
                Set_Pass_textBox.Enabled = false;
                Set_User_textBox.Enabled = false;


                Open_file.Enabled = true;
            }
            catch (MySqlException me)
            {

                DB_Info_Show.Text = "NG";


                info.Text = "DB設定を確認後　テストを行ってください";

                String err = me.Message;
                MessageBox.Show(err,
                    "DB接続エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);


                Close_Button.Enabled = true;



                conn.Close();
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        static void Sleep_Millisecond(int ms)
        {
            for (int i = 0; i < ms * 8; i = i + 1000)
            {
                Console.Write(".");
                Thread.Sleep(125);
            }
            Console.WriteLine("");
        }
    }
}
