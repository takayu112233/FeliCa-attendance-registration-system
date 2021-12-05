namespace NFC_READ
{
    partial class DBSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBSetting));
            this.DB_Info_Show = new System.Windows.Forms.Label();
            this.DB_Test_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Set_Pass_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Set_User_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Set_Host_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Set_DB_textBox = new System.Windows.Forms.TextBox();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Set_ClientName_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // DB_Info_Show
            // 
            this.DB_Info_Show.AutoSize = true;
            this.DB_Info_Show.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DB_Info_Show.Location = new System.Drawing.Point(949, 526);
            this.DB_Info_Show.Name = "DB_Info_Show";
            this.DB_Info_Show.Size = new System.Drawing.Size(149, 37);
            this.DB_Info_Show.TabIndex = 17;
            this.DB_Info_Show.Text = "           ";
            // 
            // DB_Test_Button
            // 
            this.DB_Test_Button.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DB_Test_Button.Location = new System.Drawing.Point(730, 477);
            this.DB_Test_Button.Name = "DB_Test_Button";
            this.DB_Test_Button.Size = new System.Drawing.Size(213, 86);
            this.DB_Test_Button.TabIndex = 4;
            this.DB_Test_Button.Text = "テスト";
            this.DB_Test_Button.UseVisualStyleBackColor = true;
            this.DB_Test_Button.Click += new System.EventHandler(this.DB_Test_Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(23, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 37);
            this.label4.TabIndex = 15;
            this.label4.Text = "データベース情報";
            // 
            // Set_Pass_textBox
            // 
            this.Set_Pass_textBox.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Set_Pass_textBox.Location = new System.Drawing.Point(478, 236);
            this.Set_Pass_textBox.Name = "Set_Pass_textBox";
            this.Set_Pass_textBox.Size = new System.Drawing.Size(601, 34);
            this.Set_Pass_textBox.TabIndex = 2;
            this.Set_Pass_textBox.TextChanged += new System.EventHandler(this.Set_Pass_textBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(255, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 37);
            this.label3.TabIndex = 13;
            this.label3.Text = "パスワード";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Set_User_textBox
            // 
            this.Set_User_textBox.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Set_User_textBox.Location = new System.Drawing.Point(478, 169);
            this.Set_User_textBox.Name = "Set_User_textBox";
            this.Set_User_textBox.Size = new System.Drawing.Size(601, 34);
            this.Set_User_textBox.TabIndex = 1;
            this.Set_User_textBox.TextChanged += new System.EventHandler(this.Set_User_textBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(255, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 37);
            this.label2.TabIndex = 11;
            this.label2.Text = "ユーザー名";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Set_Host_textBox
            // 
            this.Set_Host_textBox.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Set_Host_textBox.Location = new System.Drawing.Point(478, 93);
            this.Set_Host_textBox.Name = "Set_Host_textBox";
            this.Set_Host_textBox.Size = new System.Drawing.Size(601, 34);
            this.Set_Host_textBox.TabIndex = 0;
            this.Set_Host_textBox.TextChanged += new System.EventHandler(this.Set_Host_textBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(255, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "接続先";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(255, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 37);
            this.label5.TabIndex = 18;
            this.label5.Text = "DB名";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Set_DB_textBox
            // 
            this.Set_DB_textBox.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Set_DB_textBox.Location = new System.Drawing.Point(478, 312);
            this.Set_DB_textBox.Name = "Set_DB_textBox";
            this.Set_DB_textBox.Size = new System.Drawing.Size(601, 34);
            this.Set_DB_textBox.TabIndex = 3;
            this.Set_DB_textBox.TextChanged += new System.EventHandler(this.Set_DB_textBox_TextChanged);
            // 
            // OK_Button
            // 
            this.OK_Button.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OK_Button.Location = new System.Drawing.Point(730, 624);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(349, 93);
            this.OK_Button.TabIndex = 6;
            this.OK_Button.Text = "保存・設定終了";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.Location = new System.Drawing.Point(270, 624);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(349, 93);
            this.Cancel_Button.TabIndex = 5;
            this.Cancel_Button.Text = "キャンセル";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 519);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "データベースのINSERTとSELECTを許可してください";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(255, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 37);
            this.label7.TabIndex = 20;
            this.label7.Text = "端末名";
            // 
            // Set_ClientName_comboBox
            // 
            this.Set_ClientName_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Set_ClientName_comboBox.Font = new System.Drawing.Font("MS UI Gothic", 20.25F);
            this.Set_ClientName_comboBox.FormattingEnabled = true;
            this.Set_ClientName_comboBox.Location = new System.Drawing.Point(478, 397);
            this.Set_ClientName_comboBox.MaxLength = 10;
            this.Set_ClientName_comboBox.Name = "Set_ClientName_comboBox";
            this.Set_ClientName_comboBox.Size = new System.Drawing.Size(601, 35);
            this.Set_ClientName_comboBox.TabIndex = 22;
            this.Set_ClientName_comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DBSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.Set_ClientName_comboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.Set_DB_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DB_Info_Show);
            this.Controls.Add(this.DB_Test_Button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Set_Pass_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Set_User_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Set_Host_textBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DBSetting";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.DBSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DB_Info_Show;
        private System.Windows.Forms.Button DB_Test_Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Set_Pass_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Set_User_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Set_Host_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Set_DB_textBox;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Set_ClientName_comboBox;
    }
}