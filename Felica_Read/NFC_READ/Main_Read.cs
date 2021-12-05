using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FelicaLib;

using System.Configuration;
using MySql.Data.MySqlClient;
using System.IO;

namespace NFC_READ
{
    public partial class Main_Read : Form
    {

        string Gakuseki_String = "";
        string Search_Gakuseki_String = "";
        string Time_String = "";


        string log_file,cash_file;

        StreamWriter writer;
        Encoding enc = Encoding.GetEncoding("Shift_JIS");

        int Interval = 100;//250


        int Auto = 0; //0無効　1有効

        int Debug_Count = 0;

        int Same_Card_SW1 = 0;//重複カード判定用
        int Same_Card_SW2 = 0;

        int Error_control = 0;//読み取りエラー制御用

        string connectionString;

        string Last_Student_Number;
        string HEX_String;

        FelicaLib.Felica f;

        System.Media.SoundPlayer Ok_Sound = new System.Media.SoundPlayer("./Resources/Ok_Sound.wav");
        System.Media.SoundPlayer Ng_Sound = new System.Media.SoundPlayer("./Resources/Ng_Sound.wav");

        MySqlConnection conn;
        MySqlDataReader reader;

        MySqlCommand cmd;

        String Set_Hostname, Set_Password,Set_User,Set_Database, Set_ClientName;
        

        DateTime stime, ltime,itime;

        DB_Look DB_look;
        int one_new_dblook = 0;
        int off_line_mode = 0;


        //ここからテーブル名の設定
        String datatable_name = "data";//仕様書


        public Main_Read()
        {

            InitializeComponent();

            ExecutionState.DisableSuspend();

            Info_Show.Text = "DBに接続してください";

            //this.FormBorderStyle = FormBorderStyle.None;//全画面の設定
            //this.WindowState = FormWindowState.Maximized;//全画面の設定２
            //this.TopMost = true;//最前面

            Auto_ON_Button.Enabled = false;
            Auto_OFF_Button.Enabled = false;
            DB_Disconnect_Button.Enabled = false;


            Set_Database = ConfigurationManager.AppSettings["db"];
            Set_Hostname = ConfigurationManager.AppSettings["host"];
            Set_Password = ConfigurationManager.AppSettings["pass"];
            Set_User = ConfigurationManager.AppSettings["user"];
            Set_ClientName = ConfigurationManager.AppSettings["ClientName"];

            connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", Set_Hostname, Set_Database, Set_User, Set_Password);


            this.ActiveControl = this.DB_Connect_Button;
            

            Data_Gakuseki_Show.ReadOnly = true;

            Ok_info.Visible = false;
            Touch_Moji.Visible = false;

            ClientName_Show.Text = Set_ClientName;
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

            DBName_Show.Text = Set_Database;
        }

        private void Main_Read_Load(object sender, EventArgs e)
        {
            Auto_OFF_Button.Visible = false;
            DB_Disconnect_Button.Visible = false;
            Auto_ON_Button.Visible = false;


            ScanTimer.Interval = Interval;

            Read_Info_Show.Text = " ";
            Data_Time_Show.Text = " ";
            Data_Name_Show.Text = " ";
            Data_Gakuseki_Show.Text = " ";
        }

        void bye()
        {
                this.Close();
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
                if (off_line_mode == 0)
                {
                    stime = DateTime.Parse(MySqlHelper.ExecuteScalar(conn, "SELECT NOW()").ToString());
                    Now_Time_Show.Text = stime.ToString("HH:mm:ss");
                }
                if (off_line_mode == 1)
                {
                    ltime = DateTime.Now;
                    Now_Time_Show.Text = ltime.ToString("HH:mm:ss");
                }
            }
            catch (Exception)
            {
                DB_Info_Show.Text = "未接続(OFFLINE登録)";
                DB_info_pictureBox.Image = NFC_READ.Properties.Resources.DB_Err;

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
                    DB_info_pictureBox.Image = NFC_READ.Properties.Resources.DB_Connect;

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


        private void Auto_ON_Button_Click(object sender, EventArgs e)
        {
            try{
                f = new FelicaLib.Felica();
                Auto = 1;
                Auto_ON_Button.Enabled = false;
                Auto_OFF_Button.Enabled = true;

                Auto_OFF_Button.Visible = true;
                Auto_ON_Button.Visible = false;

                DB_Disconnect_Button.Enabled = false;
                DB_Connect_Button.Enabled = false;
                ScanTimer.Enabled = true;

                this.ActiveControl = this.No_Enter;

                End_Button.Visible = false;
                DB_Disconnect_Button.Visible = false;

                Touch_Moji.Visible = true;
                Info_Show.Text = "";
            }
            catch (Exception e1)
            {
                Info_Show.Text = e1.Message;
            }

        }

        private void Auto_OFF_Button_Click(object sender, EventArgs e)
        {
            Auto_OFF_Button.Visible = false;
            Auto_ON_Button.Visible = true;

            Auto = 0;
            Auto_ON_Button.Enabled = true;
            Auto_OFF_Button.Enabled = false;
            DB_Disconnect_Button.Enabled = true;
            DB_Connect_Button.Enabled = false;
            ScanTimer.Enabled = false;
            Info_Show.Text = "読み取りを開始してください";
            f.Close();
            
            this.ActiveControl = this.Auto_ON_Button;


            DB_Disconnect_Button.Visible = true;

            Touch_Moji.Visible = false;
        }

        public void Gakuseki_Read()
        {

            //if (Debug_Count % 10 == 0) f = new FelicaLib.Felica(); //10回ごと生成する
            f = new FelicaLib.Felica(); //毎回生成　

            try
            {
                Gakuseki_String = "";
                Search_Gakuseki_String = "";
                Time_String = "";

                f.Polling(0xfe00);

                if (f.felicap == IntPtr.Zero)
                {
                    //Info_Show.Text = "カードがありません";
                    Same_Card_SW2 = 1;
                    Error_control = 0;
                }
                else
                {

                    byte[] data = f.ReadWithoutEncryption(0x1a8b, 0);//サービスコード

                    if (data == null)
                    {
                        //Info_Show.Text = "データがありません";
                        //Ok_show_timer.Enabled = false;
                        //Ok_info.Visible = false;
                        //↑三つを外すとスイカなどはデータがありませんと出表示する
                        // Last_Student_Number = "";
                        //↑コメントを外すと同じカードでデータを登録できるようになる
                        //Ok_show_timer.Enabled = true;

                        //↑5つ運用時コメントアウト
                    }
                    else
                    {

                        Gakuseki_String = System.Text.Encoding.ASCII.GetString(data);

                        HEX_String = BitConverter.ToString(data).Replace("-", string.Empty);
                        
                        if (HEX_String.Substring(1, 5) == "00000")
                        {
                            if(Error_control == 0)
                            {
                                Info_Show.Text = "読込失敗";
                                Ng_Sound.Play();
                            }
                        }
                        else
                        {

                            Gakuseki_String = Gakuseki_String.Remove(0, 2);
                            Gakuseki_String = Gakuseki_String.Remove(9);

                  
                            Data_Gakuseki_Show.Text = Gakuseki_String;

                            if (Gakuseki_String.Substring(0, 1) != "G" &&  Gakuseki_String.Substring(0, 1) != "K") Gakuseki_String = Gakuseki_String.Remove(5);

                            Search_Gakuseki_String = Gakuseki_String;

                            

                            Gakuseki_String = System.Text.Encoding.ASCII.GetString(data);

                            


                            if (Last_Student_Number == Gakuseki_String)
                            {
                                Read_Info_Show.Text = " ";
                                if (Same_Card_SW2 == 1) Same_Card_SW1 = 1;
                            }
                            else
                            {
                                Insert();
                            }

                            if (Same_Card_SW1 == 1)
                            {
                                //Info_Show.Text = "同じカードを連続で使用できません";
                                //Ok_info.Visible = false;
                                //Ok_show_timer.Enabled = false;
                                //Ok_show_timer.Enabled = true;

                                //↑同じカードの連続表示
                            }
                            else
                            {
                                Info_Show.Text = "読込完了";
                                Ok_info.Visible = true;
                                Ok_show_timer.Enabled = false;
                                Ok_show_timer.Enabled = true;
                            }

                            Error_control = 1;
                            
                        }

                    }

                }

            }
            catch (Exception)
            //catch (Exception ex)
            {
                Info_Show.Text = "読込失敗";
                //Error_Info_Show.Text = ex.ToString();
            }


        }

        private void Ok_show_timer_Tick(object sender, EventArgs e)
        {
            Ok_show_timer.Enabled = false;
            Ok_info.Visible = false;
            Info_Show.Text = "";
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
                ScanTimer.Enabled = false;

                OfflineData_Insert oldi = new OfflineData_Insert(Set_Hostname, Set_Password, Set_User, Set_Database,Set_ClientName);
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

                ScanTimer.Enabled = true;
            }
            else if (result == DialogResult.No)
            {

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ClientName_Show_Click(object sender, EventArgs e)
        {

        }

        private void Offline_Cash_Label_Click(object sender, EventArgs e)
        {

        }

        private void Offline_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Timer_1Sec.Enabled = true;

                Offline_Button.Visible = false;
                Offline_Button.Enabled = false;
                DB_Disconnect_Button.Enabled = true;
                DB_Connect_Button.Enabled = false;


                DB_Connect_Button.Visible = false;
                DB_Setting_Button.Visible = false;
                DB_Disconnect_Button.Visible = true;

                End_Button.Enabled = false;
                this.ActiveControl = this.No_Enter;

                conn = new MySqlConnection(connectionString);
                
                Timer_1Sec.Enabled = true;
                Info_Show.Text = "読み取りを開始してください";
                Auto_ON_Button.Enabled = true;
                Auto_OFF_Button.Enabled = false;
                DB_Disconnect_Button.Enabled = true;
                DB_Connect_Button.Enabled = false;

                this.ActiveControl = this.Auto_ON_Button;

                Auto_ON_Button.Visible = false;
                DB_Connect_Button.Visible = false;
                DB_Setting_Button.Visible = false;
                DB_Disconnect_Button.Visible = true;


                DB_look = new DB_Look(Set_Hostname, Set_Password, Set_User, Set_Database);


                End_Button.Visible = false;

                cash_file = ".\\offline_cash\\" + Set_Database + "_cash.csv";


                Offline_Cash_pictureBox.Visible = false;
                Offline_Cash_Label.Visible = false;

                if (System.IO.File.Exists(cash_file))
                {
                    Offline_Cash_pictureBox.Visible = true;
                    Offline_Cash_Label.Visible = true;
                }

                off_line_mode = 1;

                DB_Info_Show.Text = "未接続(OFFLINE登録)";

                DB_info_pictureBox.Image = NFC_READ.Properties.Resources.DB_Err;


                if (one_new_dblook == 0)
                {
                    DB_look = new DB_Look(Set_Hostname, Set_Password, Set_User, Set_Database);
                    one_new_dblook = 1;
                }

                if (DB_look.Enabled == false)
                {
                    DB_look.Start();
                }

                this.ActiveControl = this.Auto_ON_Button;

                Auto_ON_Button.Visible = true;

            }
            catch (MySqlException)
            {
            }
        }

        private void DB_Disconnect_Button_Click(object sender, EventArgs e)
        {
            if(Offline_Cash_pictureBox.Visible == true)
            {
                DialogResult result = MessageBox.Show("未送信データがあります、確認しますか？",
                "未送信データ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    OfflineData_Insert oldi = new OfflineData_Insert(Set_Hostname, Set_Password, Set_User, Set_Database,Set_ClientName);
                    oldi.ShowDialog(this);
                    oldi.Dispose();
                }
                else if (result == DialogResult.No)
                {
                }
            }

            Auto_ON_Button.Enabled = false;
            Auto_OFF_Button.Enabled = false;

            Offline_Button.Visible = true;
            Offline_Button.Enabled = true;

            conn.Close();
            
            Now_Time_Show.Text = "未取得";
            DB_Setting_Button.Enabled = true;
            DB_Disconnect_Button.Enabled = false;
            DB_Connect_Button.Enabled = true;
            Timer_1Sec.Enabled = false; 
            DB_Connect_Button.Text = "DB接続";
            DB_Info_Show.Text = "DB未接続";

            DB_info_pictureBox.Image = NFC_READ.Properties.Resources.DB_DisConnect;
            Info_Show.Text = "DBに接続してください";


            DB_Connect_Button.Visible = true;
            DB_Disconnect_Button.Visible = false;
            DB_Setting_Button.Visible = true;
            Auto_ON_Button.Visible = false;

            this.ActiveControl = this.DB_Connect_Button;

            End_Button.Visible = true;
            End_Button.Enabled = true;


            Offline_Cash_pictureBox.Visible = false;
            Offline_Cash_Label.Visible = false;
        }


        private void DB_Connect_Button_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Connect_Button.Text = "接続試行中";
                DB_Connect_Button.Enabled = false;
                DB_Setting_Button.Enabled = false;
                Offline_Button.Enabled = false;
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
                DB_info_pictureBox.Image = NFC_READ.Properties.Resources.DB_Connect;
                Info_Show.Text = "読み取りを開始してください";
                Auto_ON_Button.Enabled = true;
                Auto_OFF_Button.Enabled = false;
                DB_Disconnect_Button.Enabled = true;
                DB_Connect_Button.Enabled = false;
                
                this.ActiveControl = this.Auto_ON_Button;

                Auto_ON_Button.Visible = true;
                DB_Connect_Button.Visible = false;
                DB_Setting_Button.Visible = false;
                DB_Disconnect_Button.Visible = true;
                Offline_Button.Visible = false;


                DB_look = new DB_Look(Set_Hostname, Set_Password, Set_User, Set_Database);


                End_Button.Visible = false;

                cash_file = ".\\offline_cash\\" + Set_Database + "_cash.csv";


                Offline_Cash_pictureBox.Visible = false;
                Offline_Cash_Label.Visible = false;

                if (System.IO.File.Exists(cash_file))
                {
                    Offline_Cash_pictureBox.Visible = true;
                    Offline_Cash_Label.Visible = true;
                }

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
                DB_info_pictureBox.Image = NFC_READ.Properties.Resources.DB_DisConnect;
                Info_Show.Text = "DBに接続してください";
                DB_Connect_Button.Text = "DB接続";
                DB_Connect_Button.Enabled = true;
                DB_Setting_Button.Enabled = true;
                End_Button.Enabled = true;
                Offline_Button.Visible = true;
                Offline_Button.Enabled = true;
            }
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


            DBName_Show.Text = Set_Database;
        }

        private void ScanTimer_Tick(object sender, EventArgs e)
        {
            if (Auto == 1)
            {
                Debug_Count++;
                Debug_Count_Show.Text = Debug_Count.ToString();

                Gakuseki_Read();
            }
        }


        void Insert ()
        {
            Ok_Sound.Play();

            if (off_line_mode == 0)
            {
                itime = stime;

                Last_Student_Number = Gakuseki_String;
                Same_Card_SW2 = 0;
                Same_Card_SW1 = 0;

                Time_String = itime.ToString("HH:mm:ss");

                try
                {

                    Console.WriteLine("2");
                    string Insert_SQL = "insert into " + datatable_name + " ( gakuseki_no,time,Insertinfo ) value ('" + Search_Gakuseki_String + "','" + itime + " ','" + Set_ClientName +"')";
                    cmd = new MySqlCommand(Insert_SQL, conn);
                    cmd.ExecuteNonQuery();

                    Read_Info_Show.Text = "■";
                    Data_Time_Show.Text = Time_String;

                    try
                    {

                        log_file = ".\\log\\" + Set_Database + "_Insert.csv";

                        if (System.IO.File.Exists(@log_file))
                        {
                            writer = new StreamWriter(@log_file, true, enc);

                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String + ",通常登録");

                        }
                        else
                        {
                            writer = new StreamWriter(@log_file, false, enc);

                            writer.WriteLine("日時,学籍番号,登録方式");
                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String + ",通常登録");
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
                        Console.WriteLine("SELECT name FROM gakuseki WHERE gakuseki_no = '" + Search_Gakuseki_String + "'");
                        String sql = "SELECT name FROM gakuseki WHERE gakuseki_no = '" + Search_Gakuseki_String + "'";
                        cmd = new MySqlCommand(sql, conn);
                        reader = cmd.ExecuteReader();
                        reader.Read();

                        Name_label.Text = "氏名";
                        Data_Name_Show.Text = reader.GetString(0);
                        reader.Close();
                    }
                    catch (MySqlException)
                    {
                        

                        Name_label.Text = "氏名";
                        Data_Name_Show.Text = "未登録";

                        reader.Close();
                    }

                }
                catch (MySqlException err)
                {
                    ltime = DateTime.Now;
                    itime = ltime;
                    Time_String = itime.ToString("HH:mm:ss");
                    Name_label.Text = "";
                    Data_Name_Show.Text = "";
                    Data_Time_Show.Text = Time_String;

                    try
                    {
                        cash_file = ".\\offline_cash\\" + Set_Database + "_cash.csv";


                        Offline_Cash_pictureBox.Visible = true;
                        Offline_Cash_Label.Visible = true;

                        if (System.IO.File.Exists(@cash_file))
                        {
                            writer = new StreamWriter(@cash_file, true, enc);

                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String);

                        }
                        else
                        {
                            writer = new StreamWriter(@cash_file, false, enc);

                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String);
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

                        if (System.IO.File.Exists(@log_file))
                        {
                            writer = new StreamWriter(@log_file, true, enc);

                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String + ",登録時エラー");

                        }
                        else
                        {
                            writer = new StreamWriter(@log_file, false, enc);

                            writer.WriteLine("日時,学籍番号,登録方式");
                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String + ",登録時エラー");
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

                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String + ",登録時エラー," + err.Message);
                        }
                        else
                        {
                            writer = new StreamWriter(@log_file, false, enc);

                            writer.WriteLine("日時,学籍番号,登録方式,エラー内容");
                            writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String + ",登録時エラー,"+ err.Message);
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
            }
            else if (off_line_mode == 1)
            {
                Ok_Sound.Play();

                ltime = DateTime.Now;
                itime = ltime;

                Last_Student_Number = Gakuseki_String;
                Same_Card_SW2 = 0;
                Same_Card_SW1 = 0;

                try
                {
                    cash_file = ".\\offline_cash\\" + Set_Database + "_cash.csv";


                    Offline_Cash_pictureBox.Visible = true;
                    Offline_Cash_Label.Visible = true;

                    if (System.IO.File.Exists(@cash_file))
                    {
                        writer = new StreamWriter(@cash_file, true, enc);

                        writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String);

                    }
                    else
                    {
                        writer = new StreamWriter(@cash_file, false, enc);

                        writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String);
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

                    if (System.IO.File.Exists(@log_file))
                    {
                        writer = new StreamWriter(@log_file, true, enc);

                        writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String + ",オフライン");

                    }
                    else
                    {
                        writer = new StreamWriter(@log_file, false, enc);

                        writer.WriteLine("日時,学籍番号,登録方式");
                        writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String + ",オフライン");
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

                        writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String + ",オフライン");
                    }
                    else
                    {
                        writer = new StreamWriter(@log_file, false, enc);

                        writer.WriteLine("日時,学籍番号,登録方式,エラー内容");
                        writer.WriteLine(itime.ToString("yy/MM/dd HH:mm:ss") + "," + Search_Gakuseki_String + ",オフライン,未接続");
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    writer.Close();
                }


                Time_String = itime.ToString("HH:mm:ss");



                Read_Info_Show.Text = "■";
                Data_Time_Show.Text = Time_String;


                Name_label.Text = "";

                Data_Name_Show.Text = "";
            }                    
        }
    }
}
