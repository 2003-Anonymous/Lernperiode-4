namespace LP_4_Wegwerfprojekt
{
    public partial class Form1 : Form
    {
        Form1 parent;
        public Form1()
        {
            InitializeComponent();

            this.parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Map(this).Show();            
            this.Hide();
        }
    }
}
