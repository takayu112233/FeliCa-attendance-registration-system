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




namespace NFC_READ
{
    public partial class DBSetting : Form
    {
        MySqlConnection conn;
        public String Set_Hostname, Set_Password, Set_User, Set_Database, Set_ClientName;

        public DBSetting(String Set_Hostname,String Set_Password,String Set_User,String Set_Database,String Set_ClientName)
        {
            InitializeComponent();
            this.Set_Hostname = Set_Hostname;
            this.Set_Password = Set_Password;
            this.Set_User = Set_User;
            this.Set_Database = Set_Database;
            this.Set_ClientName = Set_ClientName;

            this.FormBorderStyle = FormBorderStyle.None;//全画面の設定
            this.WindowState = FormWindowState.Maximized;//全画面の設定２
            this.TopMost = true;//最前面
        }

        private void DBSetting_Load(object sender, EventArgs e)
        {
            Set_DB_textBox.Text = Set_Database;
            Set_Host_textBox.Text = Set_Hostname;
            Set_Pass_textBox.Text = Set_Password;
            Set_User_textBox.Text = Set_User;

            Set_ClientName_comboBox.Text = Set_ClientName;


            String d;
            for (int count = 1; count < 10; count++)
            {
                d = "タッチ0" + count;

                Set_ClientName_comboBox.Items.Add(d);
            }

            try
            {
                Set_ClientName_comboBox.SelectedIndex = int.Parse(Set_ClientName.Remove(0, 4)) - 1;
            }
            catch (Exception)
            {
            }
        }

        private void Set_DB_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Set_Pass_textBox_TextChanged(object sender, EventArgs e)
        {
            Set_Pass_textBox.PasswordChar = '*';
        }

        private void Set_User_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Set_Host_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                config.AppSettings.Settings["ClientName"].Value = Set_ClientName_comboBox.Text;
                config.Save();


                Set_Hostname = Set_Host_textBox.Text;
                Set_Password = Set_Pass_textBox.Text;
                Set_User = Set_User_textBox.Text;
                Set_Database = Set_DB_textBox.Text;
                Set_ClientName = Set_ClientName_comboBox.Text;


                this.Close();
                return;
            }
            else if (result == DialogResult.No)
            {
            }
        }
    }
}
