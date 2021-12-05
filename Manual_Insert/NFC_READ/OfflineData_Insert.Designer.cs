namespace Manual_Insert
{
    partial class OfflineData_Insert
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfflineData_Insert));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_show = new System.Windows.Forms.DataGridView();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.count_show = new System.Windows.Forms.Label();
            this.Send_button = new System.Windows.Forms.Button();
            this.CSV_button = new System.Windows.Forms.Button();
            this.Log_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "未送信データ確認画面";
            // 
            // dataGridView_show
            // 
            this.dataGridView_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_show.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_show.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_show.Location = new System.Drawing.Point(16, 84);
            this.dataGridView_show.Name = "dataGridView_show";
            this.dataGridView_show.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_show.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_show.RowTemplate.Height = 21;
            this.dataGridView_show.Size = new System.Drawing.Size(651, 602);
            this.dataGridView_show.TabIndex = 26;
            // 
            // Cancel_button
            // 
            this.Cancel_button.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_button.Location = new System.Drawing.Point(1207, 669);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(131, 48);
            this.Cancel_button.TabIndex = 27;
            this.Cancel_button.Text = "終了";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // count_show
            // 
            this.count_show.AutoSize = true;
            this.count_show.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.count_show.Location = new System.Drawing.Point(597, 701);
            this.count_show.Name = "count_show";
            this.count_show.Size = new System.Drawing.Size(70, 24);
            this.count_show.TabIndex = 29;
            this.count_show.Text = "-----";
            // 
            // Send_button
            // 
            this.Send_button.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Send_button.Location = new System.Drawing.Point(1070, 669);
            this.Send_button.Name = "Send_button";
            this.Send_button.Size = new System.Drawing.Size(131, 48);
            this.Send_button.TabIndex = 30;
            this.Send_button.Text = "一括送信";
            this.Send_button.UseVisualStyleBackColor = true;
            this.Send_button.Click += new System.EventHandler(this.Send_button_Click);
            // 
            // CSV_button
            // 
            this.CSV_button.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CSV_button.Location = new System.Drawing.Point(16, 692);
            this.CSV_button.Name = "CSV_button";
            this.CSV_button.Size = new System.Drawing.Size(131, 33);
            this.CSV_button.TabIndex = 33;
            this.CSV_button.Text = "CSV書出し";
            this.CSV_button.UseVisualStyleBackColor = true;
            this.CSV_button.Click += new System.EventHandler(this.CSV_button_Click);
            // 
            // Log_textBox
            // 
            this.Log_textBox.Location = new System.Drawing.Point(673, 84);
            this.Log_textBox.Multiline = true;
            this.Log_textBox.Name = "Log_textBox";
            this.Log_textBox.ReadOnly = true;
            this.Log_textBox.Size = new System.Drawing.Size(665, 579);
            this.Log_textBox.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(669, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 24);
            this.label3.TabIndex = 38;
            this.label3.Text = "ログ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 39;
            this.label2.Text = "データ";
            // 
            // OfflineData_Insert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Log_textBox);
            this.Controls.Add(this.CSV_button);
            this.Controls.Add(this.Send_button);
            this.Controls.Add(this.count_show);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.dataGridView_show);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OfflineData_Insert";
            this.Text = "データ送信";
            this.Load += new System.EventHandler(this.OfflineData_Insert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_show;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Label count_show;
        private System.Windows.Forms.Button Send_button;
        private System.Windows.Forms.Button CSV_button;
        private System.Windows.Forms.TextBox Log_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}