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
        int getCount;
         
        int time = 100 * 5;

        int[] velx=new int [3];
        int[] vely=new int [3];

        // const = 定数
        const int itemCount = 3;

        enum SCENE
        {
            TITLE,
            GAME,
            GAMEOVER,
            CLEAR,
            NONE
        }
        /// <summary>
        /// 現在のシーン
        /// </summary>
        SCENE nowScene;

        /// <summary>
        /// 　切り替えたいシーン
        /// </summary>
        SCENE nextScene;

        int[] vx = new int[itemCount];
        int[] vy = new int[itemCount];
        Label[] labels = new Label[itemCount];

        private static Random rand = new Random();

        public Form1()
        {
            InitializeComponent();

            nextScene = SCENE.TITLE;
            nowScene = SCENE.NONE;

            for (int i = 0; i < itemCount; i++)
            {
                labels[i] = new Label();
                labels[i].AutoSize = true;
                labels[i].Text = "(・ワ ・ 🌻)";
                Controls.Add(labels[i]);
                labels[i].Font = label1.Font;
                labels[i].ForeColor = label1.ForeColor;
                labels[i].Left = rand.Next(ClientSize.Width - label1.Width);
                labels[i].Top = rand.Next(ClientSize.Height - label1.Height);
                vx[i] = rand.Next(-5,6);
                vy[i] = rand.Next(-5,6);
            }

            label1.Left = rand.Next(ClientSize.Width - label1.Width);
            label1.Top = rand.Next(ClientSize.Height - label1.Height);

           
            
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void initProc()
        {
            //nextSceneがNONEだったら、何もしない
            if (nextScene == SCENE.NONE) return;

            nowScene = nextScene;
            nextScene = SCENE.NONE;

            switch(nowScene)
            {
                case SCENE.TITLE:
                    label2.Visible=true;
                    button1.Visible=true;
                    break;

                case SCENE.GAME:
                    label2.Visible=false;
                    button1.Visible=false;
                    getCount = itemCount;
                    break;
            }
        }

        void updateProc()
        {
            if(nowScene==SCENE.GAME)
            {
                updateGame();
            }
        }

        void updateGame()
        {
            for (int i = 0; i < itemCount; i++)
            {
                labels[i].Left += vx[i];
                labels[i].Top += vy[i];

                labels[i].Left += velx[2];
                labels[i].Top += vely[2];

                if (labels[i].Left <= 0)
                {
                    vx[2] = -vx[2];
                }
                if (labels[i].Top <= 0)
                {
                    vy[2] = -vy[2];
                }
                if (labels[i].Left >= ClientSize.Width - labels[i].Width)
                {
                    vx[2] = -Math.Abs(-vx[2]);
                }
                if (labels[i].Bottom >= ClientSize.Height - labels[i].Height)
                {
                    vy[2] = -Math.Abs(-vy[2]);
                }
                

                label2.Left += vx[1];
                label2.Top += vy[1];

                if (label2.Left <= 0)
                {
                    vx[1] = -vx[1];
                }
                if (label2.Top <= 0)
                {
                    vy[1] = -vy[1];
                }
                if (label2.Left >= ClientSize.Width - label2.Width)
                {
                    vx[1] = -Math.Abs(-vx[1]);
                }
                if (label2.Top >= ClientSize.Height - label2.Height)
                {
                    vy[1] = -Math.Abs(-vy[1]);
                }
                label2.Left += vx[1];
                label2.Top += vy[1];

                if (label2.Left <= 0)
                {
                    vx[1] = -vx[1];
                }
                if (label2.Top <= 0)
                {
                    vy[1] = -vy[1];
                }
                if (label2.Left >= ClientSize.Width - label2.Width)
                {
                    vx[1] = -Math.Abs(-vx[1]);
                }
                if (label2.Top >= ClientSize.Height - label2.Height)
                {
                    vy[1] = -Math.Abs(-vy[1]);
                }

                Point p = PointToClient(MousePosition);

                if ((p.X >= labels[i].Left)
                  && (p.X <= labels[i].Right)
                  && (p.Y >= labels[i].Top)
                  && (p.Y <= labels[i].Bottom)
                  )
                {
                    //timer1.Enabled = false;
                    labels[i].Visible = false;
                    getCount--;
                    if (getCount<=0)
                    {
                        nextScene = SCENE.CLEAR;
                    }
                }

               
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            initProc();
            updateProc();
            
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nextScene = SCENE.GAME;

        }
    }
    
}
