namespace LexicalAnalyzer
{
    partial class Form1
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
            this.path = new System.Windows.Forms.TextBox();
            this.find = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.analyzed = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(12, 11);
            this.path.Multiline = true;
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(339, 21);
            this.path.TabIndex = 0;
            // 
            // find
            // 
            this.find.Location = new System.Drawing.Point(357, 11);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(78, 23);
            this.find.TabIndex = 1;
            this.find.Text = "Find";
            this.find.UseVisualStyleBackColor = true;
            this.find.Click += new System.EventHandler(this.find_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 39);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(423, 290);
            this.textBox.TabIndex = 2;
            this.textBox.Text = "";
            // 
            // analyzed
            // 
            this.analyzed.Location = new System.Drawing.Point(441, 10);
            this.analyzed.Name = "analyzed";
            this.analyzed.Size = new System.Drawing.Size(222, 23);
            this.analyzed.TabIndex = 4;
            this.analyzed.Text = "Analyzed";
            this.analyzed.UseVisualStyleBackColor = true;
            this.analyzed.Click += new System.EventHandler(this.analyzed_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(441, 39);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(222, 290);
            this.outputBox.TabIndex = 5;
            this.outputBox.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 340);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.analyzed);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.find);
            this.Controls.Add(this.path);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Button find;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.Button analyzed;
        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

