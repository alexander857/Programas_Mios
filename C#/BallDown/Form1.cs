using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace BallDown
{
    public partial class Form1 : Form
    {
        private SoundPlayer musicMenu;
        public Form1()
        {
            InitializeComponent();
            musicMenu = new SoundPlayer("../../Sounds/mario.wav");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            musicMenu.PlayLooping();
            
            BackgroundImage = Image.FromFile("../../Sprites/fondo.png");
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        //boton de jugar
        private void btnPlay_Click(object sender, EventArgs e)
        {
            musicMenu.Stop();
            BallDown game = new BallDown();
            game.ShowDialog();
        }

        //boton info
        private void btnInfo_Click(object sender, EventArgs e)
        {
            string message = "A: moverte despacio a la izquierda\nD: moverte despacio a la derecha\nFlecha izquierda:" +
                             " moverte a la izquierda\nFlecha derecha: moverte a la derecha\nEspacio: pausa/seguir\n" +
                             "P: cambiar color de fondo\nM: cambiar musica de fondo.";

            MessageBox.Show(message, "Informacion para jugara BallDown V1.0", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}