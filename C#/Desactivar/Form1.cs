using System;
using System.Media;
using System.Windows.Forms;

namespace Desactivar
{
    public partial class Form1 : Form
    {
        SoundPlayer sonido, sonidoFondo;
        private bool musicaFondo = false;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sonido = new SoundPlayer(Application.StartupPath + @"\son\beep1.wav");
                sonido.Play();
                MessageBox.Show(info(), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal :(", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        public string info()
        {
            return "Creador: Alex Flores.\nDesactiva la bomba descifrando el codigo\nantes que termine el tiempo...\n" +
                   "Podras?";
        }

        //botton jugar
        private void button1_Click(object sender, EventArgs e)
        {
            sonido = new SoundPlayer(Application.StartupPath + @"\son\beep2.wav");
            sonido.Play();
            Deactivate d = new Deactivate();
            d.Show();
            Hide();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                musicaFondo = true;
                sonidoFondo = new SoundPlayer(Application.StartupPath + @"\son\piano.wav");
                sonidoFondo.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal :(", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(musicaFondo)
                sonidoFondo.Stop();
            else
                MessageBox.Show("No hay musica de fondo", "Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
        }
    }
}