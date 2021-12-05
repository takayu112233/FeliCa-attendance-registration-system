using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_CREATE
{
    public partial class DB_CREATE : Form
    {

        MySqlCommand cmd;
        string connStr;

        public DB_CREATE()
        {
            InitializeComponent();

            //this.TopMost = true;//最前面
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Set_Host_textBox.Text = "localhost";
            Set_Pass_textBox.Text = "";
            Set_DB_textBox.Text = "";
            Set_User_textBox.Text = "root";
        }

        private void Set_Pass_textBox_TextChanged(object sender, EventArgs e)
        {
            Set_Pass_textBox.PasswordChar = '*';
        }

        private void writeLog(String logText)
        {
            Log_textBox.SelectionStart = Log_textBox.Text.Length;
            Log_textBox.SelectionLength = 0;
            Log_textBox.SelectedText = "[" + System.DateTime.Now.ToString() + "]" + logText + "\r\n";
        }


        private void Start_Button_Click(object sender, EventArgs e)
        {
            Log_textBox.Text = "";

            Start_Button.Enabled = false;
            Set_Host_textBox.Enabled = false;
            Set_Pass_textBox.Enabled = false;
            Set_DB_textBox.Enabled = false;
            Set_User_textBox.Enabled = false;

            Sleep_Millisecond(2000);

            try
            {
                connStr = "server=" + Set_Host_textBox.Text + "; user id=" + Set_User_textBox.Text + "; password=" + Set_Pass_textBox.Text + "; pooling=false";

                //DB接続
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();

                //データベースの作成
                String cmd1 = "CREATE DATABASE `" + Set_DB_textBox.Text + "` DEFAULT CHARSET=utf8 COLLATE utf8_general_ci;";
                //writeLog(cmd1 + "を実行");
                writeLog("データベース"+ Set_DB_textBox.Text +"の作成");
                cmd = new MySqlCommand(cmd1, conn);
                cmd.ExecuteNonQuery();
                Sleep_Millisecond(1000);


                //データベース切り替え
                String cmd2 = "USE " + Set_DB_textBox.Text + ";";
                writeLog("データベース" + Set_DB_textBox.Text + "に切り替え");
                //writeLog(cmd2 + "を実行");
                cmd = new MySqlCommand(cmd2, conn);
                cmd.ExecuteNonQuery();
                Sleep_Millisecond(1000);

                // 学科コードテーブル作成
                StringBuilder cmd3 = new StringBuilder();
                cmd3.Append("CREATE TABLE `" + Set_DB_textBox.Text + "`.`department` ( `department` VARCHAR(10) NOT NULL , `department_name` VARCHAR(20) NOT NULL , PRIMARY KEY (`department`(10))) ENGINE = InnoDB;");
                writeLog("科コードテーブル作成");
                //writeLog(cmd3 + "を実行");
                cmd.CommandText = cmd3.ToString();
                cmd.ExecuteNonQuery();
                Sleep_Millisecond(1000);

                // 学生データテーブルの作成
                StringBuilder cmd4 = new StringBuilder();
                cmd4.Append("CREATE TABLE `" + Set_DB_textBox.Text + "`.`gakuseki` ( `gakuseki_no` VARCHAR(10) NOT NULL , `name` VARCHAR(40) , `department` VARCHAR(10) NOT NULL , `class` INT NOT NULL ,`grade` INT NOT NULL, PRIMARY KEY (`gakuseki_no`(10)), FOREIGN KEY (`department`) REFERENCES  `department`(`department`))   ENGINE = InnoDB;");
                //writeLog(cmd4 + "を実行");
                writeLog("学生情報テーブルの作成");
                cmd.CommandText = cmd4.ToString();
                cmd.ExecuteNonQuery();
                Sleep_Millisecond(1000);

                // データテーブルの作成
                StringBuilder cmd5 = new StringBuilder();
                cmd5.Append("CREATE TABLE `" + Set_DB_textBox.Text + "`.`data` ( `no` INT NOT NULL AUTO_INCREMENT , `gakuseki_no` VARCHAR(10) NOT NULL , `time` DATETIME NOT NULL , `Insertinfo` VARCHAR(10)  , PRIMARY KEY (`no`)) ENGINE = InnoDB;");
                //writeLog(cmd5 + "を実行");
                writeLog("データテーブルの作成");
                cmd.CommandText = cmd5.ToString();
                cmd.ExecuteNonQuery();
                Sleep_Millisecond(1000);



                string filePath = @"./Resources/department.csv";
                StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("shift_jis"));

                writeLog("科コードの挿入");
                while (reader.Peek() >= 0)
                {
                    StringBuilder cmd6 = new StringBuilder();
                    string[] cols = reader.ReadLine().Split(',');
                    for (int n = 0; n < cols.Length; n++) writeLog(cols[n] + "\t");
                    writeLog("を追加");
                    string Insert_SQL = "INSERT INTO `" + Set_DB_textBox.Text + "`.`department` ( `department`,`department_name` ) value ('" + cols[0] + "','" + cols[1] + "')";

                    //writeLog(Insert_SQL + "を実行");
                    writeLog("");

                    cmd.CommandText = Insert_SQL;
                    cmd.ExecuteNonQuery();
                    Sleep_Millisecond(100);
                }
                reader.Close();
                Sleep_Millisecond(1000);

                // ユーザーmaron_useの作成
                StringBuilder cmd7 = new StringBuilder();
                StringBuilder cmd8 = new StringBuilder();
                cmd7.Append("CREATE USER 'maron_use'@'%' identified by 'maronusepasspass';");
                cmd8.Append("GRANT SELECT, INSERT ON *.* TO 'maron_use'@'%' REQUIRE NONE WITH MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0;");
                try
                {
                    //writeLog(cmd7 + "を実行");
                    writeLog("ユーザーの作成１");
                    cmd.CommandText = cmd7.ToString();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    writeLog("すでにユーザーが存在します");
                }
                Sleep_Millisecond(1000);
                try
                {
                    //writeLog(cmd8 + "を実行");
                    writeLog("ユーザーの権限付与");
                    cmd.CommandText = cmd8.ToString();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception eee)
                {
                    writeLog("Error : " + eee.Message);
                }
                Sleep_Millisecond(1000);

                // ユーザーmaron_adminの作成
                StringBuilder cmd9 = new StringBuilder();
                StringBuilder cmd10 = new StringBuilder();
                StringBuilder cmd11 = new StringBuilder();
                cmd9.Append("CREATE USER 'maron_admin'@'%' identified by 'maronadminpasspass';");
                cmd10.Append("GRANT ALL PRIVILEGES ON *.* TO 'maron_admin'@'%' REQUIRE NONE WITH GRANT OPTION MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0;");
                //cmd11.Append("GRANT ALL PRIVILEGES ON `a1`.* TO 'maron_admin'@'%';");
                try
                {
                    //writeLog(cmd9 + "を実行");
                    writeLog("ユーザーの作成２");
                    cmd.CommandText = cmd9.ToString();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    writeLog("すでにユーザーが存在します");
                }
                Sleep_Millisecond(1000);
                try
                {
                    //writeLog(cmd10 + "を実行");
                    writeLog("ユーザーの権限付与");
                    cmd.CommandText = cmd10.ToString();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception eeeeee)
                {
                    writeLog("Error : " + eeeeee.Message);
                }
                Sleep_Millisecond(1000);
                //writeLog(cmd11 + "を実行");
                //cmd.CommandText = cmd11.ToString();
                //cmd.ExecuteNonQuery();
                //Sleep_Millisecond(1000);

                //外部キー制約
                StringBuilder cmd12 = new StringBuilder();
                cmd12.Append("ALTER TABLE `gakuseki` ADD FOREIGN KEY(`department`) REFERENCES `department`(`department`) ON DELETE RESTRICT ON UPDATE RESTRICT;");
                try
                {
                    //writeLog(cmd12 + "を実行");
                    writeLog("ユーザーの権限付与");
                    cmd.CommandText = cmd12.ToString();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception eeeeeee)
                {
                    writeLog("Error : " + eeeeeee.Message);
                }
                Sleep_Millisecond(1000);


                writeLog("Complete!!!");


                MessageBox.Show("DB構築に成功しました",
                    "終了",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.None);




            }
            catch (Exception eeeeeeeee)
            {
                Thread.Sleep(1000);

                DialogResult result = MessageBox.Show(eeeeeeeee.Message +"エラーが発生しました。データベースを削除しますか？",
    "エラー",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Exclamation,
    MessageBoxDefaultButton.Button2);

                writeLog("Error : " + eeeeeeeee.Message);

                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    StringBuilder cmd13 = new StringBuilder();
                    cmd13.Append("DROP DATABASE `" + Set_DB_textBox.Text + "` ;");
                    try
                    {
                        writeLog(cmd13 + "を実行");
                        cmd.CommandText = cmd13.ToString();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception eeeeeee)
                    {
                        writeLog("Error : " + eeeeeee.Message);
                    }
                    Sleep_Millisecond(1000);

                    writeLog("Error : " + eeeeeeeee.Message);
                    writeLog("エラーが発生しました、データベースを削除しました");
                }
                else if (result == DialogResult.No)
                {
                    writeLog("エラーが発生しました");
                }

            }
            finally
            {
                Start_Button.Enabled = true;
                Set_Host_textBox.Enabled = true;
                Set_Pass_textBox.Enabled = true;
                Set_DB_textBox.Enabled = true;
                Set_User_textBox.Enabled = true;
            }
        }

        static void Sleep_Millisecond(int ms)
        {
            for (int i = 0; i < ms * 8; i = i + 1000)
            {
                Thread.Sleep(125);
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("メモ帳を開きます\n科コード編集後上書き保存してください\n書式は科コード（英数字）,学科名のCSVファイルです", "科コード編集", MessageBoxButtons.OK, MessageBoxIcon.None);
            System.Diagnostics.Process.Start("notepad.exe", @"""./Resources/department.csv""");
        }
    }
}
