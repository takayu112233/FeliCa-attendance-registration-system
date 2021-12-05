using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manual_Insert
{
    public partial class OfflineData_Insert : Form
    {
        MySqlConnection conn;
        public string Set_Hostname, Set_Password, Set_User, Set_Database, Set_ClientName;
        string cash_file,log_file;
        string connectionString;
        StreamWriter writer;
        StreamReader reader;

        Encoding enc = Encoding.GetEncoding("Shift_JIS");

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CSV_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "フォルダを指定してください。";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = @"C:\Windows";
            fbd.ShowNewFolderButton = true;


            if (fbd.ShowDialog(this) == DialogResult.OK)
            {

                DateTime dt = DateTime.Now;

                String Now_Time = dt.ToString("yyyy-MM-dd HH_mm_ss");

                string outputfolder = fbd.SelectedPath;
                string outputfile = outputfolder + "\\" + Set_Database + "_send_err_" + Now_Time + ".csv";

                try
                {
                    System.IO.File.Copy(@cash_file, @outputfile, true);

                    MessageBox.Show(@outputfile + "に書き出しました",
                    "CSV書出し成功",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.None);
                }
                catch (UnauthorizedAccessException)
                {

                    MessageBox.Show("CSV書出しに失敗しました",
                    "CSV書出し失敗",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void Send_button_Click(object sender, EventArgs e)
        {
            String cash2nd = ".\\offline_cash\\" + Set_Database + "_cash2.csv";
            File.Delete(@cash2nd);
            Log_textBox.Text = "";
            writeLog("書込み開始");
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                reader = new StreamReader(@cash_file, Encoding.GetEncoding("shift_jis"));
                try
                {
                    all_count = 1;

                    dataGridView_show.Rows.Clear();

                    while (reader.Peek() >= 0)
                    {
                        string[] cols = reader.ReadLine().Split(',');
                        try
                        {
                            writeLog("\n\n" + cols[0] + "',' " + cols[1] + "送信");
                            string Insert_SQL = "insert into data ( gakuseki_no,time,Insertinfo ) value ('" + cols[1] + "','" + cols[0] + "','" + Set_ClientName + "')";
                            MySqlCommand cmd = new MySqlCommand(Insert_SQL, conn);
                            cmd.ExecuteNonQuery();
                            writeLog("" + cols[0] + "',' " + cols[1] + "送信成功");
                        }
                        catch (Exception err1)
                        {
                            //2次cashへ
                            writeLog("" + cols[0] + "',' " + cols[1] + "送信失敗");
                            writeLog(err1.Message);

                            try
                            {
                                if (System.IO.File.Exists(@cash2nd))
                                {
                                    writer = new StreamWriter(@cash2nd, true, enc);

                                    writer.WriteLine(cols[0]+","+cols[1]);
                                }
                                else
                                {
                                    writer = new StreamWriter(@cash2nd, false, enc);

                                    writer.WriteLine(cols[0] + "," + cols[1]);
                                }
                            }
                            catch (Exception)
                            {

                            }
                            finally
                            {
                                writer.Close();
                            }
                        }

                        all_count++;
                    }

                    reader.Close();

                    if (System.IO.File.Exists(@cash2nd))
                    {
                        File.Delete(@cash_file);
                        System.IO.File.Copy(@cash2nd, @cash_file);
                        File.Delete(@cash2nd);


                        reader = new StreamReader(@cash_file, Encoding.GetEncoding("shift_jis"));
                        try
                        {
                            all_count = 1;

                            dataGridView_show.Rows.Clear();

                            while (reader.Peek() >= 0)
                            {
                                string[] cols = reader.ReadLine().Split(',');
                                dataGridView_show.Rows.Add(all_count, cols[0], cols[1]);

                                all_count++;
                            }
                        }
                        catch (Exception)
                        {
                        }
                        finally
                        {
                            all_count--;
                        }
                        count_show.Text = "のこり全" + all_count + "件";


                        reader.Close();
                    }
                    else
                    {
                        File.Delete(@cash_file);
                        count_show.Text = "未送信データはありません";
                    }

                }
                catch (Exception)
                {
                }
       

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,
                    "DB接続エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                writeLog("処理を中止します");
            }

        }

        int all_count;
        public OfflineData_Insert(String Set_Hostname, String Set_Password, String Set_User, String Set_Database ,String Set_ClientName)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;//全画面の設定
            this.WindowState = FormWindowState.Maximized;//全画面の設定２
            this.TopMost = true;//最前面


            this.Set_Hostname = Set_Hostname;
            this.Set_Password = Set_Password;
            this.Set_User = Set_User;
            this.Set_Database = Set_Database;
            this.Set_ClientName = Set_ClientName+"off";

            dataGridView_show.ColumnCount = 3;

            dataGridView_show.Columns[0].HeaderText = "No.";
            dataGridView_show.Columns[1].HeaderText = "時間";
            dataGridView_show.Columns[2].HeaderText = "学籍番号";

            cash_file = ".\\offline_cash\\" + Set_Database + "_cash.csv";


            StreamReader reader = new StreamReader(@cash_file, Encoding.GetEncoding("shift_jis"));
            try
            {
                all_count = 1;

                dataGridView_show.Rows.Clear();

                while (reader.Peek() >= 0)
                {
                    string[] cols = reader.ReadLine().Split(',');
                    dataGridView_show.Rows.Add(all_count, cols[0], cols[1]);

                    all_count++;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                all_count--;

            }
            count_show.Text = "全" + all_count + "件";

            reader.Close();

            connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", Set_Hostname, Set_Database, Set_User, Set_Password);


            
        }

        private void OfflineData_Insert_Load(object sender, EventArgs e)
        {
        }

        private void writeLog(String logText)
        {
            Log_textBox.SelectionStart = Log_textBox.Text.Length;
            Log_textBox.SelectionLength = 0;
            Log_textBox.SelectedText = logText + "\r\n";
        }

    }
}
