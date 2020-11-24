using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_2
{
    public partial class Form1 : Form
    {
        MVC model;
        public Form1()
        {
            InitializeComponent();
            model = new MVC();
            model.observers += new System.EventHandler(this.updateFromMVC);
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setValue(textBox1, textBox2);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setValue(textBox2, textBox1);
        }
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            model.setValue(trackBar, textBox1, textBox2);
        }
        public void updateFromMVC(object sender, EventArgs e)
        {
            progressBar.Value = model.getValue();
            trackBar.Value = model.getValue();
        }
        public class MVC
        {
            private int value;
            public System.EventHandler observers;
            public void setValue(TextBox T1, TextBox T2)
            {
                value = Convert.ToInt32(T1.Text);
                if (T1.Name == "textBox1")
                    T2.Text = (value + 1).ToString();
                else
                    T2.Text = (value - 1).ToString();
                observers.Invoke(this, null);
            }
            public void setValue(TrackBar tr, TextBox T1, TextBox T2)
            {
                value = tr.Value;
                T1.Text = value.ToString();
                T2.Text = (value + 1).ToString();
                observers.Invoke(this, null);
            }
            public int getValue()
            {
                return value;
            }
        }
    }
}
