﻿using System.Windows.Forms;
using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;
using System.Media;
using static Questionnare.Form1;
using MySql.Data.MySqlClient;

namespace Questionnare
{




    public partial class Form1 : Form
    {
        public MediaPlayerExample media = new MediaPlayerExample();
        public int power_ups_count;
        public int games_played_count = 0;
        public int correct_answers_count;
        public int incorrect_answers_count;
        public int total_questions_count;
        public class MediaPlayerExample
        {
            private SoundPlayer soundPlayer;
            private bool isMusicPlaying = false;

            public bool IsMusicPlaying => isMusicPlaying;

            public void PlayMusic(string filePath)
            {
                try
                {
                    soundPlayer = new SoundPlayer(filePath);
                    soundPlayer.PlayLooping();  
                    isMusicPlaying = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error playing media: " + ex.Message);
                }
            }

            public void StopMusic()
            {
                if (soundPlayer != null && isMusicPlaying)
                {
                    soundPlayer.Stop();  
                    soundPlayer.Dispose();  
                    isMusicPlaying = false;
                }
            }

            public void ToggleMusic(string filePath)
            {
                if (isMusicPlaying)
                {
                    StopMusic();
                }
                else
                {
                    PlayMusic(filePath);
                }
            }
        }




        private MediaPlayerExample mediaPlayerExample;

        //Paths

        public string highscorePath = @"C:\Users\Tomi\OneDrive\Asztali gép\quiiz game\NewFolder1\highscore.txt";
        public Image rankingBronzePath = Image.FromFile(@"C:\Users\Tomi\OneDrive\Asztali gép\quiiz game\Ranking\Bronze.jpg");
        public Image rankingSilverPath = Image.FromFile(@"C:\Users\Tomi\OneDrive\Asztali gép\quiiz game\Ranking\Silver.jpg");
        public Image rankingGoldPath = Image.FromFile(@"C:\Users\Tomi\OneDrive\Asztali gép\quiiz game\Ranking\Gold.jpg");
        public Image rankingDiamondPath = Image.FromFile(@"C:\Users\Tomi\OneDrive\Asztali gép\quiiz game\Ranking\Diamond.jpg");
        public Image rankingChampionPath = Image.FromFile(@"C:\Users\Tomi\OneDrive\Asztali gép\quiiz game\Ranking\Champion.jpg");
        public string easyQuestionsPath = @"C:\Users\Tomi\OneDrive\Asztali gép\quiiz game\NewFolder1\easy.txt";
        public string normalQuestionsPath = @"C:\Users\Tomi\OneDrive\Asztali gép\quiiz game\NewFolder1\normal.txt";
        public string hardQuestionsPath = @"C:\Users\Tomi\OneDrive\Asztali gép\quiiz game\NewFolder1\hard.txt";

        public string music_path = @"C:\Users\Tomi\OneDrive\Asztali gép\quiiz game\Songs\undertale_dogsong (online-audio-converter.com).wav";
        public string music_on = @"C:\Users\Tomi\OneDrive\Asztali gép\quiiz game\Icon\sound.ico";
        public string music_off = @"C:\Users\Tomi\OneDrive\Asztali gép\quiiz game\Icon\mute.ico";

        public string stats_txt = @"C:\Users\Tomi\OneDrive\Asztali gép\quiiz game\NewFolder1\datas.txt";

        public string[] line_parts;
        public int highest_score;
        public int CurrentScore = 0;
        public int difficulty;
        public int Time = 15;
        public bool timer_run = false;
        private Thread countdownThread;
        bool GuessClicked = false;

        public string correct_answer;

        public string rank = "Bronze";

        public class Statistics
        {
            public int games_played { get; set; }
            public int power_ups_used { get; set; }

            public int correct_answers { get; set; }

            public int incorrect_answers { get; set; }

            public int total_questions { get; set; }

            public Statistics(int _games_played, int _power_ups_used, int _correct_answers, int _incorrect_answers, int _total_questions)
            {
                games_played = _games_played;
                power_ups_used = _power_ups_used;
                correct_answers = _correct_answers;
                incorrect_answers = _incorrect_answers;
                total_questions = _total_questions;
            }
        }
        public class Question
        {
            public string Questions { get; set; }
            public string Option1 { get; set; }
            public string Option2 { get; set; }
            public string Option3 { get; set; }
            public string Option4 { get; set; }
            public string Correct_answer { get; set; }

            public string Full_Correct_answer { get; set; }

            public Question(string _questions, string _option1, string _option2, string _option3, string _option4, string _correct_answer, string _full_correct_answer)
            {
                Questions = _questions.Trim();
                Option1 = _option1.Trim();
                Option2 = _option2.Trim();
                Option3 = _option3.Trim();
                Option4 = _option4.Trim();
                Correct_answer = _correct_answer.Trim();
                Full_Correct_answer = _full_correct_answer.Trim();
            }

        }

        private void Select_Language(object sender, EventArgs e)
        {
            string selectedLanguage = Language.SelectedItem.ToString();


            switch (selectedLanguage)
            {
                case "English":
                    ChangeLanguage("en-US");
                    Properties.Settings.Default.Language = "en-US";
                    break;

                case "French":
                    ChangeLanguage("fr-FR");
                    Properties.Settings.Default.Language = "fr-FR";
                    break;

                default:
                    break;
            }

            Properties.Settings.Default.Save();

            ApplyLocalization();
        }

        private List<Question> questions = new List<Question>();
        public List<Statistics> statistics = new List<Statistics>();




        public Form1()
        {
            InitializeComponent();
            mediaPlayerExample = new MediaPlayerExample();
            button1.Click += Button1_Click;
            GuessBtn.Click += GuessBtn_Click;
            Guess.KeyPress += Guess_KeyPress;
            this.Load += Form1_Load1;
            Language.SelectedIndexChanged += Select_Language;
            HalveBtn.Click += HalveBtn_Click;
            Skip.Click += Skip_Click;
            Audience.Click += Audience_Click;
            PlusTime.Click += PlusTime_Click;
            Music.Click += Music_Click;
            this.FormClosing += Form1_FormClosing;
        }

        
        private void Save_Stats()
        {

            using (StreamWriter writer = new StreamWriter(stats_txt, false))
            {
                writer.WriteLine($"{games_played_count};{power_ups_count};{correct_answers_count};{incorrect_answers_count};{total_questions_count}");
            }
        }
        private bool isFormClosing = false;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string connection_sql = "server=127.0.0.1;user=root;database=leaderboard;password=;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connection_sql))
                {
                    connection.Open(); 

                    string query = "INSERT INTO datas (score) VALUES (@score)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@score", CurrentScore); 

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {

                            string selectQuery = "SELECT * FROM datas ORDER BY score DESC";

                            using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection))
                            {
                                using (MySqlDataReader reader = selectCmd.ExecuteReader())
                                {
                                    
                                    while (reader.Read())
                                    {
                                        int score = reader.GetInt32("score");
                                        Console.WriteLine("Score: " + score);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data was inserted.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            if (isFormClosing)
            {
                return; 
            }

            isFormClosing = true;

            
            games_played_count += 1;
            Save_Stats();
            Stats();
            media.StopMusic();
        }


        private void Load_Stats()
        {
            if (File.Exists(stats_txt))
            {
                Console.WriteLine("Stats file exists. Reading file...");
                string[] lines = File.ReadAllLines(stats_txt);
                if (lines.Length > 0)
                {
                    string[] parts = lines[0].Split(';');
                    if (parts.Length == 5)
                    {
                        games_played_count = int.Parse(parts[0]);
                        power_ups_count = int.Parse(parts[1]);
                        correct_answers_count = int.Parse(parts[2]);
                        incorrect_answers_count = int.Parse(parts[3]);
                        total_questions_count = int.Parse(parts[4]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid format in the file.");
                    }
                }
                else
                {
                    Console.WriteLine("File is empty.");
                }
            }
            else
            {
                Console.WriteLine("Stats file does not exist. Initializing to default values.");
                games_played_count = 0;
                power_ups_count = 0;
            }
        }


        private void Stats()
        {
            if (File.Exists(stats_txt))
            {
                using (StreamReader r = new StreamReader(stats_txt))
                {
                    string line = r.ReadLine();

                    if (line != null)
                    {
                        string[] parts = line.Split(';');

                        if (parts.Length == 4)
                        {
                            Statistics stats = new Statistics(
                                int.Parse(parts[0]),
                                int.Parse(parts[1]),
                                int.Parse(parts[2]),
                                int.Parse(parts[3]),
                                int.Parse(parts[4])
                            );
                            statistics.Add(stats);
                        }
                    }
                }
            }

            foreach (var item in statistics)
            {
                Console.WriteLine($"{item.games_played},{item.power_ups_used},{item.correct_answers},{item.incorrect_answers},{item.total_questions}");
            }
        }

    private void Music_Click(object sender, EventArgs e)
        {
            mediaPlayerExample.ToggleMusic(music_path);

            Bitmap Icon1 = new Bitmap(music_on);
            Icon1 = new Bitmap(Icon1, new Size(16, 16));

            Bitmap Icon2 = new Bitmap(music_off);
            Icon2 = new Bitmap(Icon2, new Size(16, 16));


            if (mediaPlayerExample.IsMusicPlaying)
            {
                Music.Text = "On";
                Music.Image = Icon1;
            }
            else
            {
                Music.Text = "Off";
                Music.Image = Icon2;
            }

            Music.ImageAlign = ContentAlignment.MiddleRight;
            Music.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void PlusTime_Click(object sender, EventArgs e)
        {
            power_ups_count += 1;
            Time += 10;
            int remainingTime = Time;
            timer_run = false;
            countdownThread?.Abort();
            Timer_Reset();
            Save_Stats();

            timer_run = true;
            countdownThread = new Thread(Countdown);
            countdownThread.Start();

            PlusTime.Visible = false;
        }

        private void Audience_Click(object sender, EventArgs e)
        {
            power_ups_count += 1;
            int Percentage = 100;

            Random rnd = new Random();

            int[] percentages = new int[4];


            for (int i = 0; i < percentages.Length; i++)
            {
                percentages[i] = rnd.Next(0, Percentage);
            }

            MessageBox.Show($"Option1: {percentages[0]}%\n" +
                $"Option2: {percentages[1]}%\n" +
                $"Option3: {percentages[2]}%\n" +
                $"Option4: {percentages[3]}%\n");

            Audience.Visible = false;
            Save_Stats();
        }

        private void Skip_Click(object sender, EventArgs e)
        {
            power_ups_count += 1;
            Random_Query();
            Skip.Visible = false;
            Save_Stats();
        }

        private void HalveBtn_Click(object sender, EventArgs e)
        {
            power_ups_count += 1;
            Random random_option = new Random();

            TextBox[] options = new TextBox[4] { option1, option2, option3, option4 };

            List<int> cleared_options = new List<int>();

            int count = 0;

            while (count < 2)
            {
                int option_rnd = random_option.Next(0, options.Length);

                if (options[option_rnd].Text != correct_answer && !cleared_options.Contains(option_rnd))
                {
                    cleared_options.Add(option_rnd);
                    count++;
                }
            }

            foreach (var item in cleared_options)
            {
                options[item].Text = "";
            }

            HalveBtn.Visible = false;
            Save_Stats();
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

            string fullPath = highscorePath;

            Console.WriteLine(fullPath);

            if (File.Exists(fullPath))
            {
                using (StreamReader r = new StreamReader(fullPath))
                {
                    string line = r.ReadLine();
                    string scorePart = line.Split(':')[1].Trim();
                    highest_score = Convert.ToInt32(scorePart);
                    highscore_label.Text = $"{Resources.ResourceManager.GetString("High")}: {highest_score}";
                }
            }
            else
            {
                highest_score = 0;
                highscore_label.Text = $"{Resources.ResourceManager.GetString("High")}: {highest_score}";
            }
        }
        private void Form1_Load1(object sender, EventArgs e)
        {
            Load_Stats();

            mediaPlayerExample.PlayMusic(music_path);


            Bitmap soundIcon = new Bitmap(music_on);

            soundIcon = new Bitmap(soundIcon, new Size(16, 16));

            Music.Image = soundIcon;


            Music.ImageAlign = ContentAlignment.MiddleRight;
            Music.TextAlign = ContentAlignment.MiddleCenter;

            string culture = Properties.Settings.Default.Language ?? "en-US";
            ChangeLanguage(culture);
            ApplyLocalization();

            Language.Items.Add("English");
            Language.Items.Add("French");
            Language.SelectedItem = (culture == "fr-FR") ? "French" : "English";


            highscore_load();
            CurrentText.Text = $"{Resources.ResourceManager.GetString("Current")}: {CurrentScore}";

        }
        private void ChangeLanguage(string language)
        {
            CultureInfo culture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            ApplyLocalization();
        }

        private void ApplyLocalization()
        {
            diff.Items.Clear();
            button1.Text = Resources.ResourceManager.GetString("Start");
            GuessBtn.Text = Resources.ResourceManager.GetString("Guess");
            Skip.Text = Resources.ResourceManager.GetString("Skip");
            Audience.Text = Resources.ResourceManager.GetString("Audience");
            PlusTime.Text = Resources.ResourceManager.GetString("PlusTime");
            highscore_label.Text = $"{Resources.ResourceManager.GetString("High")}:{highest_score}";
            CurrentText.Text = $"{Resources.ResourceManager.GetString("Current")}:{CurrentScore}";
            lbrank.Text = $"{Resources.ResourceManager.GetString("Rank")}: {rank}";
            diff.Text = Resources.ResourceManager.GetString("diff");

            diff.Items.Add(Resources.ResourceManager.GetString("diff"));
            diff.Items.Add(Resources.ResourceManager.GetString("Easy"));
            diff.Items.Add(Resources.ResourceManager.GetString("Normal"));
            diff.Items.Add(Resources.ResourceManager.GetString("Hard"));

            diff.SelectedIndex = 0;
        }

        private void GuessBtn_Click(object sender, EventArgs e)
        {
    GuessClicked = true;
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

    if (currentQuery != null 
        && !string.IsNullOrEmpty(currentQuery.Correct_answer.Trim()) 
        && !string.IsNullOrEmpty(Guess.Text) 
        && string.Equals(currentQuery.Correct_answer.Trim(), Guess.Text.Trim(), StringComparison.OrdinalIgnoreCase))
    {
        // Correct Answer
        correct_answers_count += 1;
        Save_Stats();
        CurrentScore++;
        MessageBox.Show("Correct!");
        CurrentText.Text = $"{Resources.ResourceManager.GetString("Current")}: {CurrentScore}";
        Timer_Reset();
    }
    else
    {
        // Incorrect Answer
        incorrect_answers_count += 1;
        Save_Stats();
        MessageBox.Show("Incorrect!");
        CurrentScore = 0;
        CurrentText.Text = $"{Resources.ResourceManager.GetString("Current")}: {CurrentScore}";
        Timer_Reset();
    }


            if (CurrentScore > highest_score)
            {
                string fullPath = highscorePath;

                Console.WriteLine(fullPath);

                highest_score = CurrentScore;
                if (File.Exists(fullPath))
                {
                    using (StreamWriter w = new StreamWriter(fullPath))
                    {
                        w.WriteLine($"{Resources.ResourceManager.GetString("High")}: {highest_score}");
                    }
                }

                highscore_label.Text = $"{Resources.ResourceManager.GetString("High")}: {highest_score}";
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

                    if (line_parts.Length == 7)
                    {
                        Question question = new Question(
                            line_parts[0],
                            line_parts[1],
                            line_parts[2],
                            line_parts[3],
                            line_parts[4],
                            line_parts[5],
                            line_parts[6]
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
            total_questions_count += 1;

            if (GuessClicked == false)
            {
                CurrentScore = 0;
            }

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

                timer_run = true;
                countdownThread = new Thread(Countdown);
                countdownThread.Start();
            }


            Ranking.Image = rankingBronzePath;
            lbrank.Text = "Your rank: " + rank;

            Ranking.SizeMode = PictureBoxSizeMode.Zoom;
            Ranking.SizeMode = PictureBoxSizeMode.StretchImage;

            if (CurrentScore >= 1 && CurrentScore < 5)
            {
                rank = "Silver";
                Ranking.Image = rankingSilverPath;
            }
            else if (CurrentScore >= 5 && CurrentScore < 10)
            {
                rank = "Gold";
                Ranking.Image = rankingGoldPath;
            }
            else if (CurrentScore >= 10 && CurrentScore < 15)
            {
                rank = "Diamond";
                Ranking.Image = rankingDiamondPath;
            }
            else if (CurrentScore >= 15)
            {
                rank = "Champion";
                Ranking.Image = rankingChampionPath;
            }

            lbrank.Text = "Your rank: " + rank;

            if (diff.SelectedItem != null)
            {
                string selectedDifficulty = diff.SelectedItem.ToString().Trim();
                string filePath = "";

                string easy = Resources.ResourceManager.GetString("Easy");
                string normal = Resources.ResourceManager.GetString("Normal");
                string hard = Resources.ResourceManager.GetString("Hard");

                switch (selectedDifficulty)
                {
                    case var difficulty when difficulty == easy:
                        filePath = easyQuestionsPath;
                        diff.Enabled = false;
                        break;
                    case var difficulty when difficulty == normal:
                        filePath = normalQuestionsPath;
                        diff.Enabled = false;
                        break;
                    case var difficulty when difficulty == hard:
                        filePath = hardQuestionsPath;
                        diff.Enabled = false;
                        break;
                    default:
                        timer_run = false;
                        MessageBox.Show("Select Difficulty!");
                        Application.Exit();
                        Application.Restart();
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
            GuessClicked = false;
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

                correct_answer = random_query.Full_Correct_answer;



            }
            else
            {
                MessageBox.Show("No questions available!");
            }
        }

    }
}
