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
        }

        private void Home_Click(object sender, EventArgs e)
        {
            RunExecutable(@"C:\Users\Ny20VisegrádiT\Source\Repos\Questionnare\Loading_Menu\bin\Debug\Loading_Menu.exe");
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
