namespace DB_CREATE
{
    partial class DB_CREATE
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DB_CREATE));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Start_Button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Set_DB_textBox = new System.Windows.Forms.TextBox();
            this.Set_Pass_textBox = new System.Windows.Forms.TextBox();
            this.Set_User_textBox = new System.Windows.Forms.TextBox();
            this.Set_Host_textBox = new System.Windows.Forms.TextBox();
            this.Log_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Edit_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DB_CREATE.Properties.Resources.DB_SETUP_LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(498, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Start_Button
            // 
            this.Start_Button.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Start_Button.Location = new System.Drawing.Point(403, 251);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(98, 49);
            this.Start_Button.TabIndex = 1;
            this.Start_Button.Text = "DB構築";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(12, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "構築DB名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(12, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "パスワード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "ユーザー名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "接続先";
            // 
            // Set_DB_textBox
            // 
            this.Set_DB_textBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Set_DB_textBox.Location = new System.Drawing.Point(105, 221);
            this.Set_DB_textBox.Name = "Set_DB_textBox";
            this.Set_DB_textBox.Size = new System.Drawing.Size(183, 23);
            this.Set_DB_textBox.TabIndex = 26;
            // 
            // Set_Pass_textBox
            // 
            this.Set_Pass_textBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Set_Pass_textBox.Location = new System.Drawing.Point(105, 174);
            this.Set_Pass_textBox.Name = "Set_Pass_textBox";
            this.Set_Pass_textBox.Size = new System.Drawing.Size(183, 23);
            this.Set_Pass_textBox.TabIndex = 25;
            this.Set_Pass_textBox.TextChanged += new System.EventHandler(this.Set_Pass_textBox_TextChanged);
            // 
            // Set_User_textBox
            // 
            this.Set_User_textBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Set_User_textBox.Location = new System.Drawing.Point(105, 145);
            this.Set_User_textBox.Name = "Set_User_textBox";
            this.Set_User_textBox.Size = new System.Drawing.Size(183, 23);
            this.Set_User_textBox.TabIndex = 24;
            // 
            // Set_Host_textBox
            // 
            this.Set_Host_textBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Set_Host_textBox.Location = new System.Drawing.Point(105, 116);
            this.Set_Host_textBox.Name = "Set_Host_textBox";
            this.Set_Host_textBox.Size = new System.Drawing.Size(183, 23);
            this.Set_Host_textBox.TabIndex = 23;
            // 
            // Log_textBox
            // 
            this.Log_textBox.Location = new System.Drawing.Point(15, 320);
            this.Log_textBox.Multiline = true;
            this.Log_textBox.Name = "Log_textBox";
            this.Log_textBox.ReadOnly = true;
            this.Log_textBox.Size = new System.Drawing.Size(486, 164);
            this.Log_textBox.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(12, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "log";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(317, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 26);
            this.label6.TabIndex = 29;
            this.label6.Text = "DB作成・ユーザー追加\r\n科コード追加・権限編集を行います";
            // 
            // Edit_Button
            // 
            this.Edit_Button.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Edit_Button.Location = new System.Drawing.Point(253, 251);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(144, 49);
            this.Edit_Button.TabIndex = 30;
            this.Edit_Button.Text = "科コード編集";
            this.Edit_Button.UseVisualStyleBackColor = true;
            this.Edit_Button.Click += new System.EventHandler(this.Edit_Button_Click);
            // 
            // DB_CREATE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 496);
            this.Controls.Add(this.Edit_Button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Log_textBox);
            this.Controls.Add(this.Set_DB_textBox);
            this.Controls.Add(this.Set_Pass_textBox);
            this.Controls.Add(this.Set_User_textBox);
            this.Controls.Add(this.Set_Host_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Start_Button);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DB_CREATE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB構築";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Set_DB_textBox;
        private System.Windows.Forms.TextBox Set_Pass_textBox;
        private System.Windows.Forms.TextBox Set_User_textBox;
        private System.Windows.Forms.TextBox Set_Host_textBox;
        private System.Windows.Forms.TextBox Log_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Edit_Button;
    }
}

