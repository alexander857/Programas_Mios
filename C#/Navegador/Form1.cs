using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ColoresFondo();
        }

        public void ColoresFondo()
        {
            cmbFondo.DataSource = new List<String>()
            {
                "Predeterminado","Azul","Rosado","Morado","Verde","Amarillo" 
            };
        }

        private void btnNavegar_Click(object sender, EventArgs e)
        {
            if (radGoogle.Checked)
                webZAOF.Url = new Uri("https://www.google.es/");
            
            else if (radMiURL.Checked && txtURL.Text.Length != 0)
                webZAOF.Url = new Uri(txtURL.Text);
            
            else
                MessageBox.Show("Seleccione una Web!", "Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            string azul = "#1b6ef5", rosado = "#fa1697", morado = "#d816fa", verde = "#0ed104", 
                amarillo = "#effa19";

            switch (cmbFondo.SelectedIndex)
            {
                case 0:
                    BackColor = Color.Empty;
                    break;
                case 1:
                    BackColor = ColorTranslator.FromHtml(azul);
                    break;
                case 2:
                    BackColor = ColorTranslator.FromHtml(rosado);
                    break;
                case 3:
                    BackColor = ColorTranslator.FromHtml(morado);
                    break;
                case 4:
                    BackColor = ColorTranslator.FromHtml(verde);
                    break;
                case 5:
                    BackColor = ColorTranslator.FromHtml(amarillo);
                    break;
            }
        }
    }
}