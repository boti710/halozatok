namespace Zh3_G0SJ6F
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            UserControl userControl1 = new UserControl1();

            panel1.Controls.Add(userControl1);

            userControl1.Dock = DockStyle.Fill;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bezárja az app-ot?", "Bezárás", MessageBoxButtons.YesNo);

            if (res == System.Windows.Forms.DialogResult.Yes)

            {

                Application.Exit();

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            UserControl userControl2 = new UserControl2();

            panel1.Controls.Add(userControl2);

            userControl2.Dock = DockStyle.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            UserControl userControl3 = new UserControl3();

            panel1.Controls.Add(userControl3);

            userControl3.Dock = DockStyle.Fill;
        }
    }
    
}