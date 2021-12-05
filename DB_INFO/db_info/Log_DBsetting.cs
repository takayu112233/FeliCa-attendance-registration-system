using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace db_info
{
    public partial class Log_DBsetting : Form
    {

        MySqlConnection conn;
        public String Set_Hostname, Set_Password, Set_User, Set_Database;

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("設定を保存しますか？",
            "保存の確認",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["host"].Value = Set_Host_textBox.Text;
                config.AppSettings.Settings["pass"].Value = Set_Pass_textBox.Text;
                config.AppSettings.Settings["user"].Value = Set_User_textBox.Text;
                config.AppSettings.Settings["db"].Value = Set_DB_textBox.Text;
                config.Save();


                Set_Hostname = Set_Host_textBox.Text;
                Set_Password = Set_Pass_textBox.Text;
                Set_User = Set_User_textBox.Text;
                Set_Database = Set_DB_textBox.Text;


                this.Close();
                return;
            }
            else if (result == DialogResult.No)
            {
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("設定を取り消しますか？",
            "終了の確認",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else if (result == DialogResult.No)
            {
            }
        }

        private void Set_Pass_textBox_TextChanged(object sender, EventArgs e)
        {
            Set_Pass_textBox.PasswordChar = '*';
        }

        private void DB_Test_Button_Click(object sender, EventArgs e)
        {
            DB_Info_Show.Text = "テスト中";


            String connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", Set_Host_textBox.Text, Set_DB_textBox.Text, Set_User_textBox.Text, Set_Pass_textBox.Text);

            try
            {
                Cancel_Button.Enabled = false;
                OK_Button.Enabled = false;

                conn = new MySqlConnection(connectionString);
                conn.Open();

                string connect_send = "SELECT 'ホスト名:" + Environment.MachineName + "が接続テスト'";
                MySqlCommand cmd = new MySqlCommand(connect_send, conn);
                cmd.ExecuteNonQuery();


                DB_Info_Show.Text = "接続OK";


                Cancel_Button.Enabled = true;
                OK_Button.Enabled = true;
            }
            catch (MySqlException me)
            {

                DB_Info_Show.Text = "接続NG";

                String err = me.Message;
                MessageBox.Show(err,
                    "DB接続エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);


                Cancel_Button.Enabled = true;
                OK_Button.Enabled = true;
            }
        }

        public Log_DBsetting(String Set_Hostname, String Set_Password, String Set_User, String Set_Database)
        {
            InitializeComponent();
            this.Set_Hostname = Set_Hostname;
            this.Set_Password = Set_Password;
            this.Set_User = Set_User;
            this.Set_Database = Set_Database;
        }

        private void Log_DBsetting_Load_1(object sender, EventArgs e)
        {
            Set_DB_textBox.Text = Set_Database;
            Set_Host_textBox.Text = Set_Hostname;
            Set_Pass_textBox.Text = Set_Password;
            Set_User_textBox.Text = Set_User;

            this.FormBorderStyle = FormBorderStyle.None;//全画面の設定
            this.WindowState = FormWindowState.Maximized;//全画面の設定２
            this.TopMost = true;//最前面
        }
    }
}
