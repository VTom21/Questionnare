namespace Questionnare
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.option1 = new System.Windows.Forms.TextBox();
            this.option2 = new System.Windows.Forms.TextBox();
            this.option4 = new System.Windows.Forms.TextBox();
            this.option3 = new System.Windows.Forms.TextBox();
            this.questionbar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.GuessBtn = new System.Windows.Forms.Button();
            this.Guess = new System.Windows.Forms.TextBox();
            this.label_highscore = new System.Windows.Forms.Label();
            this.HighScore = new System.Windows.Forms.Label();
            this.highscore_label = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // option1
            // 
            this.option1.Location = new System.Drawing.Point(12, 187);
            this.option1.Multiline = true;
            this.option1.Name = "option1";
            this.option1.Size = new System.Drawing.Size(309, 55);
            this.option1.TabIndex = 1;
            this.option1.BackColor = System.Drawing.Color.FromArgb(242, 85, 96);  // Soft Red background
            this.option1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.option1.ForeColor = System.Drawing.Color.White;
            this.option1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.option1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // option2
            // 
            this.option2.Location = new System.Drawing.Point(346, 187);
            this.option2.Multiline = true;
            this.option2.Name = "option2";
            this.option2.Size = new System.Drawing.Size(309, 55);
            this.option2.TabIndex = 2;
            this.option2.BackColor = System.Drawing.Color.FromArgb(242, 85, 96);
            this.option2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.option2.ForeColor = System.Drawing.Color.White;
            this.option2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.option2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // option3
            // 
            this.option3.Location = new System.Drawing.Point(12, 281);
            this.option3.Multiline = true;
            this.option3.Name = "option3";
            this.option3.Size = new System.Drawing.Size(309, 55);
            this.option3.TabIndex = 3;
            this.option3.BackColor = System.Drawing.Color.FromArgb(242, 85, 96);
            this.option3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.option3.ForeColor = System.Drawing.Color.White;
            this.option3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.option3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // option4
            // 
            this.option4.Location = new System.Drawing.Point(346, 281);
            this.option4.Multiline = true;
            this.option4.Name = "option4";
            this.option4.Size = new System.Drawing.Size(309, 55);
            this.option4.TabIndex = 4;
            this.option4.BackColor = System.Drawing.Color.FromArgb(242, 85, 96);
            this.option4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.option4.ForeColor = System.Drawing.Color.White;
            this.option4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.option4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // questionbar
            // 
            this.questionbar.Location = new System.Drawing.Point(12, 49);
            this.questionbar.Multiline = true;
            this.questionbar.Name = "questionbar";
            this.questionbar.Size = new System.Drawing.Size(640, 34);
            this.questionbar.TabIndex = 5;
            this.questionbar.BackColor = System.Drawing.Color.FromArgb(242, 85, 96);
            this.questionbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionbar.ForeColor = System.Drawing.Color.White;
            this.questionbar.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.questionbar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(242, 85, 96);
            this.button1.Location = new System.Drawing.Point(686, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(242, 85, 96);
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 102, 112);  // Lighter red for hover
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(204, 0, 0);  // Darker red for click

            // 
            // GuessBtn
            // 
            this.GuessBtn.BackColor = System.Drawing.Color.FromArgb(242, 85, 96);
            this.GuessBtn.Location = new System.Drawing.Point(102, 113);
            this.GuessBtn.Name = "GuessBtn";
            this.GuessBtn.Size = new System.Drawing.Size(75, 34);
            this.GuessBtn.TabIndex = 7;
            this.GuessBtn.Text = "Guess";
            this.GuessBtn.UseVisualStyleBackColor = false;
            this.GuessBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuessBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(242, 85, 96);
            this.GuessBtn.FlatAppearance.BorderSize = 2;
            this.GuessBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 102, 112);
            this.GuessBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(204, 0, 0);

            // 
            // Guess
            // 
            this.Guess.Location = new System.Drawing.Point(12, 113);
            this.Guess.Multiline = true;
            this.Guess.Name = "Guess";
            this.Guess.Size = new System.Drawing.Size(52, 34);
            this.Guess.TabIndex = 8;
            this.Guess.BackColor = System.Drawing.Color.FromArgb(242, 85, 96);
            this.Guess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Guess.ForeColor = System.Drawing.Color.White;
            this.Guess.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Guess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // label_highscore
            // 
            this.label_highscore.AutoSize = true;
            this.label_highscore.Location = new System.Drawing.Point(12, 9);
            this.label_highscore.Name = "label_highscore";
            this.label_highscore.Size = new System.Drawing.Size(85, 13);
            this.label_highscore.TabIndex = 9;
            this.label_highscore.Text = "High Score:";
            this.label_highscore.ForeColor = System.Drawing.Color.White;

            // 
            // HighScore
            // 
            this.HighScore.AutoSize = true;
            this.HighScore.Location = new System.Drawing.Point(102, 9);
            this.HighScore.Name = "HighScore";
            this.HighScore.Size = new System.Drawing.Size(0, 13);
            this.HighScore.TabIndex = 10;
            this.HighScore.ForeColor = System.Drawing.Color.White;

            // 
            // highscore_label
            // 
            this.highscore_label.AutoSize = true;
            this.highscore_label.Location = new System.Drawing.Point(12, 13);
            this.highscore_label.Name = "highscore_label";
            this.highscore_label.Size = new System.Drawing.Size(0, 13);
            this.highscore_label.TabIndex = 11;
            this.highscore_label.ForeColor = System.Drawing.Color.White;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.highscore_label);
            this.Controls.Add(this.HighScore);
            this.Controls.Add(this.label_highscore);
            this.Controls.Add(this.Guess);
            this.Controls.Add(this.GuessBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.questionbar);
            this.Controls.Add(this.option3);
            this.Controls.Add(this.option4);
            this.Controls.Add(this.option2);
            this.Controls.Add(this.option1);
            this.Name = "Form1";
            this.Text = "Quiz Application";
            this.BackColor = System.Drawing.Color.FromArgb(35, 35, 35);  // Dark background for the form
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
        private System.Windows.Forms.Button GuessBtn;
        private System.Windows.Forms.TextBox Guess;
        private System.Windows.Forms.Label label_highscore;
        private System.Windows.Forms.Label HighScore;
        private System.Windows.Forms.Label highscore_label;

    }
}
