using System.Windows.Forms.Design;

namespace LP_4
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();


        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            new Form2(this).Show();
            this.Hide();
        }

        private void start_btn_Click_1(object sender, EventArgs e)
        {
            new Form2(this).Show();
            this.Hide();
        }
    }
}
