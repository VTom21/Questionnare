using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Globalization;
using System.Threading;

namespace Loading_Menu
{
    public partial class Form1 : Form
    {

        //Paths

        public string RankingsPath = @"C:\Users\Ny20VisegrádiT\Source\Repos\Questionnare\WinFormsApp1\bin\Debug\net8.0-windows\WinFormsApp1.exe";
        public string QuestionnairePath = @"C:\Users\Ny20VisegrádiT\Source\Repos\Questionnare\bin\Debug\Questionnare.exe";
        public string LeaderboardPath = "";

        public Form1()
        {
            InitializeComponent();
            Start.Click += Start_Click;
            btnranking.Click += Btnranking_Click;
            Quit.Click += Quit_Click;
            this.Load += Form1_Load1;
            Language.SelectedIndexChanged += Select_Language;
            leaderboard.Click += Leaderboard_Click;
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
                    Application.Exit();
                    Process.Start(path);
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
