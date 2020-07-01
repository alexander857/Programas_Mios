using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace BallDown
{
    public partial class BallDown : Form
    {
        private List<Plataform> _plataforms = new List<Plataform>();
        private List<LifesClass> lifes = new List<LifesClass>();
        private PictureBox player = new PictureBox();
        private PictureBox fireDown, fireUp;
        private PictureBox wallLeft, wallRight;
        private PictureBox[] hearts;
        private Panel score;
        private Label lblscorePlayer;
        private SoundPlayer musicBack, mainMusic;
        public BallDown()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;

            //sonidos
            musicBack = new SoundPlayer("../../Sounds/zelda.wav");
            mainMusic = new SoundPlayer("../../Sounds/mario.wav");
        }
        
        //codigo para que se vean bien los picturebox
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;    // WS_EX_COMPOSITED
                return handleParam;
            }
        }

        //metodo load, cargan todos los elementos
        private void BallDown_Load(object sender, EventArgs e)
        {
            musicBack.PlayLooping();
            LoadPanel();
            LoadFire();
            LoadWall();
            LoadPlataforms();
            
            player.Height = player.Width = 20;
            
            player.Top = fireUp.Top + (fireUp.Height * 5);
            player.Left = fireUp.Left + (fireUp.Width / 2);
            
            player.Image = Image.FromFile($"../../Sprites/{DataGame.ball + "1"}.png");
            player.SizeMode = PictureBoxSizeMode.StretchImage;
            player.BackColor = Color.Transparent;
            
            Controls.Add(player);
        }

        //movimiento de las plataformas
        private void timer1_Tick(object sender, EventArgs e)
        {
            //se le da movimiento a las plataformas 
            foreach (var p in _plataforms)
            {
                p.Top -= DataGame.speedPlataform;
                
                //si el codigo de plataforma coincide con el del corazon, el corazon se ira con esa plataforma
                foreach (var l in lifes)
                {
                    if (p.codPlataform == l.codPlataform)
                    {
                        l.Top = p.Top - l.Height;
                    }
                }

            }

            //se crea una nueva plataforma si se pasa de un limite
            if (_plataforms.Count > 0)
            {
                if (_plataforms[_plataforms.Count - 1].Location.Y < Height - DataGame.distancePlataform)
                {
                    LoadPlataforms();
                }
            }

            //si salen de la pantalla se eliminan
            if (_plataforms.Count > 0)
            {
                for (int i = 0; i < _plataforms.Count - 1; i++)
                {
                    if (_plataforms[i].Location.Y < 0)
                    {
                        Controls.Remove(_plataforms[i]);
                        _plataforms.Remove(_plataforms[i]);
                    }
                }
            }
            
            //aumentan los puntos del jugador cada certo tiempo
            DataGame.time++;

            if (DataGame.time == 10)
            {
                DataGame.timePlayer++;
                lblscorePlayer.Text = "Tiempo: " + DataGame.timePlayer;

                DataGame.time = 0;
            }

            //aumenta la velocidad de las plataformas
            if (DataGame.timePlayer % 60 == 0 && DataGame.time == 0)
                DataGame.speedPlataform += 3;

            //se eliminan las vidas 
            if (lifes.Count > 0)
            {
                
                foreach (var l in lifes)
                {
                    //se eliminan si el jugador las toma
                    if (player.Bounds.IntersectsWith(l.Bounds))
                    {
                        Controls.Remove(l);
                        lifes.Remove(l);

                        if (DataGame.lifesPlayer < 3)
                        {
                            DataGame.lifesPlayer++;
                            UpdateLifes();
                        }
                        return;
                    }

                    //se eliminan si salen de la pantalla
                    if (l.Top <= 0)
                    {
                        Controls.Remove(l);
                        lifes.Remove(l);
                        return;
                    }
                }
            }
        }

        //se cargan los picturebox de las plataformas
        private void LoadPlataforms()
        {

            Plataform plataform = new Plataform();

            //se le asigna un codigo a la plataforma correlativo al de la plataforma anterior
            if (_plataforms.Count > 0)
            {
                plataform.codPlataform = _plataforms[_plataforms.Count - 1].codPlataform + 1;
            }

            //tamaño de la plataforma
            plataform.Height = 20;
            plataform.Width = 85;

            //se setea la posicion que tendra la plataforma en pantalla
            int locationPlataform = DataGame.PositionPlataform();
            
            switch (locationPlataform)
            {
                case 1: plataform.location = fireUp.Left; break;
                case 2: plataform.location = fireUp.Left + plataform.Width; break;
                case 3: plataform.location = fireUp.Left + (plataform.Width * 2); break;
                case 4: plataform.location = fireUp.Left + (plataform.Width * 3); break;
                case 5: plataform.location = fireUp.Left + (plataform.Width * 4); break;
                case 6: plataform.location = fireUp.Left + (plataform.Width * 5); break;
                case 7: plataform.location = fireUp.Left + (plataform.Width * 6); break;
                case 8: plataform.location = fireUp.Left + (plataform.Width * 7); break;
            }

            plataform.Left = plataform.location;
            plataform.Top = Height - 10;

            int numImg = 0;

            if (DataGame.contPlataform == 3)
            {
                numImg = 2;
                DataGame.contPlataform = 0;
            }
            else
                numImg = 1;

            //se le pone el tag a la plataforma
            switch (numImg)
            {
                case 1: plataform.Tag = "normal"; break;
                case 2: plataform.Tag = "peligrosa"; break;
            }

            //img plataforma
            plataform.Image = Image.FromFile("../../Sprites/plataform" + numImg + ".png");
            plataform.SizeMode = PictureBoxSizeMode.StretchImage;
            
            //se crea una vida con la plataforma, cada 10 plataformas
            if (DataGame.contPlataformLife == 10 && plataform.Tag == "normal")
            {
                CreateLive(plataform.Top, plataform.Width, plataform.Left, plataform.codPlataform);
                plataform.aLife = true;
                
                DataGame.contPlataformLife = 0;
            }
            
            //se reinica el cont de plataformas siempre que llega a 10
            if(DataGame.contPlataformLife == 10 && plataform.Tag == "peligrosa")
                DataGame.contPlataformLife = 0;

            _plataforms.Add(plataform);
            
            Controls.Add(plataform);

            //contador de plataforma
            DataGame.contPlataform++;
            DataGame.contPlataformLife++;
        }

        //timer pelota baja
        private void timer2_Tick(object sender, EventArgs e)
        {
            //si la pelota no esta tocando ninguna plataforma, baja
            if (DataGame.playerDown)
            {
                player.Top += DataGame.speedPlayer;
            }

            foreach (var plataform in _plataforms)
            {
                //choque pelota plataforma
                if (player.Bounds.IntersectsWith(plataform.Bounds))
                {
                    //si choca con una peligrosa, pierde vida y si son 0, pierde el la partida
                    if (plataform.Tag.Equals("peligrosa"))
                    {
                        //si la tregua es false, perdera vida sino no, hasta que se posicione en una plataforma normal
                        if (!DataGame.Truce)
                        {
                            DataGame.lifesPlayer--;
                            UpdateLifes();

                            if (DataGame.lifesPlayer <= 0)
                                GameOver();

                            RestartPlayer();
                            return;
                        }
 
                    }
                    else
                    {
                        //si la plataforma no era peligrosa, se queda en ella tomando sus coordenadas
                        DataGame.playerDown = false;
                        player.Top = plataform.Top - player.Height - 10;
                        DataGame.Truce = false;
                    }
                   
                }
                else
                {
                    DataGame.playerDown = true;
                }
                   
            }

            //la pelota choca con el fuego (limites inferior o superior de la pantalla)
            if (player.Bounds.IntersectsWith(fireDown.Bounds) || player.Bounds.IntersectsWith(fireUp.Bounds) ||
                player.Left < wallLeft.Left || player.Left > wallRight.Left)
            {
                DataGame.lifesPlayer--;
                UpdateLifes();
                        
                if(DataGame.lifesPlayer <= 0)
                    GameOver();

                RestartPlayer();
                
            }

        }

        //evento de presionar tecla para mover la pelota
        private void BallDown_KeyDown(object sender, KeyEventArgs e)
        {
            //mover la pelota con las flechas
            if (e.KeyCode == Keys.Right)
            {
                if(player.Left <= wallRight.Left - 50 && !DataGame.pause)
                    player.Left += DataGame.movePlayer;
            }
            if (e.KeyCode == Keys.Left)
            {
                if(player.Location.X > 500 && !DataGame.pause)
                    player.Left -= DataGame.movePlayer;
            }
            
            //mover pelota con las teclas A y D
            if (e.KeyCode == Keys.D)
            {
                if(player.Location.X <= wallRight.Left - 50 && !DataGame.pause)
                    player.Left += DataGame.movePlayerSlow;
            }
            
            if (e.KeyCode == Keys.A)
            {
                if(player.Location.X > 500 && !DataGame.pause)
                    player.Left -= DataGame.movePlayerSlow;
            }

            //tecla para pausar el juego
            if (e.KeyCode == Keys.Space)
            {
                if (!DataGame.pause)
                {
                    Pause(0);
                    DataGame.pause = true;
                }

                else
                {
                    Pause(1);
                    DataGame.pause = false;
                }
            }

            //tecla para cambiar color al fondo
            if (e.KeyCode == Keys.P)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                    BackColor = colorDialog1.Color;
            }

            //tecla para cambiar musica de fondo
            if (e.KeyCode == Keys.M)
            {
                if (DataGame.mainMusic)
                {
                    ChangeMusic(0);
                    DataGame.mainMusic = false;
                }
                else
                {
                    ChangeMusic(1);
                    DataGame.mainMusic = true;
                }
            }
        }

        //se cargan los obstaculos (las img de fuego de los limites superior e inferior)
        private void LoadFire()
        {
            fireDown = new PictureBox();
            fireUp = new PictureBox();

            int pHeight = 20;
            int pWidth = (Width / 2) - 100;

            //tamaño
            fireDown.Height = fireUp.Height = pHeight;
            fireDown.Width = fireUp.Width = pWidth;

            //sus ubicaciones
            fireDown.Left = fireUp.Left = (Width / 2) - fireDown.Width / 2;
            fireDown.Top = Height - 55;
            fireUp.Top = score.Top + score.Height;
            
            //se setean sus imagenes
            fireDown.Image = Image.FromFile("../../Sprites/fire.png");
            fireDown.SizeMode = PictureBoxSizeMode.StretchImage;
            
            fireUp.Image = Image.FromFile("../../Sprites/fire2.png");
            fireUp.SizeMode = PictureBoxSizeMode.StretchImage;

            fireDown.BackColor = fireUp.BackColor = Color.Transparent;
            
            //se añaden al control o ventana
            Controls.Add(fireDown);
            Controls.Add(fireUp);
        }

        //metodo de termina el juego
        private void GameOver()
        {
            try
            {
                
                //se detienen los timer
                timer1.Stop();
                timer2.Stop();
                musicBack.Stop();

                //si selecciona volver a jugar reinicia el juego, sino, sale al menu principal
                if (MessageBox.Show("Perdiste. " + lblscorePlayer.Text + "seg. Volver a jugar?", 
                    "Game Over", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    //se reinicia todo y empieza de nuevo
                    musicBack.PlayLooping();

                    DataGame.timePlayer = 0;
                    lblscorePlayer.Text = "Tiempo: " + DataGame.timePlayer;
                
                    DataGame.lifesPlayer = 3;

                    UpdateLifes();
                    RestartPlayer();
                
                    timer1.Start();
                    timer2.Start();
                }
                else
                {
                    //se reinicia todo y vuelve al menu
                    DataGame.timePlayer = 0;
                    lblscorePlayer.Text = "Tiempo: " + DataGame.timePlayer;
                
                    DataGame.lifesPlayer = 3;
                
                    UpdateLifes();
                    RestartPlayer();
                
                    mainMusic.PlayLooping();
                    Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Algo salio mal, cierre la aplicacion y vuelva a entrar");
            }
            
        }
        
        //metodo de pause
        private void Pause(int n)
        {
            if (n == 0)
            {
                timer1.Stop();
                timer2.Stop();
                musicBack.Stop();
            }
            else
            {
                timer1.Start();
                timer2.Start();
                musicBack.PlayLooping();
            }
        }

        //cargar los sprites de las paredes
        private void LoadWall()
        {
            wallLeft = new PictureBox();
            wallRight = new PictureBox();

            //tamaños
            wallLeft.Height = wallRight.Height = Height;
            wallLeft.Width = wallRight.Width = 30;

            //ubicaciones
            wallLeft.Top = wallRight.Top = 0;
            wallLeft.Left = fireDown.Left - 30;
            wallRight.Left = fireDown.Left + fireDown.Width;
            
            //imgs
            wallLeft.Image = wallRight.Image = Image.FromFile($"../../Sprites/{DataGame.wall}.png");
            wallLeft.SizeMode = wallRight.SizeMode = PictureBoxSizeMode.StretchImage;

            Controls.Add(wallLeft);
            Controls.Add(wallRight);

        }

        //se carga el panel de puntuaciones
        private void LoadPanel()
        {
            score = new Panel();
            
            // Setear elementos del panel
            score.Width = Width / 2 - 100;
            score.Height = (int)(Height * 0.05);

            score.Top = 0;
            score.Left = (Width / 2) - score.Width / 2;

            score.BackColor = Color.BlueViolet;
            
            //corazones de vidas arreglo
            hearts = new PictureBox[DataGame.lifesPlayer];

            //se crean los corazones de vida que tendra el jugador
            for (int i = 0; i < DataGame.lifesPlayer; i++)
            {
                hearts[i] = new PictureBox();
                
                hearts[i].Height = hearts[i].Width = score.Height; //tamaño
                
                //img
                hearts[i].BackgroundImage = Image.FromFile("../../Sprites/life.png");
                hearts[i].BackgroundImageLayout = ImageLayout.Stretch;

                hearts[i].Top = 0;
                hearts[i].Left = i * (hearts[i].Width + 2);
            }

            //instanciando el label del puntaje
            lblscorePlayer = new Label();

            lblscorePlayer.ForeColor = Color.White;

            lblscorePlayer.Text = "Tiempo: " + DataGame.timePlayer;
            
            //fuente y alineado
            lblscorePlayer.Font = new Font("Microsoft YaHei", 16F);
            lblscorePlayer.TextAlign = ContentAlignment.MiddleRight;

            //tamaño y posicion
            lblscorePlayer.Width = 250;
            lblscorePlayer.Height = score.Height;
            
            lblscorePlayer.Left = score.Width - lblscorePlayer.Width;
            
            //se añaden al control 
            score.Controls.Add(lblscorePlayer);

            foreach (var h in hearts)
            {
                score.Controls.Add(h);
            }
            
            Controls.Add(score);
        }
        
        //crea un corazon, recibiendo los datos y codigo de la plataforma donde se posicionara
        private void CreateLive(int top, int width, int left, int cod)
        {
            LifesClass life = new LifesClass();

            //codigo plataforma del corazon = cod de la plataforma
            life.codPlataform = cod;

            //tamaño y ubicacion
            life.Height = life.Width = 20;

            life.Left = left + (width / 2);
            life.Top = top - life.Height;
            
            //img
            life.Image = Image.FromFile("../../Sprites/life.png");
            life.SizeMode = PictureBoxSizeMode.StretchImage;
            life.BackColor = Color.Transparent;
            
            lifes.Add(life);
            Controls.Add(life);
        }

        //metodo que va actualizando las vidas a medida las agarra o pierte el jugador
        private void UpdateLifes()
        {
            //se eliminan los pb de los corazones del form
            foreach (var h in hearts)
            {
                score.Controls.Remove(h);
            }
            //se vacia el arreglo
            hearts = null;
            
            //se vuelve a instanciar el arreglo
            hearts = new PictureBox[DataGame.lifesPlayer];
            
            //se crean los corazones de vida que tendra el jugador
            for (int i = 0; i < DataGame.lifesPlayer; i++)
            {
                hearts[i] = new PictureBox();

                //tamaño
                hearts[i].Height = hearts[i].Width = score.Height;
                
                //img
                hearts[i].BackgroundImage = Image.FromFile("../../Sprites/life.png");
                hearts[i].BackgroundImageLayout = ImageLayout.Stretch;

                //posicion
                hearts[i].Top = 0;
                hearts[i].Left = i * (hearts[i].Width + 2);
            }
            
            foreach (var h in hearts)
            {
                score.Controls.Add(h);
            }
        }

        //reinicia el jugador desde su posicion inicial al perder una vida
        private void RestartPlayer()
        {
            //se coloca el jugador en una posicion random
            /*Random r = new Random();
             int left = r.Next(fireUp.Left + 1, fireUp.Left + fireUp.Width);*/

            DataGame.Truce = true;

            player.Top = fireUp.Top + (fireUp.Height * 5);
            player.Left = fireUp.Left + (fireUp.Width / 2);

            //se le setea una img random
            player.Image = Image.FromFile($"../../Sprites/{DataGame.ball + DataGame.ImgBall()}.png");
            player.SizeMode = PictureBoxSizeMode.StretchImage;
            player.BackColor = Color.Transparent;
        }

        //metodo para cambiar musica de fondo
        private void ChangeMusic(int n)
        {
            if (n == 0)
            {
                musicBack = new SoundPlayer("../../Sounds/piano.wav");
                musicBack.PlayLooping();
            }
            else
            {
                musicBack = new SoundPlayer("../../Sounds/zelda.wav");
                musicBack.PlayLooping();
            }
                
        }
        
    }
}