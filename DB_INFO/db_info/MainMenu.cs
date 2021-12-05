using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace db_info
{
    public partial class MainMenu : Form
    {
        String hostname;

        int all_count,last_all_count;

        MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand cmd;

        String area;
        
        DB_Look DB_look;

        String Set_Hostname, Set_Password, Set_User, Set_Database;//log監視用設定
        string connectionString;

        int mode = 0;
        int off_line_mode = 0;
        int one_new_dblook = 0;

        DateTime stime;

        public MainMenu()
        {
            InitializeComponent();

            ExecutionState.DisableSuspend();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;//全画面の設定
            this.WindowState = FormWindowState.Maximized;//全画面の設定２
            
            Cursor.Current = Cursors.WaitCursor;

            hostname = Dns.GetHostName();

            show_host.Text = hostname;

            IPAddress[] adrList = Dns.GetHostAddresses(hostname);
            foreach (IPAddress address in adrList)
            {
                show_ip.Text = address.ToString();
            }

            Set_Database = ConfigurationManager.AppSettings["db"];
            Set_Hostname = ConfigurationManager.AppSettings["host"];
            Set_Password = ConfigurationManager.AppSettings["pass"];
            Set_User = ConfigurationManager.AppSettings["user"];

            connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", Set_Hostname, Set_Database, Set_User, Set_Password);


            Log_on.Enabled = false;
            Log_off.Enabled = false;
            Log_setting.Enabled = false;
            Log_Read_timer.Enabled = false;

            export_Mode_Botton.Enabled = false;
            Insert_gakuseki_Botton.Enabled = false;

            DB_name.Text = "監視DB設定 : " + Set_Database;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(mode == 0 && off_line_mode == 0)
            {
                DB_info.Text = "DB起動中";
                mode = 1;
                DB_info_pictureBox.Visible = true;
            }
            else if (mode == 1 && off_line_mode == 0)
            {
                mode = 0;
                DB_info_pictureBox.Visible = false;
            }


            try
            {
                if (off_line_mode == 0)
                {
                    stime = DateTime.Parse(MySqlHelper.ExecuteScalar(conn, "SELECT NOW()").ToString());
                    Now_Time_Show.Text = stime.ToString("yyyy/MM/dd\nHH:mm:ss");

                    reroad();
                }
                if (off_line_mode == 1)
                {
                    Now_Time_Show.Text = "未取得";

                    DB_info.Text = "DB異常";

                    DB_info_pictureBox.Visible = true;

                    DB_info_pictureBox.Image = db_info.Properties.Resources.DB_Err;
                }
            }
            catch (Exception)
            {

                DB_info_pictureBox.Visible = true;
                DB_info_pictureBox.Image = db_info.Properties.Resources.DB_Err;

                conn.Close();
                off_line_mode = 1;

                if (one_new_dblook == 0)
                {
                    DB_look = new DB_Look(Set_Hostname, Set_Password, Set_User, Set_Database);
                    one_new_dblook = 1;
                }

                if (DB_look.Enabled == false)
                {
                    DB_look.Start();
                }
            }

            if (DB_look.info == 1 && off_line_mode == 1)
            {
                DB_look.Enabled = false;
                try
                {
                    conn.Open();

                    off_line_mode = 0;

                    DB_info_pictureBox.Image = db_info.Properties.Resources.DB_Connect;

                    one_new_dblook = 0;
                }
                catch (Exception)
                {
                    DB_look.Enabled = true;
                    DB_look.info = 1;
                }
            }
        }

        private void pcmode_button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("PCモードにしますか？　（MYSQLは起動したままになります）",
    "PCモード",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else if (result == DialogResult.No)
            {
            }
        }

        private void shutdown_button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("電源を切りますか？",
"シャットダウン",
MessageBoxButtons.YesNo,
MessageBoxIcon.Question,
MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.ProcessStartInfo psi
= new System.Diagnostics.ProcessStartInfo();
                psi.FileName = "shutdown.exe";

                // shutdown
                psi.Arguments = "-s -t 0";

                psi.CreateNoWindow = true;
                System.Diagnostics.Process p
                = System.Diagnostics.Process.Start(psi);
            }
            else if (result == DialogResult.No)
            {
            }
        }

        private void Insert_gakuseki_Botton_Click(object sender, EventArgs e)
        {

            Log_Read_timer.Enabled = false;

            Gakuseki_import g = new Gakuseki_import(Set_Hostname, Set_Password, Set_User, Set_Database);
            g.ShowDialog(this);
            g.Dispose();


            if (Log_off.Enabled == true) Log_Read_timer.Enabled = true;

            
        }

        private void export_Mode_Botton_Click(object sender, EventArgs e)
        {

            Log_Read_timer.Enabled = false;

            Gakuseki_export ex = new Gakuseki_export(Set_Hostname, Set_Password, Set_User, Set_Database);
            ex.ShowDialog(this);
            ex.Dispose();

            if(Log_off.Enabled == true) Log_Read_timer.Enabled = true;
            
        }

        private void Log_Start_Time_Tick(object sender, EventArgs e)
        {
            Log_Start_Time.Enabled = false;
            Log_on.Enabled = true;
            Log_on.PerformClick();
        }

        private void Log_Read_timer_Tick(object sender, EventArgs e)
        {

            Console.WriteLine("===>タイマーが呼ばれた");//debag

            
            

        }

        private void IPandHost_Tick(object sender, EventArgs e)
        {
            hostname = Dns.GetHostName();

            show_host.Text = hostname;

            IPAddress[] adrList = Dns.GetHostAddresses(hostname);

            foreach (IPAddress address in adrList)
            {

                show_ip.Text = address.ToString();
            }
        }

        private void reroad()
        {
            try
            {
                Log_Read_timer.Enabled = false;

                cmd = new MySqlCommand("SELECT no FROM data ORDER BY no DESC LIMIT 1; ", conn);
                reader = cmd.ExecuteReader();

                reader.Read();
                all_count = Convert.ToInt32(reader.GetString(0));
                reader.Close();


                if (last_all_count != all_count)
                {
                    int min = last_all_count + 1;
                    int max = all_count;

                    //if (min == 2) min = 1;

                    cmd = new MySqlCommand("SELECT data.no,data.time,data.gakuseki_no,gakuseki.name,department.department,department.department_name,gakuseki.class,data.Insertinfo,gakuseki.grade FROM data LEFT OUTER JOIN gakuseki ON(data.gakuseki_no = gakuseki.gakuseki_no) LEFT OUTER JOIN department ON(gakuseki.department = department.department) WHERE data.no BETWEEN " + min + " AND " + max + ";", conn);
                    reader = cmd.ExecuteReader();

                    Cursor.Current = Cursors.WaitCursor;

                    while (reader.Read())
                    {
                        string[] row = new string[reader.FieldCount];

                        if(last_all_count == 0) Log_GridView.Rows.Clear();

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

                        Log_GridView.Rows.Insert(0, row[0], row[1], row[2], area ,row[3], row[8], row[4], row[5], row[6], row[7]);

                        for (int count = 3; count <= 7; count++)
                        {
                            if (row[count] == "未登録")
                            {
                                Log_GridView[count+1, 0].Style.BackColor = Color.Pink;
                            }
                            else
                            {
                                Log_GridView[count+1, 0].Style.BackColor = Color.LightBlue;
                            }

                        }
                        if(row[8] == "未登録")
                        {
                            Log_GridView[8, 0].Style.BackColor = Color.Pink;
                        }
                        else
                        {
                            Log_GridView[8, 0].Style.BackColor = Color.LightBlue;
                        }


                        if (area == "蒲田")Log_GridView[3, 0].Style.BackColor = Color.LightGreen;
                        
                        if (area == "八王子") Log_GridView[3, 0].Style.BackColor = Color.LightYellow;
                        
                        if (area == "その他")Log_GridView[3, 0].Style.BackColor = Color.Pink;
                        


                        last_all_count = all_count;
                    }

                    reader.Close();

                    Cursor.Current = Cursors.Default;
                }

                Log_Read_timer.Enabled = true;
            }
            catch (Exception)
            {

            }
            finally
            {
                Log_Read_timer.Enabled = true;

                reader.Close();
            }
        }

        private void Log_on_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Log_GridView.Columns.Clear();
                Log_GridView.Rows.Clear();

                Log_on.Enabled = false;
                Log_off.Enabled = false;
                Log_setting.Enabled = false;

                conn = new MySqlConnection(connectionString);
                conn.Open();

                string connect_send = "SELECT 'ホスト名:" + Environment.MachineName + "が接続'";
                MySqlCommand cmd = new MySqlCommand(connect_send, conn);
                cmd.ExecuteNonQuery();           

                cmd = new MySqlCommand("SELECT no FROM data ORDER BY no DESC LIMIT 1; ", conn);
                reader = cmd.ExecuteReader();
                reader.Read();

                DB_info_pictureBox.Image = db_info.Properties.Resources.DB_Connect;
                DB_info.Text = "DB起動中";

                try
                {
                    all_count = Convert.ToInt32(reader.GetString(0));
                    last_all_count = Convert.ToInt32(reader.GetString(0));

                    if(last_all_count != 0)
                    {
                        last_all_count = last_all_count - 30;
                        if (last_all_count <= 0) last_all_count = 0;
                    }
                }
                catch (MySqlException)
                {
                    all_count = 0;
                    last_all_count = 0;

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
                Log_GridView.Columns[4].Width = 225;
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

                Log_off.Enabled = true;


                reroad();

                Log_Read_timer.Enabled = true;


                DB_look = new DB_Look(Set_Hostname, Set_Password, Set_User, Set_Database);
                DB_info_read.Enabled = true;


                DB_info_pictureBox.Image = db_info.Properties.Resources.DB_Connect;

                off_line_mode = 0;
            }
            catch (MySqlException me)
            {
                String err = me.Message;
                MessageBox.Show(err+"\r:リアルタイム監視を開始できませんでした\rデータベース設定をご確認ください",
                    "DB接続エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);


                Log_Read_timer.Enabled = false;
                Log_on.Enabled = true;
                Log_off.Enabled = false;
                Log_setting.Enabled = true;

                conn.Close();

                DB_info_pictureBox.Visible = true;
                DB_info_pictureBox.Image = db_info.Properties.Resources.DB_DisConnect;
            }
            finally
            {
                export_Mode_Botton.Enabled = true;
                Insert_gakuseki_Botton.Enabled = true;
                
                Cursor.Current = Cursors.Default;
            }
        }

        private void Log_off_Click(object sender, EventArgs e)
        {
            conn.Close();
            reader.Close();

            DB_info_read.Enabled = false;

            Log_on.Enabled = true;
            Log_off.Enabled = false;
            Log_setting.Enabled = true;
            Log_Read_timer.Enabled = false;


            Log_GridView.Columns.Clear();
            Log_GridView.Rows.Clear();
            

            DB_info_pictureBox.Visible = true;
            DB_info_pictureBox.Image = db_info.Properties.Resources.DB_DisConnect;
  
            DB_info.Text = "DB監視オフ";

            Now_Time_Show.Text = "";
        }

        private void Log_setting_Click(object sender, EventArgs e)
        {

            Log_DBsetting Log_DBsetting = new Log_DBsetting(Set_Hostname, Set_Password, Set_User, Set_Database);
            Log_DBsetting.StartPosition = FormStartPosition.CenterScreen;
            Log_DBsetting.ShowDialog();

            Set_Database = Log_DBsetting.Set_Database;
            Set_User = Log_DBsetting.Set_User;
            Set_Password = Log_DBsetting.Set_Password;
            Set_Hostname = Log_DBsetting.Set_Hostname;

            connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", Set_Hostname, Set_Database, Set_User, Set_Password);

            DB_name.Text = "監視DB : " + Set_Database;
        }
    }
}
