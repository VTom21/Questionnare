using System.Windows.Forms;
using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Threading;

namespace Questionnare
{
    public partial class Form1 : Form
    {
        public string[] line_parts;
        public int highest_score;
        public int CurrentScore = 0;
        public int difficulty;
        public int Time = 15;
        public bool timer_run = false;
        private Thread countdownThread;
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
            string File_HighScore = @"C:\Users\Kelemen Gábor\source\repos\Questionnare\NewFolder1\highscore.txt";


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

            diff.Items.Add("Easy");
            diff.Items.Add("Normal");
            diff.Items.Add("Hard");
            diff.SelectedIndex = 0;
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
                CurrentScore = 0;
                Timer_Reset();
            }


            if (CurrentScore > highest_score)
            {
                string File_HighScore = @"C:\Users\Kelemen Gábor\source\repos\Questionnare\NewFolder1\highscore.txt";

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

        private void Load_Query(string filePath)
        {
            questions.Clear(); 

                using (StreamReader r = new StreamReader(filePath))
                {
                    while (!r.EndOfStream)
                    {
                        string line = r.ReadLine();
                        string[] line_parts = line.Split('|').Select(p => p.Trim()).ToArray();

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
                        else
                        {
                            MessageBox.Show("Invalid question format!");
                            return; 
                        }
                    }
                }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (!timer_run) 
            {
                timer_run = true;
                countdownThread = new Thread(Countdown); 
                countdownThread.Start(); 
            }
            else
            {
                timer_run = false;
                countdownThread?.Abort(); 
                Timer_Reset();  
            }


            string rank = "Bronz";
            lbrank.Text = "Your rank: " + rank;

            if (CurrentScore >= 1 && CurrentScore < 5)
            {
                rank = "Silver";
            }
            else if (CurrentScore >= 5 && CurrentScore < 10)
            {
                rank = "Gold";
            }
            else if (CurrentScore >= 10 && CurrentScore < 15)
            {
                rank = "Diamond";
            }
            else if (CurrentScore >= 15)
            {
                rank = "Champion";
            }

            lbrank.Text = "Your rank: " + rank;

            if (diff.SelectedItem != null)
            {
                string selectedDifficulty = diff.SelectedItem.ToString().Trim();  
                string filePath = "";

                switch (selectedDifficulty)
                {
                    case "Easy":
                        filePath = @"C:\Users\Kelemen Gábor\source\repos\Questionnare\NewFolder1\easy.txt";
                        break;
                    case "Normal":
                        filePath = @"C:\Users\Kelemen Gábor\source\repos\Questionnare\NewFolder1\normal.txt";
                        break;
                    case "Hard":
                        filePath = @"C:\Users\Kelemen Gábor\source\repos\Questionnare\NewFolder1\hard.txt";
                        break;
                    default:
                        MessageBox.Show("Select a difficulty!");
                        return; 
                }
                if (File.Exists(filePath))
                {
                    Load_Query(filePath);  
                }
                else
                {
                    MessageBox.Show($"File not found at: {filePath}"); 
                }
            }
           

            Random_Query();
        }


        public void Countdown()
        {
            int remainingTime = Time;

            while (remainingTime >= 0 && timer_run)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() =>
                    {
                        countdown_label.Text = TimeSpan.FromSeconds(remainingTime).ToString(@"mm\:ss");
                    }));
                }

                remainingTime--;

                Thread.Sleep(1000);
            }

            if (remainingTime < 0 && timer_run)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Time's up!");
                        CurrentScore = 0;
                        CurrentText.Text = $"Current Score: {CurrentScore}";
                        Timer_Reset();   
                    }));
                }
            }
        }

        public void Timer_Reset()
        {
            countdown_label.Text = TimeSpan.FromSeconds(Time).ToString(@"mm\:ss");

            timer_run = false;  
        }


        private void Random_Query()
        {
            if (questions.Count > 0)
            {
                Random rand = new Random();
                int indexR = rand.Next(questions.Count);

                var random_query = questions[indexR];


                questionbar.Text = random_query.Questions;
                option1.Text = random_query.Option1;
                option2.Text = random_query.Option2;
                option3.Text = random_query.Option3;
                option4.Text = random_query.Option4;
            }
            else
            {
                MessageBox.Show("No questions available!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
