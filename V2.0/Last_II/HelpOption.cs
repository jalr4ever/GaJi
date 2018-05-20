using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Last_II
{
    public partial class HelpOption : Form
    {
        public HelpOption()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//使之位于屏幕中间            
            this.button1.BackColor = Color.FromArgb(0, 255, 255, 255);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new MainOption().Show();
            this.Hide();                     
        }

        private void HelpOption_Load(object sender, EventArgs e)
        {

        }

        private void HelpOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
