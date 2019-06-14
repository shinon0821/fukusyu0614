using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fukusyu0614
{
    public partial class Form1 : Form
    {
        int time = 100 * 5;
        int velx[]=new int [3];
        int vely[]=new int [3];
        public Form1()
        {
            InitializeComponent();
            for(int i=0;i<3;i;;)
            {
                velx[i]=Random.Next(-10,11);
                vely[i]=Random.next(-10,11);
            }

            velx[0]=rand.next(-10,,11);
        velx[1]=rand.Next(-10,11);
        velx[2]=rand.Next(-10,11);
        vely[0]=rand.Next(-10,11);
        vely[1]=rand.Next(-10,11);
        vely[2]=rand.Next(-10,11);

        label1.Left=rand.Next(ClientSize.Width-label1.Width);
        label1.Top=rand.Next(ClientSize.Height=label1.Height);
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left+=velx[2];
            label1.Top+=vely[2];

            if (label1.Left <= 0)
            {
                velx[2] = -velx[2];
            }
            if (label1.Top <= 0)
            {
                vely[2] = -vely[2];
            }
            if (label1.Left >= ClientSize.Width - label1.Width)
            {
                velx[2] = -Math.Abs(-velx[2]);
            }
            if (label1.Top >= ClientSize.Height - label1.Height)
            {
                vely[2] = -Math.Abs(-vely[2]);
            }
          
            }
        }
    }
}
