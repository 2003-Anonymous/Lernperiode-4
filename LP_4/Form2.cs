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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace LP_4
{
    public partial class Form2 : Form
    {
        private Form1 parent;
        List<Point> towerPositions = new List<Point>()
        {
            new Point(300, 75),
            new Point(300, 300)
        };
        public Form2(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            Base fortress = new Base(this);
            Controls.Add(fortress);


            foreach(Point p in towerPositions)
            {
                Tower tower = new Tower(this);
                tower.Location = p;
                Controls.Add(tower);
                tower.Shoot();
            }
                
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
        private Form parentForm;
        public int health = 100;
        public int speed = 5;
        private System.Windows.Forms.Timer WalkTimer;
        public int damage = 50;
        private bool hasDamagedFortress = false;
        public CustomProgressBar EnemyHealthBar;



        public Enemy(Form parentForm)
        {

            this.parentForm = parentForm;
            this.Location = new Point(700, 200);
            this.Size = new Size(50, 50);
            this.Image = Image.FromFile(@"C:\Users\joshu\source\repos\LP_4\LP_4\Textures\enemy.png");
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            parentForm.Controls.Add(this);

            EnemyHealthBar = new CustomProgressBar();
            EnemyHealthBar.Size = new Size(70, 10);
            EnemyHealthBar.Location = new Point(700, 200);
            EnemyHealthBar.Maximum = 100;
            EnemyHealthBar.Value = health;            
            EnemyHealthBar.BackColor = Color.Black;
            EnemyHealthBar.ForeColor = Color.Red;
            
            parentForm.Controls.Add(EnemyHealthBar);



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

            EnemyHealthBar.Location = new Point(this.Left - 10, this.Top - 20);

            if (this.Bounds.IntersectsWith(parentForm.Controls.OfType<Base>().FirstOrDefault()?.Bounds ?? new Rectangle()))
            {                
                Base fortress = parentForm.Controls.OfType<Base>().FirstOrDefault();

                if (!hasDamagedFortress)
                {
                    if (fortress != null) fortress.TakeDamage(damage); this.Dispose();EnemyHealthBar.Dispose();
                    hasDamagedFortress = true;
                }                
            }
        }        
    }





    public class Tower : PictureBox
    {
        public int firerate = 10;
        private System.Windows.Forms.Timer ShootTimer;
        private Form parentForm;


        public Tower(Form parent)
        {
            this.parentForm = parent;
            this.Size = new Size(100, 100);           
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = Image.FromFile(@"C:\Users\joshu\source\repos\LP_4\LP_4\Textures\building-3603542_1280.png");

        }


        public void Shoot()
        {
            ShootTimer = new System.Windows.Forms.Timer();
            ShootTimer.Interval = 5000/firerate;
            ShootTimer.Tick += (s, e) => ShotSpawning();
            ShootTimer.Start();
        }


        public void ShotSpawning()
        {
            Projectile projectile = new Projectile(this.Location, parentForm);
            parentForm.Controls.Add(projectile);
            projectile.Location = new Point(this.Left + this.Width / 2, this.Top + this.Height / 2);
        }
    }





    public class Projectile : PictureBox
    {
        public int speed = 5;
        private Enemy target;
        private System.Windows.Forms.Timer ProjectileTimer;

        public Projectile(Point startPosition, Form parentForm)
        {
            this.Size = new Size(10, 10);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = Image.FromFile(@"C:\Users\joshu\source\repos\LP_4\LP_4\Textures\arrow.bmp");
            target = FindClosestEnemy(parentForm);

            ProjectileTimerStart(parentForm);
        }


        public void MoveProjectile(Form parentForm)
        {
            if (target == null || target.IsDisposed)
            {
                ProjectileTimer.Stop();
                FindClosestEnemy(parentForm);
                return;
            }

            // Richtung berechnen
            int dx = target.Left - this.Left;
            int dy = target.Top - this.Top;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            // Normale Richtung berechnen
            if (distance > 0)
            {
                double moveX = dx / distance * speed;
                double moveY = dy / distance * speed;

                this.Left += (int)moveX;
                this.Top += (int)moveY;
            }

            // Töten von Gegner
            if (this.Bounds.IntersectsWith(target.Bounds))
            {
                ProjectileTimer.Stop();
                target.health -= 10;

                UpdateEnemyHealthBar();

                if (target.health <= 0)
                {
                    target.Dispose();
                    target.EnemyHealthBar.Dispose();
                    
                }

                this.Dispose(); 
            }
        }

        public void UpdateEnemyHealthBar()
        {
            target.EnemyHealthBar.Value = target.health;
        }


        public void ProjectileTimerStart(Form parentForm)
        {
            ProjectileTimer = new System.Windows.Forms.Timer();
            ProjectileTimer.Interval = 50;
            ProjectileTimer.Tick += (s, e) => MoveProjectile(parentForm);
            ProjectileTimer.Start();
        }


        private Enemy FindClosestEnemy(Form parentForm)
        {
            Enemy closestEnemy = null;
            double closestDistance = double.MaxValue;

            foreach (Control c in parentForm.Controls)
            {
                if (c is Enemy enemy)
                {
                    double distance = Math.Sqrt(Math.Pow(enemy.Left - this.Left, 2) + Math.Pow(enemy.Top - this.Top, 2));

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = enemy;
                    }
                }
            }
            return closestEnemy;
        }
    }





    public class Base : PictureBox
    {
        public int health = 1000;
        private bool isDestroyed = false;
        private ProgressBar healthBar;


        public Base(Form parent)
        {
            this.Size = new Size(70, 80);
            this.Location = new Point(10, (parent.ClientSize.Height - this.Height) / 2);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = Image.FromFile(@"C:\Users\joshu\source\repos\LP_4\LP_4\Textures\tower-146734_1280.png");

            healthBar = new ProgressBar();
            healthBar.Size = new Size(70, 10);  
            healthBar.Location = new Point(10, this.Height + 70);  
            healthBar.Maximum = 1000;  
            healthBar.Value = health;  
            healthBar.BackColor = Color.Black;  
            healthBar.ForeColor = Color.Green;  
            parent.Controls.Add(healthBar);  
        }



        public void TakeDamage(int damage)
        {
            if (isDestroyed) return;

            health -= damage;
            if (health <= 0)
            {                
                isDestroyed = true;                

                MessageBox.Show("Fortress destroyed");

                Application.Exit();
            }

            healthBar.Value = health;
            UpdateHealthBar();
        }


        public void UpdateHealthBar()
        {
            healthBar.Value = health;
        }
    }



    public class CustomProgressBar : ProgressBar
    {
        public Color BarColor { get; set; } = Color.Red;

        public CustomProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = ClientRectangle;

            using (SolidBrush brush = new SolidBrush(BarColor))
            {
                // Fortschrittsbereich zeichnen
                int width = (int)(rect.Width * ((double)Value / Maximum));
                e.Graphics.FillRectangle(brush, 0, 0, width, rect.Height);
            }

            // Rahmen zeichnen
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, rect.Width - 1, rect.Height - 1);
        }
    }

}
