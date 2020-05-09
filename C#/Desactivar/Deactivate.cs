using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Desactivar
{
    public partial class Deactivate : Form
    {
        private SoundPlayer sonido;
        private int intentos, numSecreto, pistas;
        private string clave;
        private bool pistaDesbloqueada = false;
        public Deactivate()
        {
            intentos = 0; clave = ""; numSecreto = 0;
            pistas = 1;
            InitializeComponent();
            numeroSecreto();
        }

        private void Deactivate_Load(object sender, EventArgs e)
        {
        }
        //funcion activa el sonido de los botones
        public void activarSonido()
        {
            try
            {
                sonido = new SoundPlayer(Application.StartupPath + @"\son\beep3.wav");
                sonido.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal :(", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public void agregarNumero(string numero)
        {
            clave += numero;
            label1.Text = clave;
        }

        public void numeroSecreto()
        {
            Random rand = new Random();
            numSecreto = rand.Next(100, 999);
            label4.Text = "Clave secreta: 3 digitos";
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            agregarNumero("1");
            activarSonido();
        }


        private void btn2_Click(object sender, EventArgs e)
        {
            agregarNumero("2");
            activarSonido();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            agregarNumero("3");
            activarSonido();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            agregarNumero("4");
            activarSonido();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            agregarNumero("5");
            activarSonido();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            agregarNumero("6");
            activarSonido();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            agregarNumero("7");
            activarSonido();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            agregarNumero("8");
            activarSonido();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            agregarNumero("9");
            activarSonido();
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            agregarNumero("0");
            activarSonido();
        }
        //boton para limpiar el label1
        private void btnC_Click(object sender, EventArgs e)
        {
            clave = "";
            label1.Text = "0";
            activarSonido();
        }
        //boton para borrar un caracter
        private void btnCE_Click(object sender, EventArgs e)
        {
            if (clave.Length >= 1)
                clave = clave.Substring(0, clave.Length - 1);
            if (clave.Length <= 0)
                label1.Text = "0";
            else
                label1.Text = clave;
            activarSonido();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                sonido = new SoundPlayer(Application.StartupPath + @"\son\beep1.wav");
                sonido.Play();

                intentos += 1;
                label3.Text = Convert.ToString(intentos);
                
                int claveSecreta = Convert.ToInt32(label1.Text);

                if (claveSecreta == numSecreto)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Desactivaste la bomba a los " + intentos + " intentos!",
                        "Felicidades!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    Form1 f = new Form1();
                    f.Show();
                    Hide();
                }
                else
                {
                    if (pistaDesbloqueada)
                    {
                        MessageBox.Show("Clave incorrecta!", "Error" + numSecreto, MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Clave incorrecta!", "Error", MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal :(", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                MessageBox.Show("Booom!!! La bomba exploto!","Perdiste!",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Form1 f = new Form1();
                f.Show();
                Hide();
            }
        }

        private void btnPista_Click(object sender, EventArgs e)
        {
            sonido = new SoundPlayer(Application.StartupPath + @"\son\beep1.wav");
            sonido.Play();
            
            if (pistas <= 0)
            {
                MessageBox.Show("No te quedan pistas!", "Aviso", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            else
            {
                pistas--;
                label5.Text = Convert.ToString(pistas);

                MessageBox.Show("Aqui tienes tu pista :D!", "Una pista", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                pistaDesbloqueada = true;
            }
            
        }
    }
}