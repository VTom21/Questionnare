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
