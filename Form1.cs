using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Questionnare
{
    public partial class Form1 : Form
    {
        public class Question
        {
            public string questions { get; set; }
            public string option1 { get; set; }
            public string option2 { get; set; }
            public string option3 { get; set; }
            public string option4 { get; set; }
            public string correct_answer { get; set; }

            public Question(string _questions, string _option1, string _option2, string _option3, string _option4, string _correct_answer)
            {
                questions = _questions;        
                option1 = _option1;
                option2 = _option2;
                option3 = _option3;
                option4 = _option4;
                correct_answer = _correct_answer;
            }
        }

        public Form1()
        {
            InitializeComponent();


            Question question = new Question("Mikor ért véget az első világháború?", "1914", "1918", "1923", "1905", "1918");

            using (StreamReader r = new StreamReader("C:\\Users\\Ny20Kelemeng\\Source\\Repos\\Questionnare\\forras\\torifizika.txt"))
            {
                do
                {
                    string line = r.ReadLine();

                    string[]

                }
                while (!r.EndOfStream);
            };

            questionbar.Text = question.questions;
        }
    }
}
