using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LP_4_Wegwerfprojekt
{
    public partial class Map : Form
    {
        Form1 start;
        public Map(Form1 start)
        {
            InitializeComponent();
            this.start = start;
            

        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            start.Show();
        }
    }
}
