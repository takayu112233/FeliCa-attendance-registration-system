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
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace db_info
{
    public partial class Gakuseki_export : Form
    {

        MySqlConnection conn;
        String connectionString;
        MySqlCommand cmd;

        String area;

        int all_count, last_all_count;

        MySqlDataReader reader;

        String Set_Hostname, Set_Password, Set_User, Set_Database;//log監視用設定


        String folder;


        private void Close_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void all_count_show_Click(object sender, EventArgs e)
        {

        }

        private void Open_file_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "フォルダを指定してください。";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = @"C:\Windows";
            fbd.ShowNewFolderButton = true;


            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                folder = fbd.SelectedPath;

                Console.WriteLine(fbd.SelectedPath);

                Folder_Show.Text = folder;

                File_Show.Text = folder + "\\DB_output_<出力日時>.csv";

                DB_Export.Enabled = true;
            }
        }

        private void DB_Test_Button_Click_1(object sender, EventArgs e)
        {
            Set_Host_textBox.Enabled = false;
            Set_DB_textBox.Enabled = false;
            Set_Pass_textBox.Enabled = false;
            Set_User_textBox.Enabled = false;

            DB_Connect_Button.Enabled = false; 

            DB_Info_Show.Text = "接続試行中";


            all_count_show.Text = "----------";

            connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3};", Set_Host_textBox.Text, Set_DB_textBox.Text, Set_User_textBox.Text, Set_Pass_textBox.Text);

            try
            {
                Log_GridView.Columns.Clear();
                Log_GridView.Rows.Clear();


                conn = new MySqlConnection(connectionString);
                conn.Open();

                string connect_send = "SELECT 'ホスト名:" + Environment.MachineName + "が接続'";
                MySqlCommand cmd = new MySqlCommand(connect_send, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("SELECT no FROM data ORDER BY no DESC LIMIT 1; ", conn);
                reader = cmd.ExecuteReader();
                reader.Read();


                try
                {
                    all_count_show.Text = reader.GetString(0) + "件";
                    all_count = Convert.ToInt32(reader.GetString(0));
                    last_all_count = Convert.ToInt32(reader.GetString(0));

                    if (last_all_count != 0)
                    {
                        last_all_count = last_all_count - 15;
                        if (last_all_count <= 0) last_all_count = 0;
                    }

                    Open_folder.Enabled = true;
                }
                catch (MySqlException)
                {
                    all_count = 0;
                    last_all_count = 0;
                    all_count_show.Text = "データがありません";

                }
                reader.Close();


                Log_GridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;


                Log_GridView.ColumnCount = 10;
                Log_GridView.Columns[0].HeaderText = "No.";
                Log_GridView.Columns[0].Width = 60;
                Log_GridView.Columns[1].HeaderText = "時間";
                Log_GridView.Columns[1].Width = 200;
                Log_GridView.Columns[2].HeaderText = "番号";
                Log_GridView.Columns[2].Width = 115;
                Log_GridView.Columns[3].HeaderText = "エリア";
                Log_GridView.Columns[3].Width = 78;
                Log_GridView.Columns[4].HeaderText = "氏名";
                Log_GridView.Columns[4].Width = 250;
                Log_GridView.Columns[5].HeaderText = "学年";
                Log_GridView.Columns[5].Width = 78;
                Log_GridView.Columns[6].HeaderText = "学科";
                Log_GridView.Columns[6].Width = 78;
                Log_GridView.Columns[7].HeaderText = "学科名";
                Log_GridView.Columns[7].Width = 280;
                Log_GridView.Columns[8].HeaderText = "クラス";
                Log_GridView.Columns[8].Width = 78;
                Log_GridView.Columns[9].HeaderText = "登録方法";
                Log_GridView.Columns[9].Width = 120;




                Log_GridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;//折り返し
                Log_GridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;//高さ調整



                if (last_all_count == 0)
                {
                    Log_GridView.Rows.Add("-", "データ無", "-", "-", "-", "-", "-", "-", "-", "-");
                    for (int count = 0; count <= 8; count++)
                    {
                        Log_GridView[count, 0].Style.BackColor = Color.Pink;
                    }
                }
                else
                {
                }


                reroad();

                DB_Info_Show.Text = "接続中";
            }
            catch (MySqlException me)
            {

                DB_Info_Show.Text = "接続エラー";

                String err = me.Message;
                MessageBox.Show(err,
                    "DB接続エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                conn.Close();

                Set_Host_textBox.Enabled = true;
                Set_DB_textBox.Enabled = true;
                Set_Pass_textBox.Enabled = true;
                Set_User_textBox.Enabled = true;

                DB_Connect_Button.Enabled = true;

            }
        }

        private void DB_Export_Click(object sender, EventArgs e)
        {
            Close_Button.Enabled = false;
            DB_Export.Enabled = false;

            DB_Info_Show.Text = "書込み中";

            Thread.Sleep(1000);

            progressBar1.Minimum = 0;
            progressBar1.Maximum = all_count;

            try
            {
                DateTime dt = DateTime.Now;

                String Now_Time = dt.ToString("yyyyMMdd_HHmmss");

                String File_Pass = folder + "\\DB_output_" + Now_Time + ".csv";

                File_Show.Text = File_Pass;

                Encoding enc = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writer = new StreamWriter(@File_Pass, false, enc);

                Thread.Sleep(500);

                writer.WriteLine("データ番号,時間,学籍番号,エリア,氏名,学年,学科記号,学科,クラス,登録方法");

                writer.Close();

                StreamWriter writer2 = new StreamWriter(@File_Pass, true, enc);

                int Read = all_count / 100; 
                int min, max;

                for (int count = 0; count < Read; count++)
                {
                    min = count * 100 + 1;
                    max = min + 99;
                    reader.Close();
                    cmd = new MySqlCommand("SELECT data.no,data.time,data.gakuseki_no,gakuseki.name,department.department,department.department_name,gakuseki.class,data.Insertinfo,gakuseki.grade FROM data LEFT OUTER JOIN gakuseki ON(data.gakuseki_no = gakuseki.gakuseki_no) LEFT OUTER JOIN department ON(gakuseki.department = department.department) WHERE data.no BETWEEN " + min + " AND " + max + ";", conn);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string[] row = new string[reader.FieldCount];

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            try
                            {
                                row[i] = reader.GetString(i);
                            }
                            catch (Exception)
                            {
                                row[i] = " ";
                            }
                        }

                        area = "その他";
                        if (row[2].Substring(0, 1) == "G") area = "八王子";
                        if (row[2].Substring(0, 1) == "K") area = "蒲田";

                        writer2.WriteLine(row[0] + "," + row[1] + "," + row[2] + "," + area + "," + row[3] + "," + row[8] + "," + row[4] + "," + row[5] + "," + row[6] + "," + row[7]);


                        progressBar1.Value = int.Parse(row[0]);
                    }

                    reader.Close();

                }

                min = Read * 100 + 1;
                max = all_count;
                if(min <= max)
                {
                    reader.Close();
                    cmd = new MySqlCommand("SELECT data.no,data.time,data.gakuseki_no,gakuseki.name,department.department,department.department_name,gakuseki.class,data.Insertinfo,gakuseki.grade FROM data LEFT OUTER JOIN gakuseki ON(data.gakuseki_no = gakuseki.gakuseki_no) LEFT OUTER JOIN department ON(gakuseki.department = department.department) WHERE data.no BETWEEN " + min + " AND " + max + ";", conn);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string[] row = new string[reader.FieldCount];

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            try
                            {
                                row[i] = reader.GetString(i);
                            }
                            catch (Exception)
                            {
                                row[i] = " ";
                            }
                        }

                        area = "その他";
                        if (row[2].Substring(0, 1) == "G") area = "八王子";
                        if (row[2].Substring(0, 1) == "K") area = "蒲田";

                        writer2.WriteLine(row[0] + "," + row[1] + "," + row[2] + "," + area + "," + row[3] + "," + row[8] + "," + row[4] + "," + row[5] + "," + row[6] + "," + row[7]);


                        progressBar1.Value = int.Parse(row[0]);
                    }
               
                }

                writer2.Close();

                DB_Info_Show.Text = "書込み終了";

            }
            catch (Exception mee)
            {
                String err = mee.Message;
                MessageBox.Show(err,
                    "書込みエラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);


                DB_Info_Show.Text = "エラーが発生しました";
            }


            Close_Button.Enabled = true;
            DB_Export.Enabled = true;
        }

        private void Set_Pass_textBox_TextChanged(object sender, EventArgs e)
        {
            Set_Pass_textBox.PasswordChar = '*';
        }

        private void reroad()
        {
            try
            {
                cmd = new MySqlCommand("SELECT no FROM data ORDER BY no DESC LIMIT 1; ", conn);
                reader = cmd.ExecuteReader();
                reader.Read();
                all_count = Convert.ToInt32(reader.GetString(0));
                reader.Close();


                if (last_all_count != all_count)
                {
                    int min = last_all_count + 1;
                    int max = all_count;

                    if (min == 2) min = 1;

                    cmd = new MySqlCommand("SELECT data.no,data.time,data.gakuseki_no,gakuseki.name,department.department,department.department_name,gakuseki.class,data.Insertinfo,gakuseki.grade FROM data LEFT OUTER JOIN gakuseki ON(data.gakuseki_no = gakuseki.gakuseki_no) LEFT OUTER JOIN department ON(gakuseki.department = department.department) WHERE data.no BETWEEN " + min + " AND " + max + ";", conn);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        string[] row = new string[reader.FieldCount];

                        if (last_all_count == 0) Log_GridView.Rows.RemoveAt(0);

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            try
                            {
                                row[i] = reader.GetString(i);
                            }
                            catch (Exception)
                            {

                                row[i] = "未登録";

                            }
                        }

                        area = "その他";
                        if (row[2].Substring(0, 1) == "G") area = "八王子";
                        if (row[2].Substring(0, 1) == "K") area = "蒲田";

                        Log_GridView.Rows.Insert(0, row[0], row[1], row[2], area ,row[3], row[8], row[4], row[5], row[6] , row[7]);

                        /*
                        for (int count = 4; count <= ; count++)
                        {
                            if (row[count] == "未登録")
                            {
                                Log_GridView[count, 0].Style.BackColor = Color.Pink;
                            }
                            else
                            {
                                Log_GridView[count, 0].Style.BackColor = Color.LightBlue;
                            }

                        }
                        */

                        last_all_count = all_count;
                    }

                    reader.Close();
                }

            }
            catch (Exception)
            {

            }
            finally
            {

                reader.Close();
            }
        }


        private void DB_Test_Button_Click(object sender, EventArgs e)
        {

        }

        public Gakuseki_export(String Set_Hostname, String Set_Password, String Set_User, String Set_Database)
        {
            InitializeComponent();

            this.Set_Hostname = Set_Hostname;
            this.Set_Password = Set_Password;
            this.Set_User = Set_User;
            this.Set_Database = Set_Database;
        }

        private void Gakuseki_export_Load_1(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;//全画面の設定
            this.WindowState = FormWindowState.Maximized;//全画面の設定２
            this.TopMost = true;//最前面

            DB_Export.Enabled = false;
            Open_folder.Enabled = false;

            Open_folder.Enabled = false;

            Set_DB_textBox.Text = Set_Database;
            Set_Host_textBox.Text = Set_Hostname;
            Set_Pass_textBox.Text = Set_Password;
            Set_User_textBox.Text = Set_User;



        }

    }
}
