using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Threading;
using System.Globalization;
using System.Media;

namespace stats
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Home.Click += Home_Click;
            Call();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            RunExecutable(@"C:\Users\Ny20VisegrádiT\Source\Repos\Questionnare\Loading_Menu\bin\Debug\Loading_Menu.exe");
        }

        private void Call()
        {

            string filePath = @"C:\Users\Ny20VisegrádiT\Desktop\fxcbd\NewFolder1\datas.txt";
            Label[] labels = new Label[] { label1, label2, label3, label4, label5 };

            string[] strings = new string[] { "Games Played:", "Power Ups Used:", "Correct Answers:", "Incorrect Answers:", "Total Questions:" };

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parameters = line.Split(';');

                        if (parameters.Length == 5)
                        {
                            for (int i = 0; i < labels.Length; i++)
                            {

                                labels[i].Text = $"{strings[i]} {parameters[i]}";
                                labels[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(85)))), ((int)(((byte)(96)))));
                                labels[i].ForeColor = Color.GhostWhite;
                                labels[i].Padding = new Padding(5, 5, 10, 5);
                                labels[i].Width = 150;
                                labels[i].Height = 25;
                                labels[i].AutoSize = false;

                                labels[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;



                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid line format.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

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
