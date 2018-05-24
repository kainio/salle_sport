using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_Sport
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "test" && textBox2.Text == "test")
            {
                Index f = new Index();
                f.Show();
            }
            else 
            {
                MessageBox.Show("Le nom d'utilisateur ou le mot de passe ne correspond pas");
            }
            textBox2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Nom d'utilisateur:\ttest\nMot de passe:\ttest", "Coordonnées de connexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
