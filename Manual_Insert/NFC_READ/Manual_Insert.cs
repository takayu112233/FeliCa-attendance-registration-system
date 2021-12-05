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
using Manual_Insert;
using System.IO;

namespace NFC_READ
{
    public partial class Main_Read : Form
    {      
        string connectionString;

        string Last_gakuseki;

        string log_file,cash_file;
        StreamWriter writer;
        Encoding enc = Encoding.GetEncoding("Shift_JIS");


        System.Media.SoundPlayer Ok_Sound = new System.Media.SoundPlayer("./Resources/Ok_Sound.wav");

        MySqlConnection conn;
        MySqlDataReader reader;

        String Set_Hostname,Set_Password,Set_User,Set_Database, Set_ClientName;


        DateTime stime,ltime,itime;

        DB_Look DB_look;
        int one_new_dblook = 0;
        int off_line_mode = 0;
        


        public Main_Read()
        {
            InitializeComponent();
            
            Info_Show.Text = "DBに接続してください";


            this.FormBorderStyle = FormBorderStyle.None;//全画面の設定
            this.WindowState = FormWindowState.Maximized;//全画面の設定２
            this.TopMost = true;//最前面

            ExecutionState.DisableSuspend();

            DB_Disconnect_Button.Enabled = false;


            Set_Database = ConfigurationManager.AppSettings["db"];
            Set_Hostname = ConfigurationManager.AppSettings["host"];
            Set_Password = ConfigurationManager.AppSettings["pass"];
            Set_User = ConfigurationManager.AppSettings["user"];
            Set_ClientName = ConfigurationManager.AppSettings["ClientName"];



            connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", Set_Hostname, Set_Database, Set_User, Set_Password);


            this.ActiveControl = this.DB_Connect_Button;


            ClientName_Show.Text = Set_ClientName;


            DBName_Show.Text = Set_Database;

            
            try
            {
                ClientName_Show2.Visible = false;
                ClientName_Show2.Text = Set_ClientName.Remove(0, 4);
                ClientName_Show2.Visible = true;
            }
            catch (Exception)
            {
                ClientName_Show2.Visible = false;
            }
        }

        private void Main_Read_Load(object sender, EventArgs e)
        {

            DB_Disconnect_Button.Visible = false;


            Key_bs.Enabled = false;
            Key_clear.Enabled = false;
            Key_send.Enabled = false;


            Gakuseki_TextBox.Text = "";
            Gakuseki_TextBox.Enabled = false;
            All_key_lock();

            Data_Time_Show.Text = " ";
            Data_Name_Show.Text = " ";
            Last_Gakuseki_Show.Text = "";

        }

        void bye()
        {
                this.Close();

                ExecutionState.EnableSuspend();
        }

        private void Main_Read_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                bye();
            }
        }

        private void Timer_1Sec_Tick(object sender, EventArgs e)
        {
            try
            {
                if(off_line_mode == 0)
                {
                    stime = DateTime.Parse(MySqlHelper.ExecuteScalar(conn, "SELECT NOW()").ToString());
                    Now_Time_Show.Text = stime.ToString("HH:mm:ss");
                }
                if(off_line_mode == 1) 
                {
                    ltime = DateTime.Now;
                    Now_Time_Show.Text = ltime.ToString("HH:mm:ss");
                }
            }
            catch (Exception)
            {
                DB_Info_Show.Text = "未接続(OFFLINE登録)";

                DB_info_pictureBox.Image = Manual_Insert.Properties.Resources.DB_Err;

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
                    DB_Info_Show.Text = "接続中";

                    DB_info_pictureBox.Image = Manual_Insert.Properties.Resources.DB_Connect;

                    one_new_dblook = 0;
                }
                catch (Exception)
                {
                    DB_look.Enabled = true;
                    DB_look.info = 1;
                }
            }
        }


        private void End_Button_Click(object sender, EventArgs e)
        {
            bye();
        }






        private void DB_Connect_Button_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Connect_Button.Text = "接続試行中";
                DB_Connect_Button.Enabled = false;
                DB_Setting_Button.Enabled = false;

                End_Button.Enabled = false;
                this.ActiveControl = this.No_Enter;


                conn = new MySqlConnection(connectionString);
                conn.Open();

                string connect_send = "SELECT 'ホスト名:" + Environment.MachineName + "が接続'";
                MySqlCommand cmd = new MySqlCommand(connect_send, conn);
                cmd.ExecuteNonQuery();


                Timer_1Sec.Enabled = true;
                DB_Connect_Button.Text = "DB接続中";
                DB_Info_Show.Text = "DB接続中";

                DB_info_pictureBox.Image = Manual_Insert.Properties.Resources.DB_Connect;
                Info_Show.Text = "学籍番号を入力後、登録を押してください";
                DB_Disconnect_Button.Enabled = true;
                DB_Connect_Button.Enabled = false;
                Offline_Button.Enabled = false;


                DB_Connect_Button.Visible = false;
                DB_Setting_Button.Visible = false;
                DB_Disconnect_Button.Visible = true;
                Offline_Button.Visible = false;

                Gakuseki_TextBox.Enabled = true;
                Area_key_lock(0);
                Key_clear.Enabled = true;
                Key_clear.PerformClick();
                Key_clear.Enabled = false;


                Template_Visible(1);

                Template_Enabled(1);

                DB_look = new DB_Look(Set_Hostname, Set_Password, Set_User, Set_Database);

                End_Button.Visible = false;


                Offline_Cash_pictureBox.Visible = false;
                Offline_Cash_Label.Visible = false;

                cash_file = ".\\offline_cash\\" + Set_Database + "_cash.csv";

                if (System.IO.File.Exists(cash_file))
                {
                    Offline_Cash_pictureBox.Visible = true;
                    Offline_Cash_Label.Visible = true;
                }

                Key_clear.Enabled = true;

            }
            catch (MySqlException me)
            {
                String err = me.Message;
                MessageBox.Show(err,
                    "DB接続エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);


                Now_Time_Show.Text = "未取得";
                Timer_1Sec.Enabled = false;
                DB_Info_Show.Text = "DB未接続";

                DB_info_pictureBox.Image = Manual_Insert.Properties.Resources.DB_DisConnect;
                Info_Show.Text = "DBに接続してください";
                DB_Connect_Button.Text = "DB接続";
                DB_Connect_Button.Enabled = true;
                DB_Setting_Button.Enabled = true;
                Offline_Button.Enabled = true;
                Offline_Button.Visible = true;

                Gakuseki_TextBox.Text = "";
                Gakuseki_TextBox.Enabled = false;
                All_key_lock();


                DB_Setting_Button.Enabled = true;
                End_Button.Enabled = true;


                Template_Enabled(0);
            }
        }
        
        private void DB_Disconnect_Button_Click(object sender, EventArgs e)
        {
            if (Offline_Cash_pictureBox.Visible == true)
            {
                DialogResult result = MessageBox.Show("未送信データがあります、確認しますか？",
                "未送信データ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    OfflineData_Insert oldi = new OfflineData_Insert(Set_Hostname, Set_Password, Set_User, Set_Database ,Set_ClientName);
                    oldi.ShowDialog(this);
                    oldi.Dispose();
                }
                else if (result == DialogResult.No)
                {
                }
            }

            DB_look.Enabled = false;

            End_Button.Visible = true;

            conn.Close();

            Now_Time_Show.Text = "未取得";
            DB_Setting_Button.Enabled = true;
            DB_Disconnect_Button.Enabled = false;
            DB_Connect_Button.Enabled = true;
            Timer_1Sec.Enabled = false;

            Offline_Button.Visible = true;
            Offline_Button.Enabled = true;

            DB_Connect_Button.Text = "DB接続";
            DB_Info_Show.Text = "DB未接続";

            DB_info_pictureBox.Image = Manual_Insert.Properties.Resources.DB_DisConnect;
            Info_Show.Text = "DBに接続してください";


            DB_Connect_Button.Visible = true;
            DB_Disconnect_Button.Visible = false;
            DB_Setting_Button.Visible = true;

            this.ActiveControl = this.DB_Connect_Button;


            Gakuseki_TextBox.Text = "";
            Gakuseki_TextBox.Enabled = false;
            All_key_lock();


            Template_Visible(1);

            Template_Enabled(0);

            End_Button.Visible = true;
            End_Button.Enabled = true;


            Offline_Cash_pictureBox.Visible = false;
            Offline_Cash_Label.Visible = false;
        }

        private void Main_Read_FormClosing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("プログラムを終了しますか？",
            "終了の確認",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
            }else if (result == DialogResult.No){
                e.Cancel = true;
            }

        }

        private void DB_Setting_Button_Click(object sender, EventArgs e)
        {
            DBSetting DBSetting = new DBSetting(Set_Hostname,Set_Password,Set_User,Set_Database,Set_ClientName);
            DBSetting.StartPosition = FormStartPosition.CenterScreen;
            DBSetting.ShowDialog();

            Set_Database = DBSetting.Set_Database;
            Set_User = DBSetting.Set_User;
            Set_Password = DBSetting.Set_Password;
            Set_Hostname = DBSetting.Set_Hostname;
            Set_ClientName = DBSetting.Set_ClientName;

            connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", Set_Hostname, Set_Database, Set_User, Set_Password);

            ClientName_Show.Text = Set_ClientName;


            DBName_Show.Text = Set_Database;

            try
            {
                ClientName_Show2.Visible = false;
                ClientName_Show2.Text = Set_ClientName.Remove(0, 4);
                ClientName_Show2.Visible = true;
            }
            catch (Exception)
            {
                ClientName_Show2.Visible = false;
            }
        }


        void Insert (String Gakuseki)
        {
            if(off_line_mode == 0)
            {
                itime = stime;
                try
                {
                    Ok_Sound.Play();

                    Last_gakuseki = Gakuseki;

                    string Insert_SQL = "insert into data ( gakuseki_no,time,Insertinfo ) value ('" + Gakuseki + "',' " + itime + " ','" + Set_ClientName + "')";
                    MySqlCommand cmd = new MySqlCommand(Insert_SQL, conn);
                    cmd.ExecuteNonQuery();

                    Data_Time_Show.Text = itime.ToString("HH:mm:ss");
                    Last_gakuseki = Gakuseki;

                    try
                    {
                        log_file = ".\\log\\" + Set_Database + "_Insert.csv";

                        if (System.IO.File.Exists(@log_file))
                        {
                            writer = new StreamWriter(@log_file, true, enc);

                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki + ",通常登録");
                        }
                        else
                        {
                            writer = new StreamWriter(@log_file, false, enc);

                            writer.WriteLine("日時,学籍番号,登録方式");
                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki + ",通常登録");
                        }
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        writer.Close();
                    }


                    Last_Gakuseki_Show.Text = Last_gakuseki;


                    try
                    {
                        String sql = "SELECT name FROM gakuseki WHERE gakuseki_no = '" + Gakuseki + "'";
                        cmd = new MySqlCommand(sql, conn);
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        Data_Name_Show.Text = reader.GetString(0);
                        reader.Close();

                    }
                    catch (MySqlException)
                    {
                        Data_Name_Show.Text = "未登録";
                        reader.Close();
                    }

                    Gakuseki_TextBox.Text = "";

                    Name_label.Text = "氏名";



                    Template_Visible(1);

                }
                catch (MySqlException err)
                {
                    ltime = DateTime.Now;
                    itime = ltime;
                    Name_label.Text = "";
                    Data_Name_Show.Text = "";
                    Data_Time_Show.Text = itime.ToString("HH:mm:ss");

                    Last_Gakuseki_Show.Text = Last_gakuseki;

                    try
                    {
                        cash_file = ".\\offline_cash\\" + Set_Database + "_cash.csv";


                        Offline_Cash_pictureBox.Visible = true;
                        Offline_Cash_Label.Visible = true;

                        if (System.IO.File.Exists(@cash_file))
                        {
                            writer = new StreamWriter(@cash_file, true, enc);

                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki);

                        }
                        else
                        {
                            writer = new StreamWriter(@cash_file, false, enc);

                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki);
                        }

                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        writer.Close();
                    }


                    try
                    {
                        log_file = ".\\log\\" + Set_Database + "_Insert.csv";

                        if (System.IO.File.Exists(log_file))
                        {
                            writer = new StreamWriter(@log_file, true, enc);

                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki + ",登録時エラー");

                        }
                        else
                        {
                            writer = new StreamWriter(@log_file, false, enc);

                            writer.WriteLine("日時,学籍番号,登録方式");
                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki + ",登録時エラー");
                        }
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        writer.Close();
                    }

                    try
                    {
                        log_file = ".\\offline\\" + Set_Database + "_OfflineInsert.csv";

                        if (System.IO.File.Exists(log_file))
                        {
                            writer = new StreamWriter(@log_file, true, enc);

                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki + ",登録時エラー," + err.Message);
                        }
                        else
                        {
                            writer = new StreamWriter(@log_file, false, enc);

                            writer.WriteLine("日時,学籍番号,登録方式,エラー内容");
                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki + ",登録時エラー," + err.Message);
                        }
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        writer.Close();
                    }

                    Gakuseki_TextBox.Text = "";


                    Template_Visible(1);
                }

            }
            else if(off_line_mode == 1)
            {
                Ok_Sound.Play();

                ltime = DateTime.Now;
                itime = ltime;

                try
                {
                    cash_file = ".\\offline_cash\\" + Set_Database + "_cash.csv";


                    Offline_Cash_pictureBox.Visible = true;
                    Offline_Cash_Label.Visible = true;

                    if (System.IO.File.Exists(@cash_file))
                    {
                        writer = new StreamWriter(@cash_file, true, enc);

                        writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki);

                    }
                    else
                    {
                        writer = new StreamWriter(@cash_file, false, enc);

                        writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki);
                    }

                }
                catch (Exception)
                {

                }
                finally
                {
                    writer.Close();
                }

                try
                {
                    Data_Time_Show.Text = itime.ToString("HH:mm:ss");
                    Last_gakuseki = Gakuseki;

                    try
                    {
                        log_file = ".\\log\\" + Set_Database + "_Insert.csv";

                        if (System.IO.File.Exists(@log_file))
                        {
                            writer = new StreamWriter(@log_file, true, enc);

                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki + ",オフライン");
                        }
                        else
                        {
                            writer = new StreamWriter(@log_file, false, enc);

                            writer.WriteLine("日時,学籍番号,登録方式");
                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki + ",オフライン");
                        }
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        writer.Close();
                    }

                    try
                    {
                        log_file = ".\\offline\\" + Set_Database + "_OfflineInsert.csv";

                        if (System.IO.File.Exists(@log_file))
                        {
                            writer = new StreamWriter(@log_file, true, enc);

                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki + ",オフライン");
                        }
                        else
                        {
                            writer = new StreamWriter(@log_file, false, enc);

                            writer.WriteLine("日時,学籍番号,登録方式");
                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Gakuseki + ",オフライン");
                        }
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        writer.Close();
                    }

                    Last_gakuseki = Gakuseki;
                    Last_Gakuseki_Show.Text = Last_gakuseki;

                    Gakuseki_TextBox.Text = "";


                    Template_Visible(0);


                    Key_clear.Enabled = true;

                    Name_label.Text = "";
                    Data_Name_Show.Text = "";
                }
                catch (MySqlException me)
                {
                    String err = me.Message;
                    Console.WriteLine(err);
                    MessageBox.Show(err,
                        "ERROR発生",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }


        }


        private void Ten_key_lock(int on)
        {
            if (on == 1)
            {
                Key_0.Enabled = false;
                Key_1.Enabled = false;
                Key_2.Enabled = false;
                Key_3.Enabled = false;
                Key_4.Enabled = false;
                Key_5.Enabled = false;
                Key_6.Enabled = false;
                Key_7.Enabled = false;
                Key_8.Enabled = false;
                Key_9.Enabled = false;
            }
            else
            {
                Key_0.Enabled = true;
                Key_1.Enabled = true;
                Key_2.Enabled = true;
                Key_3.Enabled = true;
                Key_4.Enabled = true;
                Key_5.Enabled = true;
                Key_6.Enabled = true;
                Key_7.Enabled = true;
                Key_8.Enabled = true;
                Key_9.Enabled = true;
            }
        }

        private void Area_key_lock(int on)
        {
            if (on == 1)
            {
                Key_hachioji.Enabled = false;
                Key_kamata.Enabled = false;

            }
            else
            {
                Key_hachioji.Enabled = true;
                Key_kamata.Enabled = true;
            }
        }
        private void College_lock(int on)
        {
            if (on == 1)
            {
                Key_a.Enabled = false;
                Key_b.Enabled = false;
                Key_c.Enabled = false;
                Key_d.Enabled = false;
                Key_e.Enabled = false;
                Key_g.Enabled = false;
            }
            else
            {
                Key_a.Enabled = true;
                Key_b.Enabled = true;
                Key_c.Enabled = true;
                Key_d.Enabled = true;
                Key_e.Enabled = true;
                Key_g.Enabled = true;
            }
        }

        private void All_key_lock()
        {
            Ten_key_lock(1);
            College_lock(1);
            Area_key_lock(1);
            Key_clear.Enabled = false;
            Key_bs.Enabled = false;
            Key_send.Enabled = false;
        }


        private void Gakuseki_TextBox_TextChanged(object sender, EventArgs e)
        {
            int Moji_count = Gakuseki_TextBox.TextLength;

            if (Moji_count == 0)
            {
                Ten_key_lock(1);
                College_lock(1);
                Area_key_lock(0);

                Key_send.Enabled = false;
                Key_bs.Enabled = false;
                Key_clear.Enabled = true;
            }
            if (Moji_count == 1)
            {
                Ten_key_lock(0);
                College_lock(1);
                Area_key_lock(1);

                Key_send.Enabled = false;
                Key_bs.Enabled = true;
                Key_clear.Enabled = true;
            }
            if (Moji_count == 2)
            {
                Ten_key_lock(0);
                College_lock(1);
                Area_key_lock(1);

                Key_send.Enabled = false;
                Key_bs.Enabled = true;
                Key_clear.Enabled = true;
            }
            if (Moji_count == 3)
            {
                Ten_key_lock(0);
                College_lock(1);
                Area_key_lock(1);

                Key_send.Enabled = false;
                Key_bs.Enabled = true;
                Key_clear.Enabled = true;
            }
            if (Moji_count == 4)
            {
                Ten_key_lock(1);
                College_lock(0);
                Area_key_lock(1);

                Key_send.Enabled = false;
                Key_bs.Enabled = true;
                Key_clear.Enabled = true;
            }
            if (Moji_count == 5)
            {
                Ten_key_lock(0);
                College_lock(1);
                Area_key_lock(1);

                Key_send.Enabled = false;
                Key_bs.Enabled = true;
                Key_clear.Enabled = true;
            }
            if (Moji_count == 6)
            {
                Ten_key_lock(0);
                College_lock(1);
                Area_key_lock(1);

                Key_send.Enabled = false;
                Key_bs.Enabled = true;
                Key_clear.Enabled = true;
            }
            if (Moji_count == 7)
            {
                Ten_key_lock(0);
                College_lock(1);
                Area_key_lock(1);

                Key_send.Enabled = false;
                Key_bs.Enabled = true;
                Key_clear.Enabled = true;
            }
            if (Moji_count == 8)
            {
                Ten_key_lock(0);
                College_lock(1);
                Area_key_lock(1);

                Key_send.Enabled = false;
                Key_bs.Enabled = true;
                Key_clear.Enabled = true;
            }
            if (Moji_count == 9)
            {
                Ten_key_lock(1);
                College_lock(1);
                Area_key_lock(1);

                Key_send.Enabled = true;
                Key_bs.Enabled = true;
                Key_clear.Enabled = true;
            }



        }

        private void Key_1_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "1";
        }

        private void Key_2_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "2";
        }

        private void Key_3_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "3";
        }

        private void Key_4_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "4";
        }

        private void Key_5_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "5";
        }

        private void Key_6_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "6";
        }

        private void Key_7_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "7";
        }

        private void Key_8_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "8";
        }

        private void Key_9_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "9";
        }

        private void Key_0_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "0";
        }

        private void Key_b_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "B";
        }

        private void Key_c_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "C";
        }

        private void Key_d_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "D";
        }

        private void Key_e_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "E";
        }

        private void Key_g_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "G";
        }

        private void Offline_Cash_pictureBox_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("未送信データがあります、確認しますか？",
            "未送信データ",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                OfflineData_Insert oldi = new OfflineData_Insert(Set_Hostname,Set_Password,Set_User,Set_Database,Set_ClientName);
                oldi.ShowDialog(this);
                oldi.Dispose();

                if (System.IO.File.Exists(cash_file))
                {
                    Offline_Cash_pictureBox.Visible = true;
                    Offline_Cash_Label.Visible = true;
                }
                else
                {
                    Offline_Cash_pictureBox.Visible = false;
                    Offline_Cash_Label.Visible = false;
                }
            }
            else if (result == DialogResult.No)
            {
            }
        }

        private void Info_Show_Click(object sender, EventArgs e)
        {

        }

        private void Offline_Cash_Label_Click(object sender, EventArgs e)
        {

        }

        private void DB_Info_Show_Click(object sender, EventArgs e)
        {

        }

        private void DB_info_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void Data_Name_Show_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Key_k018c_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "K018C";
            Template_Visible(0);
        }

        private void Key_k019c_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "K019C";
            Template_Visible(0);
        }

        private void Key_etc_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = "";
            Template_Visible(0);
        }

        private void Key_k016c_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "K016C";
            Template_Visible(0);
        }

        private void Key_k017c_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "K017C";
            Template_Visible(0);
        }

 
        void Template_Visible(int sw)
        {
            if (sw == 0)
            {
                Key_k016c.Visible = false;
                Key_k017c.Visible = false;
                Key_k018c.Visible = false;
                Key_k019c.Visible = false;
                Key_etc.Visible = false;
            }
            else if (sw == 1)
            {
                Key_k016c.Visible = true;
                Key_k017c.Visible = true;
                Key_k018c.Visible = true;
                Key_k019c.Visible = true;
                Key_etc.Visible = true;
            }
        }

        void Template_Enabled(int sw)
        {
            if (sw == 0)
            {
                Key_k016c.Enabled = false;
                Key_k017c.Enabled = false;
                Key_k018c.Enabled = false;
                Key_k019c.Enabled = false;
                Key_etc.Enabled = false;
            }
            else if (sw == 1)
            {
                Key_k016c.Enabled = true;
                Key_k017c.Enabled = true;
                Key_k018c.Enabled = true;
                Key_k019c.Enabled = true;
                Key_etc.Enabled = true;
            }
        }

        private void Offline_Button_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connectionString);
            Offline_Button.Visible = false;
            try
            {
                Timer_1Sec.Enabled = true;
                
                DB_Disconnect_Button.Enabled = true;
                DB_Connect_Button.Enabled = false;


                DB_Connect_Button.Visible = false;
                DB_Setting_Button.Visible = false;
                DB_Disconnect_Button.Visible = true;


                Gakuseki_TextBox.Enabled = true;
                Area_key_lock(0);
                Key_clear.Enabled = true;
                Key_clear.PerformClick();
                Key_clear.Enabled = false;


                Template_Enabled(1);


                DB_look = new DB_Look(Set_Hostname, Set_Password, Set_User, Set_Database);

                End_Button.Visible = false;


                Offline_Cash_pictureBox.Visible = false;
                Offline_Cash_Label.Visible = false;

                cash_file = ".\\offline_cash\\" + Set_Database + "_cash.csv";

                if (System.IO.File.Exists(cash_file))
                {
                    Offline_Cash_pictureBox.Visible = true;
                    Offline_Cash_Label.Visible = true;
                }

                off_line_mode = 1;

                DB_Info_Show.Text = "未接続(OFFLINE登録)";

                DB_info_pictureBox.Image = Manual_Insert.Properties.Resources.DB_Err;
                

                if (one_new_dblook == 0)
                {
                    DB_look = new DB_Look(Set_Hostname, Set_Password, Set_User, Set_Database);
                    one_new_dblook = 1;
                }

                if (DB_look.Enabled == false)
                {
                    DB_look.Start();
                }

                Key_clear.Enabled = true;

            }
            catch (MySqlException)
            {
                
            }
        }

        private void Key_clear_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = "";
                       
            Template_Visible(1);

            Template_Enabled(1);
        }

        private void Key_kamata_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = "K";
        }

        private void Key_hachioji_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = "G";
        }

        private void Key_bs_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text.Substring(0, Gakuseki_TextBox.Text.Length - 1);
        }

        private void Key_a_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text + "A";
        }

        private void Key_send_Click(object sender, EventArgs e)
        {
            Gakuseki_TextBox.Text = Gakuseki_TextBox.Text.ToUpper();

            Insert(Gakuseki_TextBox.Text);
        }

    }
}
