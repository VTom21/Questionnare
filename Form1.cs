﻿using System.Windows.Forms;
using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Text;

namespace Questionnare
{
    public partial class Form1 : Form
    {
        public string[] line_parts;
        public int highest_score;
        public int CurrentScore = 0;
        public class Question
        {
            public string Questions { get; set; }
            public string Option1 { get; set; }
            public string Option2 { get; set; }
            public string Option3 { get; set; }
            public string Option4 { get; set; }
            public string Correct_answer { get; set; }

            public Question(string _questions, string _option1, string _option2, string _option3, string _option4, string _correct_answer)
            {
                Questions = _questions.Trim();
                Option1 = _option1.Trim();
                Option2 = _option2.Trim();
                Option3 = _option3.Trim();
                Option4 = _option4.Trim();
                Correct_answer = _correct_answer.Trim();
            }

        }

        private List<Question> questions = new List<Question>();


        public Form1()
        {
            InitializeComponent();
            Load_File_Content();
            button1.Click += Button1_Click;
            GuessBtn.Click += GuessBtn_Click;
            Guess.KeyPress += Guess_KeyPress;
            this.Load += Form1_Load1;
        }

        private void Guess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Guess.Text.Length > 0 && e.KeyChar != (char)Keys.Back)
            {
                Guess.Clear();
            }
        }


        private void highscore_load()
        {
            string File_HighScore = @"highscore.txt";

            string directory = Application.StartupPath;
            string fullFilePath = Path.Combine(directory, File_HighScore);

            if (File.Exists(File_HighScore))
            {
                using (StreamReader r = new StreamReader(File_HighScore))
                {
                    string line = r.ReadLine();
                    string scorePart = line.Split(':')[1].Trim();
                    highest_score = Convert.ToInt32(scorePart);  
                    highscore_label.Text = $"High Score: {highest_score}";
                }
            }
            else
            {
                highest_score = 0;
                highscore_label.Text = $"High Score: {highest_score}";
            }
        }
        private void Form1_Load1(object sender, EventArgs e)
        {
            highscore_load();
            CurrentText.Text = $"Current Score: {CurrentScore}";
        }

        private void GuessBtn_Click(object sender, EventArgs e)
        {
            highscore_load();

            Question currentQuery = null;
            foreach (var item in questions)
            {
                if (item.Questions == questionbar.Text)
                {
                    currentQuery = item;
                    break;
                }
            }

            if (currentQuery.Correct_answer == Guess.Text.ToUpper())
            {
                CurrentScore++;
                MessageBox.Show("Correct!");
                CurrentText.Text = $"Current Score: {CurrentScore}";
                Guess.Text = "";
            }
            else
            {
                MessageBox.Show("Incorrect!");
                Guess.Text = "";
            }


            if (CurrentScore > highest_score)
            {
                string File_HighScore = @"highscore.txt";

                highest_score = CurrentScore;
                if (File.Exists(File_HighScore))
                {
                    using (StreamWriter w = new StreamWriter(File_HighScore))
                    {
                        w.WriteLine($"High Score: {highest_score}");
                    }
                }

                highscore_label.Text = $"High Score: {highest_score}";
                MessageBox.Show("New High Score!");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Random_Query();
        }

        private void Load_File_Content()
        {

         string filePath = @"torifizika.txt";
         string directory = Application.StartupPath;
         string fullFilePath = Path.Combine(directory, filePath);


            if (File.Exists(fullFilePath))
            {
                using (StreamReader r = new StreamReader(fullFilePath))
                {
                    while (!r.EndOfStream)
                    {
                        string line = r.ReadLine();
                        string[] line_parts = line.Split('|');

                        if (line_parts.Length == 6)
                        {
                            Question question = new Question(
                                line_parts[0],
                                line_parts[1],
                                line_parts[2],
                                line_parts[3],
                                line_parts[4],
                                line_parts[5]
                            );
                            questions.Add(question);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("File not found at: " + fullFilePath);
            }

        }



        private void Random_Query()
        {
            if (questions.Count > 0)
            {
                Random rand = new Random();
                int indexR = rand.Next(questions.Count);

                var random_query = questions[indexR];

                questionbar.Text = $"{random_query.Questions}";
                option1.Text = $"{random_query.Option1}";
                option2.Text = $"{random_query.Option2}";
                option3.Text = $"{random_query.Option3}";
                option4.Text = $"{random_query.Option4}";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
