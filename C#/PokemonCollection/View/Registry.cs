using System;
using System.Windows.Forms;

namespace PokemonCollection
{
    public partial class Registry : Form
    {
        public Registry()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 2;
            progressBar1.PerformStep(); //se empieza a llenar la barra

            if (progressBar1.Value >= 100)
            {
                timer1.Enabled = false;
                MessageBox.Show("Ha sido registrado correctamente!", "Exito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                
                Login l = new Login();
                l.Show();
                Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals("") || txtPassword.Text.Equals("") || txtVerify.Text.Equals(""))
            {
                MessageBox.Show("No deje campos vacios!", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtPassword.Text.Equals(txtVerify.Text))
            {
                timer1.Enabled = true;
                progressBar1.Visible = true;
                lblLoading.Visible = true;

                try
                {  //se crea el nuevo usuario y se añade a la BDD
                    Coach c = new Coach(txtName.Text,txtPassword.Text,15,10,1000,0,0);
                
                    CoachDAO.AddCoach(c);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un problema inesperado!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden!", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            Hide();
        }
    }
}