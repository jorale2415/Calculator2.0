using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Name: Jordan Alex
namespace Calculator2._0
{
    public partial class Form1 : Form
    {
        String path = Environment.CurrentDirectory + "/" + "Memory.txt";
        Double result = 0.0;
        String operatorUsed = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Input_Click(object sender, EventArgs e)
        {
            Button input = (Button)sender;

            if(txtInput.Text == "0" && input.Text != ".")
            {
                txtInput.Clear();
                if (txtInput.Text.Contains(".") && input.Text != ".")
                {
                    txtInput.Text += input.Text;
                }
                else if (!txtInput.Text.Contains("."))
                {
                    txtInput.Text += input.Text;
                }
            }
            else
            {
                if (txtInput.Text.Contains(".") && input.Text != ".")
                {
                    txtInput.Text += input.Text;
                }
                else if (!txtInput.Text.Contains("."))
                {
                    txtInput.Text += input.Text;
                }
            }
                    
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtInput.Text = "0";
        }

        private void KeysPressed(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case ".":
                    btnDecimal.PerformClick();
                    break;
                case "0":
                    btn0.PerformClick();
                    break;
                case "1":
                    btn1.PerformClick();
                    break;
                case "2":
                    btn2.PerformClick();
                    break;
                case "3":
                    btn3.PerformClick();
                    break;
                case "4":
                    btn1.PerformClick();
                    break;
                case "5":
                    btn5.PerformClick();
                    break;
                case "6":
                    btn6.PerformClick();
                    break;
                case "7":
                    btn7.PerformClick();
                    break;
                case "8":
                    btn8.PerformClick();
                    break;
                case "9":
                    btn9.PerformClick();
                    break;
                case "+":
                    btnAdd.PerformClick();
                    break;
                case "-":
                    btnSub.PerformClick();
                    break;
                case "*":
                    btnMultiple.PerformClick();
                    break;
                case "/":
                    btnDivide.PerformClick();
                    break;
                case "=":
                    btnEqual.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button operatorClicked = (Button)sender;
            operatorUsed = operatorClicked.Text;
            result = Double.Parse(txtInput.Text);
            txtDisplay.Text = result + " " + operatorUsed;
            btnClearEntry.PerformClick();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {   
            string value2 = "";
            if (!txtDisplay.Text.Contains("="))
            {
                switch (operatorUsed)
                {
                    case "+":
                        value2 = txtInput.Text;
                        txtDisplay.AppendText(" " + value2 + " =");
                        txtInput.Text = (result + Double.Parse(txtInput.Text)).ToString();
                        break;
                    case "-":
                        value2 = txtInput.Text;
                        txtDisplay.AppendText(" " + value2 + " =");
                        txtInput.Text = (result - Double.Parse(txtInput.Text)).ToString();
                        break;
                    case "*":
                        value2 = txtInput.Text;
                        txtDisplay.AppendText(" " + value2 + " =");
                        txtInput.Text = (result * Double.Parse(txtInput.Text)).ToString();
                        break;
                    case "/":
                        value2 = txtInput.Text;
                        txtDisplay.AppendText(" " + value2 + " =");
                        if (txtInput.Text == "0")
                        {
                            txtDisplay.Text = "**Cannot Divide by Zero**";
                            break;
                        }
                        else
                        {
                            txtInput.Text = (result / Double.Parse(txtInput.Text)).ToString();
                            break;
                        }
                    default:
                        break;
                }
            }          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
        }

        private void btnPosNeg_Click(object sender, EventArgs e)
        {
            Double number = Convert.ToDouble(txtInput.Text);
            Double num = number - number - number;

            txtInput.Text = Convert.ToString(num);
        }

        private void btnMemoryAdd_Click(object sender, EventArgs e)
        {
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine(txtInput.Text);
                        sw.Close();
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(txtInput.Text);
                    sw.Close();
                }
            }
            btnClearEntry.PerformClick();
        }

        private void btnMemoryClear_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        private void btnMemoryRecall_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string text = sr.ReadToEnd();
                    txtInput.Text = text;
                    sr.Close();
                }
            }
        }
    }
}
