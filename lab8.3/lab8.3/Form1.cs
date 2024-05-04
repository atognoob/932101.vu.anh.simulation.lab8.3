using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double[] probT, probEx;
        int N;
        int[] stat;
        Random rnd = new Random();
        double a;
        private void button1_Click(object sender, EventArgs e)
        {
            probT = new double[5];
            probEx = new double[5];
            stat = new int[5];
            N = int.Parse(textBox6.Text);
            probT[0] = double.Parse(textBox1.Text);
            probT[1]= double.Parse(textBox2.Text);
            probT[2] = double.Parse(textBox3.Text);
            probT[3] = double.Parse(textBox4.Text);
            probT[4] = 1;

            
            for(int i = 0; i<N; i++)
            {
                a = rnd.NextDouble();

                for (int k = 0; k < 5; k++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        double gap = 0;
                        if (j > 0) gap = (probT[j] - probT[j - 1]) / 2;
                        if (a < probT[j])
                        {
                            if ((a < probT[j] - gap) && (j > 0))
                            {
                                stat[j - 1]++;
                                break;
                            }
                            else { stat[j]++; break; }
                        }
                    }
                }
            }
            for (int i = 0; i<5; i++)
            {
                probEx[i] = stat[i] / (double)N;
            }
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < 5; i++)
            {
                chart1.Series[0].Points.AddXY(i+1, probEx[i]);
            }
        }
    }
}
