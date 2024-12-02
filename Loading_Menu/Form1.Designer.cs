
namespace Loading_Menu
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
            this.Start = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.btnranking = new System.Windows.Forms.Button();
            this.Language = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(85)))), ((int)(((byte)(96)))));
            this.Start.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(85)))), ((int)(((byte)(96)))));
            this.Start.FlatAppearance.BorderSize = 2;
            this.Start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.ForeColor = System.Drawing.Color.GhostWhite;
            this.Start.Location = new System.Drawing.Point(238, 104);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(289, 47);
            this.Start.TabIndex = 7;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            // 
            // Quit
            // 
            this.Quit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(85)))), ((int)(((byte)(96)))));
            this.Quit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(85)))), ((int)(((byte)(96)))));
            this.Quit.FlatAppearance.BorderSize = 2;
            this.Quit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Quit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit.ForeColor = System.Drawing.Color.GhostWhite;
            this.Quit.Location = new System.Drawing.Point(238, 253);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(289, 46);
            this.Quit.TabIndex = 7;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = false;
            // 
            // btnranking
            // 
            this.btnranking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(85)))), ((int)(((byte)(96)))));
            this.btnranking.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(85)))), ((int)(((byte)(96)))));
            this.btnranking.FlatAppearance.BorderSize = 2;
            this.btnranking.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnranking.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(112)))));
            this.btnranking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnranking.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnranking.Location = new System.Drawing.Point(238, 179);
            this.btnranking.Name = "btnranking";
            this.btnranking.Size = new System.Drawing.Size(289, 47);
            this.btnranking.TabIndex = 7;
            this.btnranking.Text = "Ranking";
            this.btnranking.UseVisualStyleBackColor = false;
            // 
            // Language
            // 
            this.Language.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(85)))), ((int)(((byte)(96)))));
            this.Language.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Language.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Language.ForeColor = System.Drawing.Color.GhostWhite;
            this.Language.FormattingEnabled = true;
            this.Language.Location = new System.Drawing.Point(657, 392);
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(121, 23);
            this.Language.TabIndex = 15;
            this.Language.Text = "Select Language!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(67)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Language);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.btnranking);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Button btnranking;
        private System.Windows.Forms.ComboBox Language;
    }
}

