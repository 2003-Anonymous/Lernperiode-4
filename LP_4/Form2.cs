using Microsoft.VisualBasic.ApplicationServices;
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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace LP_4
{
    
    public partial class Form2 : Form
    {

        int gold = 50;
        private Form1 parent;
        List<Point> towerPositions = new List<Point>()
        {
            new Point(400, 75),
            new Point(400, 300)            
        };

        List<Point> platformPositions = new List<Point>()
        {            
            new Point(75, 125), 
            new Point(225, 225),
            new Point(225, 350),
            new Point(400, 150),
            new Point(400, 50)
        };       


        public Form2(Form1 parent)
        {
            

            InitializeComponent();
            this.parent = parent;
            Gold_Label.Text = $"Gold: {gold}";

            Base fortress = new Base(this);
            Controls.Add(fortress);

            
            foreach (Point t in platformPositions)
            {
                Towerplatform platform = new Towerplatform(this);
                platform.Location = t;
                Controls.Add(platform);                
            }

            //foreach (Point p in towerPositions)
            //{
            //    Tower tower = new Tower(this);
            //    tower.Location = p;
            //    Controls.Add(tower);
            //    tower.Shoot();

            //}
            //this.BackgroundImage = Image.FromFile(@"C:\Users\joshu\source\repos\LP_4\LP_4\Textures\Background_1.jpeg");
            //this.BackgroundImageLayout = ImageLayout.Stretch; // Optional: Bild anpassen

        }




        private void back_btn_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();

        }


        public void AddGold(int amount)
        {
            gold += amount;
            Gold_Label.Text = $"Gold: {gold}";
        }

        private void start_spawn_btn_Click(object sender, EventArgs e)
        {
            Spawn spawn = new Spawn(this);
            spawn.Show();
            Controls.Add(spawn);
            
        }

        public void BuyTower(object sender, int costs)
        {
            if(gold >= costs)
            {
                gold -= costs;
                Gold_Label.Text = $"Gold: {gold}";

                if (sender is Control clickedControl)
                {
                    Tower tower = new Tower(this);
                    tower.Location = clickedControl.Location;
                    Controls.Add(tower);
                    tower.Shoot();

                    clickedControl.Dispose();
                }               
            }
        }
        

        public void BuyUpgrade(object sender, int costs)
        {
            if(gold >= costs)
            {
                gold -= costs;
                Gold_Label.Text = $"Gold: {gold}";
            }
        }
    }





    public class Spawn : PictureBox
    {
        private Form form;

        int[] waves = [10, 3];

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

            List<Point> path = new List<Point>()
            {
            new Point(700, 200),
            new Point(500, 200),
            new Point(500, 125),
            new Point(300, 125),
            new Point(300, 300),
            new Point(150, 300),
            new Point(150, 200),
            new Point(0, 200),
            };

            int enemyCount = 10;
            int delay = 4000; 

            System.Windows.Forms.Timer SpawnTimer = new System.Windows.Forms.Timer();
            SpawnTimer.Interval = delay;


            int currentEnemyIndex = 0;

            SpawnTimer.Tick += (s, args) =>
            {
                if (currentEnemyIndex < enemyCount)
                {
                    Enemy enemy = new Enemy(form,path);
                    enemy.Show();
                    currentEnemyIndex++;
                }
                else if(currentEnemyIndex == enemyCount)
                {
                    Boss boss = new Boss(form, path);
                    boss.Show();
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
        public int health = 120;
        public int speed = 3;
        public int drop = 50;
        private List<Point> path;
        private int currentPathIndex = 0;
        private System.Windows.Forms.Timer WalkTimer;
        public int damage = 50;
        private bool hasDamagedFortress = false;
        public CustomProgressBar EnemyHealthBar;



        public Enemy(Form parentForm, List<Point> path)
        {

            this.parentForm = parentForm;
            this.path = path;            
            this.Location = path[0]; //700, 200
            this.Size = new Size(25, 25);
            this.Image = Image.FromFile(@"C:\Users\joshu\source\repos\LP_4\LP_4\Textures\enemy.png");
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            parentForm.Controls.Add(this);

            EnemyHealthBar = new CustomProgressBar();
            EnemyHealthBar.Size = new Size(35, 5);
            EnemyHealthBar.Location = new Point(700, 200);
            EnemyHealthBar.Maximum = health;
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
            WalkTimer.Tick += MoveAlongPath;
            WalkTimer.Start();            
        }

        private void MoveAlongPath(object sender, EventArgs e)
        {
           if(health > 0)
            {
                EnemyHealthBar.Location = new Point(this.Left - 10, this.Top - 20);

                if (currentPathIndex < (path.Count - 1))
                {
                    
                    
                    if (this.Bounds.IntersectsWith(parentForm.Controls.OfType<Base>().FirstOrDefault()?.Bounds ?? new Rectangle()))
                    {
                        Base fortress = parentForm.Controls.OfType<Base>().FirstOrDefault();

                        if (!hasDamagedFortress)
                        {
                            if (fortress != null) fortress.TakeDamage(damage); this.Dispose(); EnemyHealthBar.Dispose();
                            hasDamagedFortress = true;
                        }
                    }
                    

                    Point target = path[currentPathIndex + 1];

                    int dx = target.X - this.Left;
                    int dy = target.Y - this.Top;
                    double distance = Math.Sqrt(dx * dx + dy * dy);

                    if (distance < speed)
                    {
                        currentPathIndex++;
                        if (currentPathIndex >= path.Count - 1)
                        {
                            WalkTimer.Stop();
                        }
                    }
                    else
                    {                        
                        double moveX = dx / distance * speed;
                        double moveY = dy / distance * speed;

                        this.Left += (int)moveX;
                        this.Top += (int)moveY;
                    }
                }
                else
                {                    
                    WalkTimer.Stop();
                }
            }
        }
            
    }





    public class Tower : PictureBox
    {
        public int firerate = 5;
        private System.Windows.Forms.Timer ShootTimer;
        private Form parentForm;
        public int upgradeCosts = 100;


        public Tower(Form parent)
        {           
            this.parentForm = parent;            
            this.Size = new Size(50, 50);           
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = Image.FromFile(@"C:\Users\joshu\source\repos\LP_4\LP_4\Textures\building-3603542_1280.png");
            this.Click += Upgrade;
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

        public void Upgrade(object sender, EventArgs e)
        {
            if (sender is Tower tower)
            {
                bool enoughGold = false;

                if (enoughGold)
                {
                    Form2 form = Parent as Form2;
                    form.BuyUpgrade(sender, upgradeCosts);
                }
            }
        }

    }





    public class Projectile : PictureBox
    {
        public int speed = 10;
        private Enemy target;
        public int damage = 20;
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
                this.Dispose();
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
                
                target.health -= damage;

                UpdateEnemyHealthBar();              

                if (target.health <= 0)
                {
                    Form2 form = target.Parent as Form2;
                    
                    form.AddGold(target.drop);
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
            this.Size = new Size(35, 40);
            this.Location = new Point(10, (parent.ClientSize.Height - this.Height) / 2);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = Image.FromFile(@"C:\Users\joshu\source\repos\LP_4\LP_4\Textures\tower-146734_1280.png");

            healthBar = new ProgressBar();
            healthBar.Size = new Size(35, 5);  
            healthBar.Location = new Point(10, this.Height + 135);  
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



    public class Towerplatform : PictureBox
    {
        public int costs = 50;

        public Towerplatform(Form parent)
        {
            this.Size = new Size(35, 40);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = Image.FromFile(@"C:\Users\joshu\source\repos\LP_4\LP_4\Textures\rug-576081_1280.png");
            this.Click += PlatformClick;
        }

        
        private void PlatformClick(object sender, EventArgs e)
        {
            Form2 form = Parent as Form2;

            form.BuyTower(sender, costs);            
        }
    }



    public class Boss : Enemy
    {
        


        public Boss(Form parentForm, List<Point> path) : base(parentForm, path)
        {
            this.health = 1000;
            this.drop = 200;
            this.damage = 150;
            this.Size = new Size(50, 50);
            this.EnemyHealthBar.Maximum = this.health;
            this.EnemyHealthBar.Value = this.health;
            this.Image = Image.FromFile(@"C:\Users\joshu\source\repos\LP_4\LP_4\Textures\zombie-7470191_1280.png");
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }


}
