using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WF_HW_Module_3
{
    public partial class Form1 : Form
    {
        bool Flag = false;
        public Form1()
        {
            InitializeComponent();
            comboBox1_Kind_Petrol.Items.Add("а-92");
            comboBox1_Kind_Petrol.Items.Add("а-95");
            comboBox1_Kind_Petrol.Items.Add("а-98");
            comboBox1_Kind_Petrol.Items.Add("а-100");
            comboBox1_Kind_Petrol.Items.Add("а-ДТ");
            comboBox1_Kind_Petrol.Items.Add("Газ");
            textBox_Price_HotDog.Text = price_HotDog.ToString();
            textBox_Price_Burger.Text = price_Burger.ToString();
            textBox_Price_Cola.Text = price_Cola.ToString();
            textBox_Price_Potato.Text = price_Potata.ToString();
            textBox_Amount_HotDog.Text = 0.ToString();
            textBox_Amount_Burger.Text = 0.ToString();
            textBox_Amount_Potato.Text = 0.ToString();
            textBox_Amount_Cola.Text = 0.ToString();


            //toolStripDropDownButton1.DropDownItems.Add(DateTime.Now.DayOfWeek.ToString());
            





        }
        private double a92 = 50;
        private double a95 = 55;
        private double a98 = 64;
        private double a100 = 70;
        private double dp = 53;
        private double lpg = 20;
        public double price_HotDog = 40;
        public double price_Burger = 67;
        public double price_Potata = 30;
        public double price_Cola = 28;

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1_Kind_Petrol.SelectedIndex = 0;
            radioButton_Amount.Checked = true;

            notifyIcon1.BalloonTipTitle = "АЗС касса";
            notifyIcon1.BalloonTipText = "Приложение свернуто";
            notifyIcon1.Text = "Касса";


        }
       

        private void comboBox1_Kind_Petrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1_Kind_Petrol.SelectedIndex == 0)
                textBox1_Price_Petrol.Text = a92.ToString();
            if (comboBox1_Kind_Petrol.SelectedIndex == 1)
                textBox1_Price_Petrol.Text = a95.ToString();
            if (comboBox1_Kind_Petrol.SelectedIndex == 2)
                textBox1_Price_Petrol.Text = a98.ToString();
            if (comboBox1_Kind_Petrol.SelectedIndex == 3)
                textBox1_Price_Petrol.Text = a100.ToString();
            if (comboBox1_Kind_Petrol.SelectedIndex == 4)
                textBox1_Price_Petrol.Text = dp.ToString();
            if (comboBox1_Kind_Petrol.SelectedIndex == 5)
                textBox1_Price_Petrol.Text = lpg.ToString();
            
        }

        private void radioButton_Amount_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Amount.Checked)
            {
                textBox_Summ_For_Petrol.ReadOnly = true;
                textBox_Amount_Petrol.ReadOnly = false;
                textBox_Amount_Petrol.Text = 10.ToString("N2");
                textBox_Summ_For_Petrol.Text = string.Empty;
            }
            if (radioButton_Summ_Petrol.Checked)
            {
                textBox_Summ_For_Petrol.ReadOnly = false;
                textBox_Amount_Petrol.ReadOnly = true;
                textBox_Summ_For_Petrol.Text = 100.ToString("N2");
                textBox_Amount_Petrol.Text = string.Empty;
            }

        }
        private double Payment_Petrol()
        {
            double res = 0;
            
            
              
                if (radioButton_Amount.Checked)
                {
                    res = double.Parse(textBox1_Price_Petrol.Text) * double.Parse(textBox_Amount_Petrol.Text);
                }
                if (radioButton_Summ_Petrol.Checked)
                {
                    res = double.Parse(textBox_Summ_For_Petrol.Text);

                }
            
            return res;
        }

        private void textBox_Amount_Petrol_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_Amount_Petrol.Text))
                label_Summ_Total.Text = Payment_Petrol().ToString();
        }

        private void textBox_Summ_For_Petrol_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_Summ_For_Petrol.Text))
                label_Summ_Total.Text = Payment_Petrol().ToString();
        }
        private void textBox_cafe_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_Amount_HotDog.Text) && !string.IsNullOrEmpty(textBox_Amount_Burger.Text) &&
                !string.IsNullOrEmpty(textBox_Amount_Potato.Text) && !string.IsNullOrEmpty(textBox_Amount_Cola.Text))
              label_cafe_Pay.Text = (double.Parse(textBox_Price_HotDog.Text) * double.Parse(textBox_Amount_HotDog.Text) +
                                        double.Parse(textBox_Price_Burger.Text) * double.Parse(textBox_Amount_Burger.Text) +
                                        double.Parse(textBox_Price_Potato.Text) * double.Parse(textBox_Amount_Potato.Text) +
                                        double.Parse(textBox_Price_Cola.Text) * double.Parse(textBox_Amount_Cola.Text)).ToString();
            
        }

        private void checkBox_HotDog_CheckedChanged(object sender, EventArgs e)
        {
            
            if(checkBox_HotDog.Checked)
                textBox_Amount_HotDog.Text = 1.ToString();

            else textBox_Amount_HotDog.Text = 0.00.ToString();
            
        }

        private void checkBox_Burger_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Burger.Checked)
                textBox_Amount_Burger.Text = 1.ToString();
            else textBox_Amount_Burger.Text = 0.ToString();
        }

        private void checkBox_Potato_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Potato.Checked)
                textBox_Amount_Potato.Text = 1.ToString();
            else textBox_Amount_Potato.Text = 0.ToString();
        }

        private void checkBox_Cola_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Cola.Checked)
                textBox_Amount_Cola.Text = 1.ToString();
            else textBox_Amount_Cola.Text = 0.ToString();

        }

        private void Button_Total_Cost_Click(object sender, EventArgs e)
        {
            string check_list = "";
            int count = 0;
            label_Total_Summ.Text = ( double.Parse(label_Summ_Total.Text) + double.Parse(label_cafe_Pay.Text)).ToString();
            if (double.Parse(label_Summ_Total.Text) > 0)
            {
                check_list += ++count + ". "+comboBox1_Kind_Petrol.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(textBox_Amount_Petrol.Text) && double.Parse(textBox_Amount_Petrol.Text) > 0)
                    check_list += "\t" + textBox_Amount_Petrol.Text + " л.\t";
                else
                {
                    check_list += "\t" + (double.Parse(textBox_Summ_For_Petrol.Text) / double.Parse(textBox1_Price_Petrol.Text)).ToString() + " л.\t";
                }
                check_list += label_Summ_Total.Text + "  грн.\n";



                if (checkBox_HotDog.Checked)
                {
                    check_list += ++count + ". " + checkBox_HotDog.Text + "  " + textBox_Amount_HotDog.Text + " шт." + "  " +
                        double.Parse(textBox_Amount_HotDog.Text) * double.Parse(textBox_Price_HotDog.Text) + " грн.";
                }

                if (checkBox_Burger.Checked)
                {
                    check_list += "\n"+ ++count + ". " + checkBox_Burger.Text + "  " + textBox_Amount_Burger.Text + " шт." + "  " +
                        double.Parse(textBox_Amount_Burger.Text) * double.Parse(textBox_Price_Burger.Text) + " грн.";
                }
                if (checkBox_Potato.Checked)
                {
                    check_list += "\n" + ++count + ". " + checkBox_Potato.Text + "  " + textBox_Amount_Potato.Text + " шт." + "  " +
                        double.Parse(textBox_Amount_Potato.Text) * double.Parse(textBox_Price_Potato.Text) + " грн.";
                }
                if (checkBox_Cola.Checked)
                {
                    check_list += "\n" + ++count + ". " + checkBox_Cola.Text + "  " + textBox_Amount_Cola.Text + " шт." + "  " +
                        double.Parse(textBox_Amount_Cola.Text) * double.Parse(textBox_Price_Cola.Text) + " грн.";
                }





                check_list += "\n\nВсего к оплате : " + (double.Parse(label_Summ_Total.Text) + double.Parse(label_cafe_Pay.Text)).ToString() +" грн.";
                check_list += "\n\n"+DateTime.Now;


            }




            MessageBox.Show("Чек : \n"+ check_list);
        }


        class Order
        {
             List<string> names = new List<string>();
             List<string> price = new List<string>();
             List<string> amount = new List<string>();
             List<List<string>> AllInfo { get; }
            public void set(string name , string price, string amount)
            {
                this.names.Add(name);
                this.price.Add(price);
                this.amount.Add(amount);
               
            }
            public List<List<string>> GetInfo()
            {
                AllInfo.Add(this.names);
                AllInfo.Add(this.price);
                AllInfo.Add(this.amount);
                return AllInfo;
            }
            


        }
        static private void SaverOrders(string orders, int index = 0)
        {
            



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Flag)
            {
                toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString();
                Flag = false;
            }
            else
            {
                toolStripStatusLabel1.Text = DateTime.Now.ToShortTimeString();
                Flag |= true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal) 
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);


            }
            else if(FormWindowState.Normal == this.WindowState) 
            {
                notifyIcon1.Visible=false;
            }
        }
    }
}
