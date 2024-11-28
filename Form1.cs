using System.Windows.Forms;
using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Text;

namespace Questionnare
{
    public partial class Form1 : Form
    {
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
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Random_Query();
        }

        private void Load_File_Content()
        {
            string filePath = "C:\\Users\\Ny20VisegrádiT\\Desktop\\Questionnare\\forras\\torifizika.txt";
            if (File.Exists(filePath))
            {
                using (StreamReader r = new StreamReader(filePath))
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
                MessageBox.Show("File not found.");
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
            }
        }



    }
}
