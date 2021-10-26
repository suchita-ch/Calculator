using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class Calculator : Form
    {
        List<string> equation = new List<string>();

        string tempnumber;
        public Calculator()
        {
            InitializeComponent();
        }

        private void addSign(string sign)
        {
            if (tempnumber != string.Empty)
            {
                equation.Add(tempnumber);
                equation.Add(sign);
                tempnumber = "";
                textResult.Text += sign;
            }
        }
        private void addNumber(string number)
        {
            tempnumber += number;
            if(textResult.Text=="0")
                textResult.Text = number;
            else
                textResult.Text += number;
        }
        private void btnOne_Click(object sender, EventArgs e)
        {
            addNumber("1");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            addNumber("2");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            addNumber("3");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (textResult.Text.Trim() == string.Empty || textResult.Text.Trim() == "0")
                MessageBox.Show("Please enter valid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                addSign("+");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (textResult.Text.Trim() == string.Empty || textResult.Text.Trim() == "0")
                MessageBox.Show("Please enter valid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                addSign("/");
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
                if (textResult.Text.Trim() == string.Empty || textResult.Text.Trim() == "0")
                MessageBox.Show("Please enter valid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (tempnumber != string.Empty)
                    equation.Add(tempnumber);
                int index = 1;
                decimal result = 0;
                string sign = "+";

                foreach (string part in equation)
                {
                    if (index % 2 != 0)
                    {
                        if (sign == "+")
                            result = result + Convert.ToDecimal(part);
                        else if (sign == "/")
                            result = result / Convert.ToDecimal(part);
                        else if(sign=="*")
                            result = result * Convert.ToDecimal(part);
                    }
                    else
                    {
                        sign = part;
                    }
                    index++;
                }
                textResult.Text = result.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            equation.Clear();
            textResult.Text = "0";
        }

        private void CalculateResult()
        {
            //switch (opp)
            //{
            //    case 1:
            //        Result = Firstnumber + SecondNumber;
            //        textResult.Text = Result.ToString();
            //        break;
            //    case 2:
            //        Result = Firstnumber / SecondNumber;
            //        textResult.Text = Result.ToString();
            //        break;

            //    default:
            //        break;
            //}
        }

      
    }
}
