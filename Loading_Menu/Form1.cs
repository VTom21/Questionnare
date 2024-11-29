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

            string path = @"C:\Users\Ny20VisegrádiT\source\repos\Questionnare\bin\Debug\Questionnare.exe";


            Console.WriteLine(path);

            try
            {
                Process.Start(path);

                Application.Exit(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error launching the executable: " + ex.Message);
            }
        }
    }
}
