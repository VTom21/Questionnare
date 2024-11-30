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

namespace Loading_Menu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start.Click += Start_Click;
            btnranking.Click += Btnranking_Click;
            Quit.Click += Quit_Click;
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btnranking_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The ranks: \n" +
                "0 Bronz \n" +
                "1-4 Silver \n" +
                "5-9 Gold \n" +
                "10-14 Diamond \n" +
                "15 or higher Champion");
        }

        private void Start_Click(object sender, EventArgs e)
        {
            RunExecutable();
        }

        private void RunExecutable()
        {
            string path = @"C:\Users\Tomi\OneDrive\Asztali gép\Questionnare\bin\Debug\Questionnare.exe";

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
