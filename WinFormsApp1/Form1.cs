namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            PictureBox[] pictureboxes = new PictureBox[5] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };

            string[] rankings = new string[5] { "Bronze", "Silver", "Gold", "Diamond", "Champion" };

            Label[] labels = new Label[5] {label1,label2,label3,label4,label5};

            Label[] labels2 = new Label[5] { label6, label7, label8, label9, label10 };

            string[] texts = new string[5] {"0 - 1","1 - 5","5 - 10","10 - 15","above 15"};

            for (int i = 0; i < pictureboxes.Length; i++)
            {
                pictureboxes[i].SizeMode = PictureBoxSizeMode.Zoom;
                pictureboxes[i].SizeMode = PictureBoxSizeMode.StretchImage;

                pictureboxes[i].Image = Image.FromFile($@"C:\Users\Ny20VisegrádiT\Desktop\Questionnare\Ranking\{rankings[i]}.jpg");
                labels[i].Text = rankings[i];
                labels2[i].Text = texts[i];  
            }
        }
    }
}
