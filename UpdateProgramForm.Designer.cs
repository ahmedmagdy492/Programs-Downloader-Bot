namespace Programs_Downloader_Bot
{
    partial class UpdateProgramForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.txtProgName = new System.Windows.Forms.TextBox();
            this.btnUpdateProgram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 34);
            this.label2.TabIndex = 9;
            this.label2.Text = "Link";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 34);
            this.label1.TabIndex = 8;
            this.label1.Text = "Program Name";
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(176, 194);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(304, 41);
            this.txtLink.TabIndex = 6;
            // 
            // txtProgName
            // 
            this.txtProgName.Location = new System.Drawing.Point(176, 99);
            this.txtProgName.Name = "txtProgName";
            this.txtProgName.Size = new System.Drawing.Size(304, 41);
            this.txtProgName.TabIndex = 5;
            // 
            // btnUpdateProgram
            // 
            this.btnUpdateProgram.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateProgram.Location = new System.Drawing.Point(176, 269);
            this.btnUpdateProgram.Name = "btnUpdateProgram";
            this.btnUpdateProgram.Size = new System.Drawing.Size(304, 57);
            this.btnUpdateProgram.TabIndex = 10;
            this.btnUpdateProgram.Text = "Update Program";
            this.btnUpdateProgram.UseVisualStyleBackColor = true;
            this.btnUpdateProgram.Click += new System.EventHandler(this.btnUpdateProgram_Click_1);
            // 
            // UpdateProgramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(657, 384);
            this.Controls.Add(this.btnUpdateProgram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.txtProgName);
            this.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateProgramForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Program";
            this.Load += new System.EventHandler(this.UpdateProgramForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.TextBox txtProgName;
        private System.Windows.Forms.Button btnUpdateProgram;
    }
}