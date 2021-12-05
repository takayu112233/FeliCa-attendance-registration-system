namespace NFC_READ
{
    partial class Main_Read
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Read));
            this.Timer_1Sec = new System.Windows.Forms.Timer(this.components);
            this.Read_Info_Show = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Name_label = new System.Windows.Forms.Label();
            this.Data_Name_Show = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Now_Time_Show = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Data_Time_Show = new System.Windows.Forms.Label();
            this.End_Button = new System.Windows.Forms.Button();
            this.Auto_ON_Button = new System.Windows.Forms.Button();
            this.Auto_OFF_Button = new System.Windows.Forms.Button();
            this.Debug_Count_Show = new System.Windows.Forms.Label();
            this.ScanTimer = new System.Windows.Forms.Timer(this.components);
            this.DB_Connect_Button = new System.Windows.Forms.Button();
            this.DB_Disconnect_Button = new System.Windows.Forms.Button();
            this.DB_Setting_Button = new System.Windows.Forms.Button();
            this.DB_Info_Show = new System.Windows.Forms.Label();
            this.Info_Show = new System.Windows.Forms.TextBox();
            this.Data_Gakuseki_Show = new System.Windows.Forms.TextBox();
            this.Touch_Moji = new System.Windows.Forms.Label();
            this.Ok_show_timer = new System.Windows.Forms.Timer(this.components);
            this.Ok_info = new System.Windows.Forms.Label();
            this.No_Enter = new System.Windows.Forms.Button();
            this.Offline_Cash_pictureBox = new System.Windows.Forms.PictureBox();
            this.DB_info_pictureBox = new System.Windows.Forms.PictureBox();
            this.Logo_pictureBox = new System.Windows.Forms.PictureBox();
            this.Info_pictureBox = new System.Windows.Forms.PictureBox();
            this.Offline_Cash_Label = new System.Windows.Forms.Label();
            this.Offline_Button = new System.Windows.Forms.Button();
            this.ClientName_Show = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DBName_Show = new System.Windows.Forms.Label();
            this.ClientName_Show2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Offline_Cash_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DB_info_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Info_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer_1Sec
            // 
            this.Timer_1Sec.Interval = 1000;
            this.Timer_1Sec.Tick += new System.EventHandler(this.Timer_1Sec_Tick);
            // 
            // Read_Info_Show
            // 
            this.Read_Info_Show.AutoSize = true;
            this.Read_Info_Show.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Read_Info_Show.ForeColor = System.Drawing.Color.Green;
            this.Read_Info_Show.Location = new System.Drawing.Point(446, 702);
            this.Read_Info_Show.Name = "Read_Info_Show";
            this.Read_Info_Show.Size = new System.Drawing.Size(39, 27);
            this.Read_Info_Show.TabIndex = 19;
            this.Read_Info_Show.Text = "■";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(619, 430);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 33);
            this.label6.TabIndex = 20;
            this.label6.Text = "学籍番号";
            // 
            // Name_label
            // 
            this.Name_label.AutoSize = true;
            this.Name_label.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.Name_label.Location = new System.Drawing.Point(619, 534);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(81, 33);
            this.Name_label.TabIndex = 21;
            this.Name_label.Text = "氏名";
            // 
            // Data_Name_Show
            // 
            this.Data_Name_Show.AutoSize = true;
            this.Data_Name_Show.Font = new System.Drawing.Font("MS UI Gothic", 60F, System.Drawing.FontStyle.Bold);
            this.Data_Name_Show.Location = new System.Drawing.Point(772, 492);
            this.Data_Name_Show.Name = "Data_Name_Show";
            this.Data_Name_Show.Size = new System.Drawing.Size(412, 80);
            this.Data_Name_Show.TabIndex = 23;
            this.Data_Name_Show.Text = "山本　沙羅";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(3, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 33);
            this.label1.TabIndex = 24;
            this.label1.Text = "現在時刻";
            // 
            // Now_Time_Show
            // 
            this.Now_Time_Show.AutoSize = true;
            this.Now_Time_Show.Font = new System.Drawing.Font("メイリオ", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Now_Time_Show.Location = new System.Drawing.Point(133, 2);
            this.Now_Time_Show.Name = "Now_Time_Show";
            this.Now_Time_Show.Size = new System.Drawing.Size(348, 144);
            this.Now_Time_Show.TabIndex = 25;
            this.Now_Time_Show.Text = "未取得";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(619, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 33);
            this.label2.TabIndex = 28;
            this.label2.Text = "入場時間";
            // 
            // Data_Time_Show
            // 
            this.Data_Time_Show.AutoSize = true;
            this.Data_Time_Show.Font = new System.Drawing.Font("MS UI Gothic", 60F, System.Drawing.FontStyle.Bold);
            this.Data_Time_Show.Location = new System.Drawing.Point(772, 274);
            this.Data_Time_Show.Name = "Data_Time_Show";
            this.Data_Time_Show.Size = new System.Drawing.Size(314, 80);
            this.Data_Time_Show.TabIndex = 29;
            this.Data_Time_Show.Text = "08:17:23";
            // 
            // End_Button
            // 
            this.End_Button.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.End_Button.Location = new System.Drawing.Point(660, 702);
            this.End_Button.Name = "End_Button";
            this.End_Button.Size = new System.Drawing.Size(88, 24);
            this.End_Button.TabIndex = 6;
            this.End_Button.Text = "終了";
            this.End_Button.UseVisualStyleBackColor = true;
            this.End_Button.Click += new System.EventHandler(this.End_Button_Click);
            // 
            // Auto_ON_Button
            // 
            this.Auto_ON_Button.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Auto_ON_Button.Location = new System.Drawing.Point(491, 702);
            this.Auto_ON_Button.Name = "Auto_ON_Button";
            this.Auto_ON_Button.Size = new System.Drawing.Size(103, 24);
            this.Auto_ON_Button.TabIndex = 3;
            this.Auto_ON_Button.Text = "タッチモード開始";
            this.Auto_ON_Button.UseVisualStyleBackColor = true;
            this.Auto_ON_Button.Click += new System.EventHandler(this.Auto_ON_Button_Click);
            // 
            // Auto_OFF_Button
            // 
            this.Auto_OFF_Button.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Auto_OFF_Button.Location = new System.Drawing.Point(491, 702);
            this.Auto_OFF_Button.Name = "Auto_OFF_Button";
            this.Auto_OFF_Button.Size = new System.Drawing.Size(103, 24);
            this.Auto_OFF_Button.TabIndex = 5;
            this.Auto_OFF_Button.TabStop = false;
            this.Auto_OFF_Button.Text = "タッチモード終了";
            this.Auto_OFF_Button.UseVisualStyleBackColor = true;
            this.Auto_OFF_Button.Click += new System.EventHandler(this.Auto_OFF_Button_Click);
            // 
            // Debug_Count_Show
            // 
            this.Debug_Count_Show.AutoSize = true;
            this.Debug_Count_Show.ForeColor = System.Drawing.Color.Red;
            this.Debug_Count_Show.Location = new System.Drawing.Point(754, 711);
            this.Debug_Count_Show.Name = "Debug_Count_Show";
            this.Debug_Count_Show.Size = new System.Drawing.Size(11, 12);
            this.Debug_Count_Show.TabIndex = 38;
            this.Debug_Count_Show.Text = "0";
            // 
            // ScanTimer
            // 
            this.ScanTimer.Tick += new System.EventHandler(this.ScanTimer_Tick);
            // 
            // DB_Connect_Button
            // 
            this.DB_Connect_Button.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DB_Connect_Button.Location = new System.Drawing.Point(248, 702);
            this.DB_Connect_Button.Name = "DB_Connect_Button";
            this.DB_Connect_Button.Size = new System.Drawing.Size(88, 24);
            this.DB_Connect_Button.TabIndex = 1;
            this.DB_Connect_Button.Text = "DB接続";
            this.DB_Connect_Button.UseVisualStyleBackColor = true;
            this.DB_Connect_Button.Click += new System.EventHandler(this.DB_Connect_Button_Click);
            // 
            // DB_Disconnect_Button
            // 
            this.DB_Disconnect_Button.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DB_Disconnect_Button.Location = new System.Drawing.Point(248, 702);
            this.DB_Disconnect_Button.Name = "DB_Disconnect_Button";
            this.DB_Disconnect_Button.Size = new System.Drawing.Size(88, 24);
            this.DB_Disconnect_Button.TabIndex = 2;
            this.DB_Disconnect_Button.Text = "DB切断";
            this.DB_Disconnect_Button.UseVisualStyleBackColor = true;
            this.DB_Disconnect_Button.Click += new System.EventHandler(this.DB_Disconnect_Button_Click);
            // 
            // DB_Setting_Button
            // 
            this.DB_Setting_Button.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DB_Setting_Button.Location = new System.Drawing.Point(154, 702);
            this.DB_Setting_Button.Name = "DB_Setting_Button";
            this.DB_Setting_Button.Size = new System.Drawing.Size(88, 24);
            this.DB_Setting_Button.TabIndex = 0;
            this.DB_Setting_Button.Text = "DB設定";
            this.DB_Setting_Button.UseVisualStyleBackColor = true;
            this.DB_Setting_Button.Click += new System.EventHandler(this.DB_Setting_Button_Click);
            // 
            // DB_Info_Show
            // 
            this.DB_Info_Show.AutoSize = true;
            this.DB_Info_Show.Location = new System.Drawing.Point(40, 674);
            this.DB_Info_Show.Name = "DB_Info_Show";
            this.DB_Info_Show.Size = new System.Drawing.Size(57, 12);
            this.DB_Info_Show.TabIndex = 42;
            this.DB_Info_Show.Text = "DB未接続";
            // 
            // Info_Show
            // 
            this.Info_Show.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Info_Show.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Info_Show.Font = new System.Drawing.Font("MS UI Gothic", 40F, System.Drawing.FontStyle.Bold);
            this.Info_Show.ForeColor = System.Drawing.Color.Black;
            this.Info_Show.Location = new System.Drawing.Point(625, 199);
            this.Info_Show.Name = "Info_Show";
            this.Info_Show.ReadOnly = true;
            this.Info_Show.Size = new System.Drawing.Size(713, 54);
            this.Info_Show.TabIndex = 43;
            this.Info_Show.TabStop = false;
            this.Info_Show.Text = "Info_Show";
            this.Info_Show.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Data_Gakuseki_Show
            // 
            this.Data_Gakuseki_Show.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Data_Gakuseki_Show.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Data_Gakuseki_Show.Font = new System.Drawing.Font("MS UI Gothic", 60F, System.Drawing.FontStyle.Bold);
            this.Data_Gakuseki_Show.Location = new System.Drawing.Point(786, 383);
            this.Data_Gakuseki_Show.Name = "Data_Gakuseki_Show";
            this.Data_Gakuseki_Show.Size = new System.Drawing.Size(429, 80);
            this.Data_Gakuseki_Show.TabIndex = 44;
            this.Data_Gakuseki_Show.TabStop = false;
            this.Data_Gakuseki_Show.Text = "K018C1031";
            // 
            // Touch_Moji
            // 
            this.Touch_Moji.AutoSize = true;
            this.Touch_Moji.Font = new System.Drawing.Font("MS UI Gothic", 35F, System.Drawing.FontStyle.Bold);
            this.Touch_Moji.Location = new System.Drawing.Point(57, 575);
            this.Touch_Moji.Name = "Touch_Moji";
            this.Touch_Moji.Size = new System.Drawing.Size(472, 47);
            this.Touch_Moji.TabIndex = 46;
            this.Touch_Moji.Text = "カードをタッチしてください";
            // 
            // Ok_show_timer
            // 
            this.Ok_show_timer.Interval = 2000;
            this.Ok_show_timer.Tick += new System.EventHandler(this.Ok_show_timer_Tick);
            // 
            // Ok_info
            // 
            this.Ok_info.AutoSize = true;
            this.Ok_info.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.Ok_info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Ok_info.Location = new System.Drawing.Point(827, 169);
            this.Ok_info.Name = "Ok_info";
            this.Ok_info.Size = new System.Drawing.Size(309, 27);
            this.Ok_info.TabIndex = 47;
            this.Ok_info.Text = "■■■■■■■■■■■";
            // 
            // No_Enter
            // 
            this.No_Enter.Location = new System.Drawing.Point(1328, 708);
            this.No_Enter.Name = "No_Enter";
            this.No_Enter.Size = new System.Drawing.Size(10, 18);
            this.No_Enter.TabIndex = 4;
            this.No_Enter.TabStop = false;
            this.No_Enter.UseVisualStyleBackColor = true;
            // 
            // Offline_Cash_pictureBox
            // 
            this.Offline_Cash_pictureBox.Image = global::NFC_READ.Properties.Resources.Information;
            this.Offline_Cash_pictureBox.Location = new System.Drawing.Point(6, 622);
            this.Offline_Cash_pictureBox.Name = "Offline_Cash_pictureBox";
            this.Offline_Cash_pictureBox.Size = new System.Drawing.Size(28, 31);
            this.Offline_Cash_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Offline_Cash_pictureBox.TabIndex = 49;
            this.Offline_Cash_pictureBox.TabStop = false;
            this.Offline_Cash_pictureBox.Visible = false;
            this.Offline_Cash_pictureBox.Click += new System.EventHandler(this.Offline_Cash_pictureBox_Click);
            // 
            // DB_info_pictureBox
            // 
            this.DB_info_pictureBox.Image = global::NFC_READ.Properties.Resources.DB_DisConnect;
            this.DB_info_pictureBox.Location = new System.Drawing.Point(6, 655);
            this.DB_info_pictureBox.Name = "DB_info_pictureBox";
            this.DB_info_pictureBox.Size = new System.Drawing.Size(28, 31);
            this.DB_info_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DB_info_pictureBox.TabIndex = 48;
            this.DB_info_pictureBox.TabStop = false;
            // 
            // Logo_pictureBox
            // 
            this.Logo_pictureBox.Image = global::NFC_READ.Properties.Resources.realdreams;
            this.Logo_pictureBox.Location = new System.Drawing.Point(832, 2);
            this.Logo_pictureBox.Name = "Logo_pictureBox";
            this.Logo_pictureBox.Size = new System.Drawing.Size(519, 126);
            this.Logo_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo_pictureBox.TabIndex = 31;
            this.Logo_pictureBox.TabStop = false;
            // 
            // Info_pictureBox
            // 
            this.Info_pictureBox.Image = global::NFC_READ.Properties.Resources.新タッチ画像;
            this.Info_pictureBox.Location = new System.Drawing.Point(-5, 167);
            this.Info_pictureBox.Name = "Info_pictureBox";
            this.Info_pictureBox.Size = new System.Drawing.Size(618, 433);
            this.Info_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Info_pictureBox.TabIndex = 26;
            this.Info_pictureBox.TabStop = false;
            // 
            // Offline_Cash_Label
            // 
            this.Offline_Cash_Label.AutoSize = true;
            this.Offline_Cash_Label.Location = new System.Drawing.Point(40, 641);
            this.Offline_Cash_Label.Name = "Offline_Cash_Label";
            this.Offline_Cash_Label.Size = new System.Drawing.Size(69, 12);
            this.Offline_Cash_Label.TabIndex = 50;
            this.Offline_Cash_Label.Text = "未送信データ";
            this.Offline_Cash_Label.Visible = false;
            this.Offline_Cash_Label.Click += new System.EventHandler(this.Offline_Cash_Label_Click);
            // 
            // Offline_Button
            // 
            this.Offline_Button.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Offline_Button.Location = new System.Drawing.Point(342, 702);
            this.Offline_Button.Name = "Offline_Button";
            this.Offline_Button.Size = new System.Drawing.Size(88, 24);
            this.Offline_Button.TabIndex = 80;
            this.Offline_Button.Text = "オフライン待機";
            this.Offline_Button.UseVisualStyleBackColor = true;
            this.Offline_Button.Click += new System.EventHandler(this.Offline_Button_Click);
            // 
            // ClientName_Show
            // 
            this.ClientName_Show.AutoSize = true;
            this.ClientName_Show.Location = new System.Drawing.Point(50, 711);
            this.ClientName_Show.Name = "ClientName_Show";
            this.ClientName_Show.Size = new System.Drawing.Size(29, 12);
            this.ClientName_Show.TabIndex = 83;
            this.ClientName_Show.Text = "タッチ";
            this.ClientName_Show.Click += new System.EventHandler(this.ClientName_Show_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 710);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 82;
            this.label3.Text = "端末名：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 692);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 12);
            this.label4.TabIndex = 84;
            this.label4.Text = "DB名：";
            // 
            // DBName_Show
            // 
            this.DBName_Show.AutoSize = true;
            this.DBName_Show.Location = new System.Drawing.Point(42, 692);
            this.DBName_Show.Name = "DBName_Show";
            this.DBName_Show.Size = new System.Drawing.Size(21, 12);
            this.DBName_Show.TabIndex = 85;
            this.DBName_Show.Text = "DB";
            // 
            // ClientName_Show2
            // 
            this.ClientName_Show2.AutoSize = true;
            this.ClientName_Show2.Font = new System.Drawing.Font("MS UI Gothic", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ClientName_Show2.Location = new System.Drawing.Point(1287, 667);
            this.ClientName_Show2.Name = "ClientName_Show2";
            this.ClientName_Show2.Size = new System.Drawing.Size(51, 53);
            this.ClientName_Show2.TabIndex = 86;
            this.ClientName_Show2.Text = "0";
            // 
            // Main_Read
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.Read_Info_Show);
            this.Controls.Add(this.ClientName_Show2);
            this.Controls.Add(this.DBName_Show);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ClientName_Show);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Offline_Button);
            this.Controls.Add(this.Offline_Cash_Label);
            this.Controls.Add(this.Offline_Cash_pictureBox);
            this.Controls.Add(this.DB_info_pictureBox);
            this.Controls.Add(this.No_Enter);
            this.Controls.Add(this.Ok_info);
            this.Controls.Add(this.Touch_Moji);
            this.Controls.Add(this.Info_Show);
            this.Controls.Add(this.Data_Gakuseki_Show);
            this.Controls.Add(this.DB_Info_Show);
            this.Controls.Add(this.DB_Setting_Button);
            this.Controls.Add(this.Debug_Count_Show);
            this.Controls.Add(this.End_Button);
            this.Controls.Add(this.Data_Time_Show);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Data_Name_Show);
            this.Controls.Add(this.Name_label);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Now_Time_Show);
            this.Controls.Add(this.Logo_pictureBox);
            this.Controls.Add(this.DB_Connect_Button);
            this.Controls.Add(this.DB_Disconnect_Button);
            this.Controls.Add(this.Auto_ON_Button);
            this.Controls.Add(this.Auto_OFF_Button);
            this.Controls.Add(this.Info_pictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Main_Read";
            this.Text = "入場管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Read_FormClosing_1);
            this.Load += new System.EventHandler(this.Main_Read_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_Read_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.Offline_Cash_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DB_info_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Info_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Read_Info_Show;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Name_label;
        private System.Windows.Forms.Label Data_Name_Show;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Now_Time_Show;
        private System.Windows.Forms.PictureBox Info_pictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Data_Time_Show;
        private System.Windows.Forms.PictureBox Logo_pictureBox;
        private System.Windows.Forms.Button End_Button;
        private System.Windows.Forms.Button Auto_ON_Button;
        private System.Windows.Forms.Button Auto_OFF_Button;
        private System.Windows.Forms.Label Debug_Count_Show;
        private System.Windows.Forms.Timer ScanTimer;
        private System.Windows.Forms.Button DB_Connect_Button;
        private System.Windows.Forms.Button DB_Disconnect_Button;
        private System.Windows.Forms.Button DB_Setting_Button;
        private System.Windows.Forms.Label DB_Info_Show;
        private System.Windows.Forms.Timer Timer_1Sec;
        private System.Windows.Forms.TextBox Info_Show;
        private System.Windows.Forms.TextBox Data_Gakuseki_Show;
        private System.Windows.Forms.Label Touch_Moji;
        private System.Windows.Forms.Timer Ok_show_timer;
        private System.Windows.Forms.Label Ok_info;
        private System.Windows.Forms.Button No_Enter;
        private System.Windows.Forms.PictureBox DB_info_pictureBox;
        private System.Windows.Forms.PictureBox Offline_Cash_pictureBox;
        private System.Windows.Forms.Label Offline_Cash_Label;
        private System.Windows.Forms.Button Offline_Button;
        private System.Windows.Forms.Label ClientName_Show;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label DBName_Show;
        private System.Windows.Forms.Label ClientName_Show2;
    }
}