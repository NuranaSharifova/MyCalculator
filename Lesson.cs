using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Lesson : Form
    {
       bool pressedoperator=false;
        bool pressedequal = false;
        string tempcalc= "";
        string tempsign = "";
        bool minus = false;
        public Lesson()
        {
            InitializeComponent();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!pressedoperator )
            {
                textBox2.Text += (sender as Button).Text;
            }        
            else
            {

                textBox2.Text = (sender as Button).Text;
                pressedoperator = false;
            }
        }
        private void Calculate( string text) {

            double answer = 0;
            string[] arr = textBox1.Text.Split('+','-','/','*');
            if (arr[0]=="") { arr[0] = arr[1]; minus = true; }
            switch (text)
            {
                case "+":
                    if (!minus) answer = Double.Parse(arr[0]) + Double.Parse(textBox2.Text);
                    else { answer = Double.Parse(textBox2.Text) - Double.Parse(arr[0]); minus = false; };

                    break;
                case "-":
                    if (!minus) answer = Double.Parse(arr[0]) - Double.Parse(textBox2.Text);
                    else { answer = Double.Parse(arr[0]) + Double.Parse(textBox2.Text); minus = false; };
                    break;
                case "*":
                    answer = Double.Parse(arr[0]) * Double.Parse(textBox2.Text);
                    break;
                case "/":
                    answer = Double.Parse(arr[0]) / Double.Parse(textBox2.Text);
                    break;
                default:
                    break;
            }
            textBox2.Text = answer.ToString();
            if (!pressedequal)
            {
               
                textBox1.Text = answer.ToString() + tempsign;
            }
           
        }
     
        private void button13_Click(object sender, EventArgs e)
        {
           
            pressedoperator = true;
            if (textBox1.Text == ""|| pressedequal==true)
            {
                textBox1.Text = textBox2.Text + (sender as Button).Text;
                tempcalc = (sender as Button).Text;
                tempsign= (sender as Button).Text;
                pressedequal = false;
            }
            else {

                tempsign = (sender as Button).Text; 
                Calculate(tempcalc);
                tempcalc = (sender as Button).Text;
            }
           
        }

        private void button11_Click(object sender, EventArgs e)
        {

            string text = textBox2.Text;
            pressedequal = true;
            Calculate(tempcalc);
            textBox1.Text += text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text == "<-") 
            {

                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }
    }
}
