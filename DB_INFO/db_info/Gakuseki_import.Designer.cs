namespace db_info
{
    partial class Gakuseki_import
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gakuseki_import));
            this.DB_Info_Show = new System.Windows.Forms.Label();
            this.DB_connect_Button = new System.Windows.Forms.Button();
            this.学生データインポート = new System.Windows.Forms.Label();
            this.Set_Pass_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Set_User_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Set_Host_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Set_DB_textBox = new System.Windows.Forms.TextBox();
            this.Close_Button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Open_file = new System.Windows.Forms.Button();
            this.file_show = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView_show = new System.Windows.Forms.DataGridView();
            this.DB_import = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Label();
            this.dataGridView_ng = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView_ok = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.all_count_show = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ok)).BeginInit();
            this.SuspendLayout();
            // 
            // DB_Info_Show
            // 
            this.DB_Info_Show.AutoSize = true;
            this.DB_Info_Show.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DB_Info_Show.Location = new System.Drawing.Point(179, 199);
            this.DB_Info_Show.Name = "DB_Info_Show";
            this.DB_Info_Show.Size = new System.Drawing.Size(149, 37);
            this.DB_Info_Show.TabIndex = 17;
            this.DB_Info_Show.Text = "           ";
            // 
            // DB_connect_Button
            // 
            this.DB_connect_Button.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DB_connect_Button.Location = new System.Drawing.Point(55, 199);
            this.DB_connect_Button.Name = "DB_connect_Button";
            this.DB_connect_Button.Size = new System.Drawing.Size(118, 35);
            this.DB_connect_Button.TabIndex = 4;
            this.DB_connect_Button.Text = "接続";
            this.DB_connect_Button.UseVisualStyleBackColor = true;
            this.DB_connect_Button.Click += new System.EventHandler(this.DB_Test_Button_Click);
            // 
            // 学生データインポート
            // 
            this.学生データインポート.AutoSize = true;
            this.学生データインポート.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.学生データインポート.Location = new System.Drawing.Point(12, 8);
            this.学生データインポート.Name = "学生データインポート";
            this.学生データインポート.Size = new System.Drawing.Size(318, 37);
            this.学生データインポート.TabIndex = 15;
            this.学生データインポート.Text = "学生データインポート";
            // 
            // Set_Pass_textBox
            // 
            this.Set_Pass_textBox.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Set_Pass_textBox.Location = new System.Drawing.Point(163, 137);
            this.Set_Pass_textBox.Name = "Set_Pass_textBox";
            this.Set_Pass_textBox.Size = new System.Drawing.Size(253, 26);
            this.Set_Pass_textBox.TabIndex = 2;
            this.Set_Pass_textBox.TextChanged += new System.EventHandler(this.Set_Pass_textBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(51, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "パスワード";
            // 
            // Set_User_textBox
            // 
            this.Set_User_textBox.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Set_User_textBox.Location = new System.Drawing.Point(163, 107);
            this.Set_User_textBox.Name = "Set_User_textBox";
            this.Set_User_textBox.Size = new System.Drawing.Size(253, 26);
            this.Set_User_textBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(51, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "ユーザー名";
            // 
            // Set_Host_textBox
            // 
            this.Set_Host_textBox.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Set_Host_textBox.Location = new System.Drawing.Point(163, 77);
            this.Set_Host_textBox.Name = "Set_Host_textBox";
            this.Set_Host_textBox.Size = new System.Drawing.Size(253, 26);
            this.Set_Host_textBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(51, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "接続先";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(51, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "DB名";
            // 
            // Set_DB_textBox
            // 
            this.Set_DB_textBox.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Set_DB_textBox.Location = new System.Drawing.Point(163, 167);
            this.Set_DB_textBox.Name = "Set_DB_textBox";
            this.Set_DB_textBox.Size = new System.Drawing.Size(253, 26);
            this.Set_DB_textBox.TabIndex = 3;
            // 
            // Close_Button
            // 
            this.Close_Button.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Close_Button.Location = new System.Drawing.Point(1108, 695);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(230, 32);
            this.Close_Button.TabIndex = 5;
            this.Close_Button.Text = "終了";
            this.Close_Button.UseVisualStyleBackColor = true;
            this.Close_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 519);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 19;
            // 
            // Open_file
            // 
            this.Open_file.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Open_file.Location = new System.Drawing.Point(442, 145);
            this.Open_file.Name = "Open_file";
            this.Open_file.Size = new System.Drawing.Size(166, 54);
            this.Open_file.TabIndex = 20;
            this.Open_file.Text = "開く";
            this.Open_file.UseVisualStyleBackColor = true;
            this.Open_file.Click += new System.EventHandler(this.Open_file_Click);
            // 
            // file_show
            // 
            this.file_show.AutoSize = true;
            this.file_show.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.file_show.Location = new System.Drawing.Point(439, 9);
            this.file_show.Name = "file_show";
            this.file_show.Size = new System.Drawing.Size(61, 15);
            this.file_show.TabIndex = 21;
            this.file_show.Text = "選択なし";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(762, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(576, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "学籍番号,氏名,科コード,クラス(半角数字),学年(半角数字)形式のCSVファイルを選択してください\r\n";
            // 
            // dataGridView_show
            // 
            this.dataGridView_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_show.Location = new System.Drawing.Point(658, 77);
            this.dataGridView_show.Name = "dataGridView_show";
            this.dataGridView_show.ReadOnly = true;
            this.dataGridView_show.RowTemplate.Height = 21;
            this.dataGridView_show.Size = new System.Drawing.Size(680, 156);
            this.dataGridView_show.TabIndex = 23;
            // 
            // DB_import
            // 
            this.DB_import.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DB_import.Location = new System.Drawing.Point(850, 695);
            this.DB_import.Name = "DB_import";
            this.DB_import.Size = new System.Drawing.Size(230, 32);
            this.DB_import.TabIndex = 24;
            this.DB_import.Text = "DB書込";
            this.DB_import.UseVisualStyleBackColor = true;
            this.DB_import.Click += new System.EventHandler(this.DB_import_Click);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(440, 33);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(41, 12);
            this.info.TabIndex = 25;
            this.info.Text = "待機中";
            // 
            // dataGridView_ng
            // 
            this.dataGridView_ng.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_ng.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ng.Location = new System.Drawing.Point(692, 266);
            this.dataGridView_ng.Name = "dataGridView_ng";
            this.dataGridView_ng.ReadOnly = true;
            this.dataGridView_ng.RowTemplate.Height = 21;
            this.dataGridView_ng.Size = new System.Drawing.Size(646, 423);
            this.dataGridView_ng.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(689, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 15);
            this.label7.TabIndex = 27;
            this.label7.Text = "登録失敗データ";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(655, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "登録データ";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(9, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 15);
            this.label9.TabIndex = 29;
            this.label9.Text = "登録成功データ";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // dataGridView_ok
            // 
            this.dataGridView_ok.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_ok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ok.Location = new System.Drawing.Point(12, 266);
            this.dataGridView_ok.Name = "dataGridView_ok";
            this.dataGridView_ok.ReadOnly = true;
            this.dataGridView_ok.RowTemplate.Height = 21;
            this.dataGridView_ok.Size = new System.Drawing.Size(646, 423);
            this.dataGridView_ok.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(412, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = "登録データ総数";
            // 
            // all_count_show
            // 
            this.all_count_show.AutoSize = true;
            this.all_count_show.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.all_count_show.Location = new System.Drawing.Point(519, 218);
            this.all_count_show.Name = "all_count_show";
            this.all_count_show.Size = new System.Drawing.Size(79, 15);
            this.all_count_show.TabIndex = 32;
            this.all_count_show.Text = "---------";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 695);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(806, 23);
            this.progressBar1.TabIndex = 33;
            // 
            // Gakuseki_import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.all_count_show);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView_ok);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView_ng);
            this.Controls.Add(this.info);
            this.Controls.Add(this.DB_import);
            this.Controls.Add(this.dataGridView_show);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.file_show);
            this.Controls.Add(this.Open_file);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Close_Button);
            this.Controls.Add(this.Set_DB_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DB_Info_Show);
            this.Controls.Add(this.DB_connect_Button);
            this.Controls.Add(this.学生データインポート);
            this.Controls.Add(this.Set_Pass_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Set_User_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Set_Host_textBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Gakuseki_import";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.DBSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DB_Info_Show;
        private System.Windows.Forms.Button DB_connect_Button;
        private System.Windows.Forms.Label 学生データインポート;
        private System.Windows.Forms.TextBox Set_Pass_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Set_User_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Set_Host_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Set_DB_textBox;
        private System.Windows.Forms.Button Close_Button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Open_file;
        private System.Windows.Forms.Label file_show;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView_show;
        private System.Windows.Forms.Button DB_import;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.DataGridView dataGridView_ng;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView_ok;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label all_count_show;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}