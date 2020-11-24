using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToInt32(textBox2.Text) - 1).ToString();
            progressBar.Value = Convert.ToInt32(textBox2.Text);
            trackBar.Value = Convert.ToInt32(textBox2.Text);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox2.Text = (Convert.ToInt32(textBox1.Text) + 1).ToString();
                progressBar.Value = Convert.ToInt32(textBox1.Text);
                trackBar.Value = Convert.ToInt32(textBox1.Text);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Text = (Convert.ToInt32(textBox2.Text) - 1).ToString();
                progressBar.Value = Convert.ToInt32(textBox2.Text);
                trackBar.Value = Convert.ToInt32(textBox2.Text);
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar.Value.ToString();
            textBox2.Text = (Convert.ToInt32(textBox1.Text) + 1).ToString();
            progressBar.Value = trackBar.Value;
        }
    }
}
