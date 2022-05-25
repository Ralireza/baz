using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        int number1 = 0;
        int number2 = 0;
        int countOpt = 0;
        string opt = "";
        bool isFirstNumber = true;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;

            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    Button btn = (Button)c;
                    btn.TabStop = false;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                }

            }





        }


        void setToNumber(string text)
        {
            if (isFirstNumber)
            {
                number1 = Convert.ToInt32(display.Text);

            }
            else
            {
                number2 = Convert.ToInt32(display.Text);

            }
        }

        int calc()
        {
            //MessageBox.Show(number1 + "  " + number2 + "  " + opt);

            int result = 1;
            switch (opt)
            {
                case "plus":
                    result = number1 + number2;
                    break;
                case "minus":
                    result = number1 - number2;
                    break;
                case "tagh":
                    result = number1 / number2;
                    break;
                case "zarb":
                    result = number1 * number2;
                    break;
            }
            return result;
        }
        private void handleNumberClick(object sender, EventArgs e)
        {
            Button number = (Button)sender;
            display.Text += number.Text;
            setToNumber(display.Text);
            this.ActiveControl = display;

        }

        private void backspace_Click(object sender, EventArgs e)
        {
            if (display.Text.Length != 0)
            {
                string currnetText = display.Text;
                currnetText = currnetText.Remove(currnetText.Length - 1);
                display.Text = currnetText;
            }

            this.ActiveControl = display;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            display.Text = "0";
            isFirstNumber = true;

        }

        private void handleOpt(object sender, EventArgs e)
        {
            countOpt++;

            isFirstNumber = false;
            Button optButton = (Button)sender;

            opt = optButton.Tag + "";
            display.Text = "";
            this.ActiveControl = display;
            if (countOpt % 2 == 0)
            {
                int result = calc();
                display.Text = result + "";
                number1 = result;
            }


        }

        private void mosavi_Click(object sender, EventArgs e)
        {
            int result = calc();
            display.Text = result + "";

            isFirstNumber = true;

        }



        private void keydown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad1)
            {
                display.Text += "1";
                setToNumber(display.Text);


            }
            else if (e.KeyCode == Keys.NumPad2)
            {
                display.Text += "2";
                setToNumber(display.Text);


            }
            else if (e.KeyCode == Keys.Return)
            {
                mosavi.PerformClick();
            }
            else if (e.KeyCode == Keys.Add)
            {
                opt = "plus";
                isFirstNumber = false;
                display.Text = "";


            }
        }

        private void changeSign(object sender, EventArgs e)
        {
            display.Text = (Convert.ToInt32(display.Text) * -1) + "";
        }
    }
}
