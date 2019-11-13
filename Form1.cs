using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace masini
{
    public partial class Form1 : Form
    {
        public double a = 0;
        public double b = 0;
        public double c = 0;
        public double d = 0;
        public double x1 = 0;
        public double x2 = 0;
        public double yskor1 = 0;
        public double yskor2 = 0;
        public double skorost1 = 0;
        public double skorost2 = 0;
        public double s1 = 0;
        public double s2 = 0;
        public double costil = 0;
        public double r1001 = 0;
        public double r1002 = 0;
        public double sbenz = 0;
        public double final1 = 0;
        public bool prov;
        public DialogResult dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vre.Text = null;
            put1.Text = null;
            put2.Text = null;
            ben1.Text = null;
            ben2.Text = null;
            sto1.Text = null;
            sto2.Text = null;
            prov = double.TryParse(ras.Text, out c);
            if (prov == false)
            {
                MessageBox.Show("Ошибка в поле Расстояние");
                ras.Text = null;
            }
            else
            {
                c = Convert.ToDouble(ras.Text);
                if (c<0)
                {
                    dr = MessageBox.Show("Расстояние не может быть меньше нуля\r\nВы хотите сделать ваше число положительным?"
                   , "Программа не работает с отрицательным расстоянием", MessageBoxButtons.YesNo);
                    switch(dr)
                    {
                        case DialogResult.Yes:
                            ras.Text = "" + (c * (-1));
                            costil++;
                            break;
                        case DialogResult.No:
                            ras.Text = null;
                            break;
                    }
                }
                else
                {
                    c = c * (-1);
                    costil++;
                }
            }
            prov = double.TryParse(cen.Text, out sbenz);
            if (prov == false)
            {
                MessageBox.Show("Ошибка в поле Стоимости бензина");
                cen.Text = null;
            }
            else
            {
                sbenz = Convert.ToDouble(cen.Text);
                if (sbenz <= 0)
                {
                    if (sbenz < 0)
                    {
                        dr = MessageBox.Show("Стоимость бензина не может быть меньше нуля\r\nВы хотите сделать ваше число положительным ?"
                      , "Программа не работает с отрицательной стоимостью бензина", MessageBoxButtons.YesNo);
                        switch (dr)
                        {
                            case DialogResult.Yes:
                                sbenz = sbenz * (-1);
                                cen.Text = "" + sbenz;
                                costil++;
                                break;
                            case DialogResult.No:
                                cen.Text = null;
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Стоимость бензина не может быть равна нулю");
                        cen.Text = null;
                    }
                }
                else
                {
                    costil++;
                }
            }
            prov = double.TryParse(sko1.Text, out skorost1);
            if (prov == false)
            {
                MessageBox.Show("Ошибка в поле Скорости для первой машины");
                sko1.Text = null;
            }
            else
            {
                skorost1 = Convert.ToDouble(sko1.Text);
                if (skorost1 <= 0)
                { 
                    if (skorost1 < 0)
                    {
                        dr = MessageBox.Show("Скорость не может быть отрицательной");

                        sko1.Text = null;
                        costil--;
                        return;

                    }
                    else
                    {
                        dr = MessageBox.Show("Вы уверены, что первая машина начинает путь с нулевой скоростью?"
                         , "Подтвердите свой выбор", MessageBoxButtons.YesNo);
                        switch (dr)
                        {
                            case DialogResult.No:
                                sko1.Text = null;
                                costil--;
                                break;
                        }
                    }
                }
                
                costil++;
            }
            prov = double.TryParse(ysk1.Text, out yskor1);
            if (prov == false)
            {
                MessageBox.Show("Ошибка в поле Ускорения для первой машины");
                ysk1.Text = null;
            }
            else
            {
                yskor1 = Convert.ToDouble(ysk1.Text);
                if (yskor1 <=0)
                {
                    if (yskor1 < 0)
                    {
                        dr = MessageBox.Show("Вы уверены, что первая машина замедляется?"
                  , "Подтвердите свой выбор", MessageBoxButtons.YesNo);
                        switch (dr)
                        {
                            case DialogResult.No:
                                yskor1 = yskor1 * (-1);
                                ysk1.Text = "" + yskor1;
                                break;
                        }
                    }
                    else
                    {
                        dr = MessageBox.Show("Вы уверены, что первая машина едет без ускорения?"
                 , "Подтвердите свой выбор", MessageBoxButtons.YesNo);
                        switch (dr)
                        {
                            case DialogResult.No:
                                ysk1.Text = null;
                                costil--;
                                break;
                        }
                    }
                }
                costil++;
            }
            prov = double.TryParse(ras1001.Text, out r1001);
            if (prov == false)
            {
                MessageBox.Show("Ошибка в поле Расхода для первой машины");
                ras1001.Text = null;
            }
            else
            {
                r1001 = Convert.ToDouble(ras1001.Text);
                if (r1001 <=0)
                {
                    if (r1001 < 0)
                    {
                        dr = MessageBox.Show("Расход топлива перовй машины не может быть меньше нуля\r\nВы хотите сдедать расход топлива положительным?"
                  , "Подтвердите свой выбор", MessageBoxButtons.YesNo);
                        switch (dr)
                        {
                            case DialogResult.Yes:
                                r1001 = r1001 * (-1);
                                ras1001.Text = "" + r1001;
                                costil++;
                                break;
                            case DialogResult.No:
                                ras1001.Text = null;
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Расход топлива перовй машины не может быть равен нулю");
                        ras1001.Text = null;
                    }
                }
                else
                {
                    costil++;
                }
            }
            prov = double.TryParse(sko2.Text, out skorost2);
            if (prov == false)
            {
                MessageBox.Show("Ошибка в поле Скорости для второй машины");
                sko2.Text = null;
            }
            else
            {
                skorost2 = Convert.ToDouble(sko2.Text);
                if (skorost2 <= 0)
                {
                    if (skorost2 < 0)
                    {
                        dr = MessageBox.Show("Скорость не может быть отрицательной");

                        sko2.Text = null;
                        costil--;
                        return;
                    }
                    else
                    {
                        dr = MessageBox.Show("Вы уверены, что вторая машина начинает путь с нулевой скоростью?"
                         , "Подтвердите свой выбор", MessageBoxButtons.YesNo);
                        switch (dr)
                        {
                            case DialogResult.No:
                                sko2.Text = null;
                                costil--;
                                break;
                        }
                    }
                }
                    costil++;
            }
            prov = double.TryParse(ysk2.Text, out yskor2);
            if (prov == false)
            {
                MessageBox.Show("Ошибка в поле Ускорения для второй машины");
                ysk2.Text = null;
            }
            else
            {
                yskor2 = Convert.ToDouble(ysk2.Text);
                if (yskor2 <= 0)
                {
                    if (yskor2 < 0)
                    {
                        dr = MessageBox.Show("Вы уверены, что вторая машина замедляется?"
                  , "Подтвердите свой выбор", MessageBoxButtons.YesNo);
                        switch (dr)
                        {
                            case DialogResult.No:
                                yskor2 = yskor2 * (-1);
                                ysk2.Text = "" + yskor2;
                                break;
                        }
                    }
                    else
                    {
                        dr = MessageBox.Show("Вы уверены, что вторая машина едет без ускорения?"
                 , "Подтвердите свой выбор", MessageBoxButtons.YesNo);
                        switch (dr)
                        {
                            case DialogResult.No:
                                ysk2.Text = null;
                                costil--;
                                break;
                        }
                    }
                }
                costil++;
            }
            prov = double.TryParse(ras1002.Text, out r1002);
            if (prov == false)
            {
                MessageBox.Show("Ошибка в поле Расхода для второй машины");
                ras1002.Text = null;
            }
            else
            {
                r1002 = Convert.ToDouble(ras1002.Text);
                if (r1002 <= 0)
                {
                    if (r1002 < 0)
                    {
                        dr = MessageBox.Show("Расход топлива второй машины не может быть меньше нуля\r\nВы хотите сдедать расход топлива положительным?"
                  , "Подтвердите свой выбор", MessageBoxButtons.YesNo);
                        switch (dr)
                        {
                            case DialogResult.Yes:
                                r1002 = r1002 * (-1);
                                ras1002.Text = "" + r1002;
                                costil++;
                                break;
                            case DialogResult.No:
                                ras1002.Text = null;
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Расход топлива перовй машины не может быть равен нулю");
                        ras1002.Text = null;
                    }
                }
                else
                {
                    costil++;
                }
            }
            if (costil == 8)
            {
                a = (yskor1 + yskor2);
                if (a == 0)
                {
                    a = 1;
                }
                else
                {
                    a = a / 2;
                }
                b = (skorost1 + skorost2);
                d = Math.Pow(b, 2) - 4 * a * c;
                if (d >= 0)
                {
                    if (d > 0)
                    {
                        x1 =((-b )+Math.Sqrt(d)) / (2 * a);
                    }
                    else
                    {
                        x1 = (-b) / (2 * a);
                    }
                    s1 = (skorost1 * x1) +((yskor1 * Math.Pow(x1, 2)) / 2);
                    s2 =(skorost2 * x1) +((yskor2* Math.Pow(x1, 2)) / 2);
                    r1001 = s1 / 100 * r1001;
                    r1002 = s2 / 100 * r1002;
                    vre.Text = x1.ToString("0.00");
                    put1.Text = Math.Abs(s1).ToString("0.00");
                    put2.Text = Math.Abs(s2).ToString("0.00");
                    ben1.Text = Math.Abs(r1001).ToString("0.00");
                    ben2.Text = Math.Abs(r1002).ToString("0.00");
                    if (checkBox1.Checked)
                    {
                        final1 = (r1001 * sbenz) * 2;
                        sto1.Text = Math.Abs(final1).ToString("0.00") + "р.";
                        final1 = (r1002 * sbenz) * 2;
                        sto2.Text = Math.Abs(final1).ToString("0.00") + "р.";
                    }
                    else
                    {
                        final1 = (r1001 * sbenz);
                        sto1.Text = Math.Abs(final1).ToString("0.00") + " р.";
                        final1 = (r1002 * sbenz);
                        sto2.Text = Math.Abs(final1).ToString("0.00") + "р.";

                    }
                }
                else
                {
                    MessageBox.Show("Машины никогда не встретятся с таким ускорением\r\n" +
                        "Попробуйте ещё раз изменив параметры машин");
                }
            }
            costil = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ras_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
