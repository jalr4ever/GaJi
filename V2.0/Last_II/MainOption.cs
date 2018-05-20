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
    public partial class MainOption : Form
    {
        public MainOption()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            new StartOption().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ScoreOption().Show();
            this.Hide();
        }

        private void MainOption_Load(object sender, EventArgs e)
        {  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new HelpOption().Show();
            this.Hide();
        }

        private void MainOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
