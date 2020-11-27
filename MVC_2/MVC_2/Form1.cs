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
            if (e.KeyCode == Keys.Enter) //если нажат Enter
                model.setValue(Convert.ToInt32(textBox1.Text),1);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.setValue(Convert.ToInt32(textBox2.Text), 2);
        }
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            model.setValue(trackBar.Value, 0);
        }
        public void updateFromMVC(object sender, EventArgs e)
        {
            progressBar.Value = model.getValue();
            trackBar.Value = model.getValue();
            if(model.getCheck() == 0) //если значение получено из трэкбара
            {
                textBox1.Text = model.getValue().ToString();
                textBox2.Text = (model.getValue() + 1).ToString();
            }
            else if(model.getCheck() == 1) //если значение получено из текстбокс1
               textBox2.Text = (model.getValue() + 1).ToString();
            else //если значение получено из текстбокс2
                textBox1.Text = (model.getValue() - 1).ToString();
        }
        public class MVC
        {
            private int value;
            public int check;
            public System.EventHandler observers;
            public void setValue(int value, int check)
            {
                this.value = value;
                this.check = check;
                observers.Invoke(this, null);
            }
            public int getValue()
            {
                return value;
            }
            public int getCheck()
            {
                return check;
            }
        }
    }
}
