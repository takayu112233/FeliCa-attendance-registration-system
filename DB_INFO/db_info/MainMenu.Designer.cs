namespace db_info
{
    partial class MainMenu
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.show_ip = new System.Windows.Forms.Label();
            this.show_host = new System.Windows.Forms.Label();
            this.DB_info_read = new System.Windows.Forms.Timer(this.components);
            this.Log_GridView = new System.Windows.Forms.DataGridView();
            this.Insert_gakuseki_Botton = new System.Windows.Forms.Button();
            this.export_Mode_Botton = new System.Windows.Forms.Button();
            this.pcmode_button = new System.Windows.Forms.Button();
            this.shutdown_button = new System.Windows.Forms.Button();
            this.DB_info = new System.Windows.Forms.Label();
            this.Log_on = new System.Windows.Forms.Button();
            this.Log_off = new System.Windows.Forms.Button();
            this.Log_setting = new System.Windows.Forms.Button();
            this.Log_Read_timer = new System.Windows.Forms.Timer(this.components);
            this.Log_Start_Time = new System.Windows.Forms.Timer(this.components);
            this.DB_info_pictureBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Now_Time_Show = new System.Windows.Forms.Label();
            this.IPandHost = new System.Windows.Forms.Timer(this.components);
            this.DB_name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Log_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DB_info_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "最新登録データ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(871, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "IPアドレス";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(871, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "ホスト名";
            // 
            // show_ip
            // 
            this.show_ip.AutoSize = true;
            this.show_ip.Font = new System.Drawing.Font("MS UI Gothic", 35F, System.Drawing.FontStyle.Bold);
            this.show_ip.Location = new System.Drawing.Point(985, 12);
            this.show_ip.Name = "show_ip";
            this.show_ip.Size = new System.Drawing.Size(353, 47);
            this.show_ip.TabIndex = 5;
            this.show_ip.Text = "255.255.255.255";
            // 
            // show_host
            // 
            this.show_host.AutoSize = true;
            this.show_host.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.show_host.Location = new System.Drawing.Point(979, 82);
            this.show_host.Name = "show_host";
            this.show_host.Size = new System.Drawing.Size(120, 24);
            this.show_host.TabIndex = 6;
            this.show_host.Text = "show_host";
            // 
            // DB_info_read
            // 
            this.DB_info_read.Interval = 1000;
            this.DB_info_read.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Log_GridView
            // 
            this.Log_GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Log_GridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Log_GridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Log_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Log_GridView.Location = new System.Drawing.Point(12, 120);
            this.Log_GridView.Name = "Log_GridView";
            this.Log_GridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Log_GridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Log_GridView.RowHeadersVisible = false;
            this.Log_GridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Log_GridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.Log_GridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("MS UI Gothic", 13F, System.Drawing.FontStyle.Bold);
            this.Log_GridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Log_GridView.RowTemplate.Height = 21;
            this.Log_GridView.Size = new System.Drawing.Size(1342, 577);
            this.Log_GridView.TabIndex = 7;
            // 
            // Insert_gakuseki_Botton
            // 
            this.Insert_gakuseki_Botton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Insert_gakuseki_Botton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Insert_gakuseki_Botton.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.Insert_gakuseki_Botton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Insert_gakuseki_Botton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Insert_gakuseki_Botton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Insert_gakuseki_Botton.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Insert_gakuseki_Botton.ForeColor = System.Drawing.Color.Black;
            this.Insert_gakuseki_Botton.Location = new System.Drawing.Point(300, 703);
            this.Insert_gakuseki_Botton.Name = "Insert_gakuseki_Botton";
            this.Insert_gakuseki_Botton.Size = new System.Drawing.Size(368, 57);
            this.Insert_gakuseki_Botton.TabIndex = 8;
            this.Insert_gakuseki_Botton.Text = "学生情報CSV読込";
            this.Insert_gakuseki_Botton.UseVisualStyleBackColor = false;
            this.Insert_gakuseki_Botton.Click += new System.EventHandler(this.Insert_gakuseki_Botton_Click);
            // 
            // export_Mode_Botton
            // 
            this.export_Mode_Botton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.export_Mode_Botton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.export_Mode_Botton.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.export_Mode_Botton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.export_Mode_Botton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.export_Mode_Botton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.export_Mode_Botton.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.export_Mode_Botton.ForeColor = System.Drawing.Color.Black;
            this.export_Mode_Botton.Location = new System.Drawing.Point(687, 703);
            this.export_Mode_Botton.Name = "export_Mode_Botton";
            this.export_Mode_Botton.Size = new System.Drawing.Size(368, 57);
            this.export_Mode_Botton.TabIndex = 9;
            this.export_Mode_Botton.Text = "登録情報CSV書き出し";
            this.export_Mode_Botton.UseVisualStyleBackColor = false;
            this.export_Mode_Botton.Click += new System.EventHandler(this.export_Mode_Botton_Click);
            // 
            // pcmode_button
            // 
            this.pcmode_button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pcmode_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcmode_button.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.pcmode_button.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pcmode_button.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pcmode_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pcmode_button.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pcmode_button.ForeColor = System.Drawing.Color.Black;
            this.pcmode_button.Location = new System.Drawing.Point(1278, 703);
            this.pcmode_button.Name = "pcmode_button";
            this.pcmode_button.Size = new System.Drawing.Size(76, 24);
            this.pcmode_button.TabIndex = 11;
            this.pcmode_button.Text = "PCモード";
            this.pcmode_button.UseVisualStyleBackColor = false;
            this.pcmode_button.Click += new System.EventHandler(this.pcmode_button_Click);
            // 
            // shutdown_button
            // 
            this.shutdown_button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.shutdown_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shutdown_button.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.shutdown_button.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.shutdown_button.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.shutdown_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shutdown_button.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.shutdown_button.ForeColor = System.Drawing.Color.Black;
            this.shutdown_button.Location = new System.Drawing.Point(1278, 733);
            this.shutdown_button.Name = "shutdown_button";
            this.shutdown_button.Size = new System.Drawing.Size(76, 24);
            this.shutdown_button.TabIndex = 12;
            this.shutdown_button.Text = "シャットダウン";
            this.shutdown_button.UseVisualStyleBackColor = false;
            this.shutdown_button.Click += new System.EventHandler(this.shutdown_button_Click);
            // 
            // DB_info
            // 
            this.DB_info.AutoSize = true;
            this.DB_info.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DB_info.Location = new System.Drawing.Point(121, 31);
            this.DB_info.Name = "DB_info";
            this.DB_info.Size = new System.Drawing.Size(329, 48);
            this.DB_info.TabIndex = 0;
            this.DB_info.Text = "DB監視準備中";
            // 
            // Log_on
            // 
            this.Log_on.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Log_on.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Log_on.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.Log_on.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Log_on.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Log_on.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Log_on.Font = new System.Drawing.Font("MS UI Gothic", 8.25F);
            this.Log_on.ForeColor = System.Drawing.Color.Black;
            this.Log_on.Location = new System.Drawing.Point(12, 732);
            this.Log_on.Name = "Log_on";
            this.Log_on.Size = new System.Drawing.Size(109, 24);
            this.Log_on.TabIndex = 13;
            this.Log_on.Text = "リアルタイム監視オン";
            this.Log_on.UseVisualStyleBackColor = false;
            this.Log_on.Click += new System.EventHandler(this.Log_on_Click);
            // 
            // Log_off
            // 
            this.Log_off.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Log_off.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Log_off.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.Log_off.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Log_off.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Log_off.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Log_off.Font = new System.Drawing.Font("MS UI Gothic", 8.25F);
            this.Log_off.ForeColor = System.Drawing.Color.Black;
            this.Log_off.Location = new System.Drawing.Point(129, 732);
            this.Log_off.Name = "Log_off";
            this.Log_off.Size = new System.Drawing.Size(109, 24);
            this.Log_off.TabIndex = 14;
            this.Log_off.Text = "リアルタイム監視オフ";
            this.Log_off.UseVisualStyleBackColor = false;
            this.Log_off.Click += new System.EventHandler(this.Log_off_Click);
            // 
            // Log_setting
            // 
            this.Log_setting.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Log_setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Log_setting.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.Log_setting.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Log_setting.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Log_setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Log_setting.Font = new System.Drawing.Font("MS UI Gothic", 8.25F);
            this.Log_setting.ForeColor = System.Drawing.Color.Black;
            this.Log_setting.Location = new System.Drawing.Point(12, 703);
            this.Log_setting.Name = "Log_setting";
            this.Log_setting.Size = new System.Drawing.Size(60, 24);
            this.Log_setting.TabIndex = 15;
            this.Log_setting.Text = "DB設定";
            this.Log_setting.UseVisualStyleBackColor = false;
            this.Log_setting.Click += new System.EventHandler(this.Log_setting_Click);
            // 
            // Log_Read_timer
            // 
            this.Log_Read_timer.Interval = 2000;
            this.Log_Read_timer.Tick += new System.EventHandler(this.Log_Read_timer_Tick);
            // 
            // Log_Start_Time
            // 
            this.Log_Start_Time.Enabled = true;
            this.Log_Start_Time.Interval = 1000;
            this.Log_Start_Time.Tick += new System.EventHandler(this.Log_Start_Time_Tick);
            // 
            // DB_info_pictureBox
            // 
            this.DB_info_pictureBox.Image = global::db_info.Properties.Resources.DB_DisConnect;
            this.DB_info_pictureBox.Location = new System.Drawing.Point(24, 11);
            this.DB_info_pictureBox.Name = "DB_info_pictureBox";
            this.DB_info_pictureBox.Size = new System.Drawing.Size(91, 68);
            this.DB_info_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DB_info_pictureBox.TabIndex = 17;
            this.DB_info_pictureBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(448, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 24);
            this.label4.TabIndex = 18;
            this.label4.Text = "DB日時";
            // 
            // Now_Time_Show
            // 
            this.Now_Time_Show.AutoSize = true;
            this.Now_Time_Show.Font = new System.Drawing.Font("MS UI Gothic", 35F, System.Drawing.FontStyle.Bold);
            this.Now_Time_Show.Location = new System.Drawing.Point(547, 12);
            this.Now_Time_Show.Name = "Now_Time_Show";
            this.Now_Time_Show.Size = new System.Drawing.Size(0, 47);
            this.Now_Time_Show.TabIndex = 19;
            // 
            // IPandHost
            // 
            this.IPandHost.Enabled = true;
            this.IPandHost.Interval = 1000;
            this.IPandHost.Tick += new System.EventHandler(this.IPandHost_Tick);
            // 
            // DB_name
            // 
            this.DB_name.AutoSize = true;
            this.DB_name.Location = new System.Drawing.Point(78, 709);
            this.DB_name.Name = "DB_name";
            this.DB_name.Size = new System.Drawing.Size(45, 12);
            this.DB_name.TabIndex = 20;
            this.DB_name.Text = "監視DB";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1366, 766);
            this.Controls.Add(this.DB_name);
            this.Controls.Add(this.Now_Time_Show);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DB_info_pictureBox);
            this.Controls.Add(this.Log_setting);
            this.Controls.Add(this.Log_off);
            this.Controls.Add(this.Log_on);
            this.Controls.Add(this.shutdown_button);
            this.Controls.Add(this.pcmode_button);
            this.Controls.Add(this.export_Mode_Botton);
            this.Controls.Add(this.Insert_gakuseki_Botton);
            this.Controls.Add(this.Log_GridView);
            this.Controls.Add(this.show_host);
            this.Controls.Add(this.show_ip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DB_info);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Log_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DB_info_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label show_ip;
        private System.Windows.Forms.Label show_host;
        private System.Windows.Forms.Timer DB_info_read;
        private System.Windows.Forms.DataGridView Log_GridView;
        private System.Windows.Forms.Button Insert_gakuseki_Botton;
        private System.Windows.Forms.Button export_Mode_Botton;
        private System.Windows.Forms.Button pcmode_button;
        private System.Windows.Forms.Button shutdown_button;
        private System.Windows.Forms.Label DB_info;
        private System.Windows.Forms.Button Log_on;
        private System.Windows.Forms.Button Log_off;
        private System.Windows.Forms.Button Log_setting;
        private System.Windows.Forms.Timer Log_Read_timer;
        private System.Windows.Forms.Timer Log_Start_Time;
        private System.Windows.Forms.PictureBox DB_info_pictureBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Now_Time_Show;
        private System.Windows.Forms.Timer IPandHost;
        private System.Windows.Forms.Label DB_name;
    }
}

