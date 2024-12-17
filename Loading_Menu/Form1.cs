using System;
using System.Media;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;  

namespace Loading_Menu
{
    public partial class Form1 : Form
    {
        //Paths

        public string Song_Path = @"C:\Users\Ny20VisegrádiT\Desktop\Quiz\Songs\undertale_dogsong (online-audio-converter.com).wav";
        public string music_on = @"C:\Users\Ny20VisegrádiT\Desktop\Quiz\Icon\sound.ico";
        public string music_off= @"C:\Users\Ny20VisegrádiT\Desktop\Quiz\Icon\mute.ico";

        public string RankingsPath = @"C:\Users\Ny20VisegrádiT\Desktop\Quiz\WinFormsApp1\bin\Debug\net8.0-windows\WinFormsApp1.exe";
        public string QuestionnairePath = @"C:\Users\Ny20VisegrádiT\Desktop\Quiz\bin\Debug\Questionnare.exe";


        public class MediaPlayerExample
        {
            private SoundPlayer soundPlayer;
            private bool isMusicPlaying = true;

            public bool IsMusicPlaying => isMusicPlaying;

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

            private void StopMusic()
            {
                soundPlayer?.Stop();
                isMusicPlaying = false;
            }
        }



        private MediaPlayerExample mediaPlayerExample;

        public Form1()
        {
            InitializeComponent();
            Start.Click += Start_Click;
            btnranking.Click += Btnranking_Click;
            Quit.Click += Quit_Click;
            this.Load += Form1_Load1;
            Language.SelectedIndexChanged += Select_Language;
            mediaPlayerExample = new MediaPlayerExample();
            button1.Click += Button1_Click;
            this.Load += Form1_Load;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            mediaPlayerExample.PlayMusic(Song_Path);


            Bitmap soundIcon = new Bitmap(music_on);

            soundIcon = new Bitmap(soundIcon, new Size(16, 16));  

            button1.Image = soundIcon;


            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            mediaPlayerExample.ToggleMusic(Song_Path);

            Bitmap Icon1 = new Bitmap(music_on);  
            Icon1 = new Bitmap(Icon1, new Size(16, 16));

            Bitmap Icon2 = new Bitmap(music_off);
            Icon2 = new Bitmap(Icon2, new Size(16, 16));


            if (mediaPlayerExample.IsMusicPlaying)
            {
                button1.Text = "On";
                button1.Image = Icon1; 
            }
            else
            {
                button1.Text = "Off"; 
                button1.Image = Icon2; 
            }

            button1.ImageAlign = ContentAlignment.MiddleRight;  
            button1.TextAlign = ContentAlignment.MiddleCenter; 
        }


        private void Leaderboard_Click(object sender, EventArgs e)
        {
            RunExecutable(RankingsPath);
        }

        private void Form1_Load1(object sender, EventArgs e)
        {
            string culture = Properties.Settings.Default.Language ?? "en-US";
            ChangeLanguage(culture);
            ApplyLocalization();

            Language.Items.Add("English");
            Language.Items.Add("French");
            Language.SelectedItem = (culture == "fr-FR") ? "French" : "English";
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChangeLanguage(string cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
        }

        private void ApplyLocalization()
        {
            Start.Text = Resources.ResourceManager.GetString("Start");
            btnranking.Text = Resources.ResourceManager.GetString("btnranking");
            Quit.Text = Resources.ResourceManager.GetString("Quit");
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

        private void Btnranking_Click(object sender, EventArgs e)
        {
            RunExecutable(RankingsPath);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            RunExecutable(QuestionnairePath);
        }

        private void RunExecutable(string redirect_path)
        {
            string path = redirect_path;

            try
            {
                if (File.Exists(path))
                {
                    Process.Start(path); 
                    Application.Exit();   
                }
                else
                {
                    MessageBox.Show("Executable not found at path: " + path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error launching the executable: " + ex.Message);
            }
        }
    }
}
