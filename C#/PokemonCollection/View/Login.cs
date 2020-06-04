using System;
using System.Windows.Forms;

namespace PokemonCollection
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //se cierra la ventana
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        private void Login_Load(object sender, EventArgs e)
        {
            FillComboCoach();
        }

        public void FillComboCoach()
        {
            cmbCoach.DataSource = null;
            cmbCoach.ValueMember = "password";
            cmbCoach.DisplayMember = "name";
            cmbCoach.DataSource = CoachDAO.getCoaches();
        }

        private void btnRegistry_Click(object sender, EventArgs e)
        {
            Registry registry = new Registry();
            registry.Show();
            Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(""))
            {
                MessageBox.Show("No deje campos vacios!", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtPassword.Text.Equals(cmbCoach.SelectedValue))
            {
                Coach c = (Coach) cmbCoach.SelectedItem;
                
                Form1 f = new Form1(c);
                f.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden!", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}