using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LP_4
{
    public partial class Form2 : Form
    {
        private Form1 parent;
        public Form2(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            Tower tower = new Tower();
            Controls.Add(tower);
            
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();

        }

        private void start_spawn_btn_Click(object sender, EventArgs e)
        {
            Spawn spawn = new Spawn(this);
            spawn.Show();
            Controls.Add(spawn);

            spawn.SpawnEnemys();
        }
    }
    public class Spawn : PictureBox
    {
        private Form form;

        public Spawn(Form form)
        {
            this.form = form;
            this.Size = new Size(100, 100);
            this.Location = new Point(700, 175);
            this.Image = Image.FromFile(@"C:\Users\joshu\source\repos\LP_4\LP_4\Textures\stone-1162727_1280.png");
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            SpawnEnemys();
        }

        public void SpawnEnemys()
        {            
                int enemyCount = 10;
                int delay = 2000; 

                System.Windows.Forms.Timer SpawnTimer = new System.Windows.Forms.Timer();
                SpawnTimer.Interval = delay;

                int currentEnemyIndex = 0;

                SpawnTimer.Tick += (s, args) =>
                {
                    if (currentEnemyIndex < enemyCount)
                    {
                        Enemy enemy = new Enemy(form);
                        enemy.Show();
                        currentEnemyIndex++;
                    }
                    else
                    {
                        SpawnTimer.Stop(); 
                    }
                };

            SpawnTimer.Start();
        }
    }
    public class Enemy : PictureBox
    {
        public int health = 100;
        public int speed = 5;
        private System.Windows.Forms.Timer WalkTimer;



        public Enemy(Form parentForm)
        {
            this.Location = new Point(700, 200);
            this.Size = new Size(50, 50);
            this.Image = Image.FromFile(@"C:\Users\joshu\source\repos\LP_4\LP_4\Textures\enemy.png");
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            parentForm.Controls.Add(this);

            Walk();
        }
        public void Walk()
        {


            WalkTimer = new System.Windows.Forms.Timer();
            WalkTimer.Interval = 50;
            WalkTimer.Tick += (s, e) => Move();
            WalkTimer.Start();
        }

        public void Move()
        {
            this.Left -= speed;
        }
        
    }
    public class Tower : PictureBox
    {
        public int firerate;


        public Tower()
        {
            this.Size = new Size(100, 100);
            this.Location = new Point(300, 75);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = Image.FromFile(@"C:\Users\joshu\source\repos\LP_4\LP_4\Textures\building-3603542_1280.png");
        }
    }
}
