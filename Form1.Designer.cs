namespace Questionnare
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
            this.option1 = new System.Windows.Forms.TextBox();
            this.option2 = new System.Windows.Forms.TextBox();
            this.option4 = new System.Windows.Forms.TextBox();
            this.option3 = new System.Windows.Forms.TextBox();
            this.questionbar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // option1
            // 
            this.option1.Location = new System.Drawing.Point(12, 187);
            this.option1.Multiline = true;
            this.option1.Name = "option1";
            this.option1.Size = new System.Drawing.Size(309, 55);
            this.option1.TabIndex = 1;
            // 
            // option2
            // 
            this.option2.Location = new System.Drawing.Point(346, 187);
            this.option2.Multiline = true;
            this.option2.Name = "option2";
            this.option2.Size = new System.Drawing.Size(309, 55);
            this.option2.TabIndex = 2;
            // 
            // option4
            // 
            this.option4.Location = new System.Drawing.Point(346, 281);
            this.option4.Multiline = true;
            this.option4.Name = "option4";
            this.option4.Size = new System.Drawing.Size(309, 55);
            this.option4.TabIndex = 3;
            // 
            // option3
            // 
            this.option3.Location = new System.Drawing.Point(12, 281);
            this.option3.Multiline = true;
            this.option3.Name = "option3";
            this.option3.Size = new System.Drawing.Size(309, 55);
            this.option3.TabIndex = 4;
            // 
            // questionbar
            // 
            this.questionbar.Location = new System.Drawing.Point(15, 106);
            this.questionbar.Multiline = true;
            this.questionbar.Name = "questionbar";
            this.questionbar.Size = new System.Drawing.Size(640, 34);
            this.questionbar.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(688, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.questionbar);
            this.Controls.Add(this.option3);
            this.Controls.Add(this.option4);
            this.Controls.Add(this.option2);
            this.Controls.Add(this.option1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox option1;
        private System.Windows.Forms.TextBox option2;
        private System.Windows.Forms.TextBox option4;
        private System.Windows.Forms.TextBox option3;
        private System.Windows.Forms.TextBox questionbar;
        private System.Windows.Forms.Button button1;
    }
}

