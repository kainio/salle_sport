using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Gestion_de_Sport
{
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
        }

        private void vider()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClient fc = new FormClient();
            fc.ShowDialog(this);
        }

        private void personnelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonnel fc = new FormPersonnel();
            fc.ShowDialog(this);
        }

        //Ajouter
        private void button1_Click(object sender, EventArgs e)
        {
            Client c = new Client(textBox1.Text, textBox2.Text,textBox3.Text,dateTimePicker1.Value,comboBox1.Text,comboBox2.Text, dateTimePicker2.Value);
            c.Serialisation("clients\\"+ c.Numeroinscription.ToString() + ".xml");
            MessageBox.Show("Client Ajoute");

        }

        //Rechercher
        private void button5_Click(object sender, EventArgs e)
        {
            int ni = 0;
            try
            {
                ni = int.Parse(textBox4.Text);
            } catch(Exception ex)
            {
                errorProvider1.SetError(textBox4, ex.Message);
            }

            try
            {
                Client c = Client.Deserialisation("clients\\" + ni.ToString() + ".xml");
                textBox1.Text = c.Nom;
                textBox2.Text = c.Prenom;
                textBox3.Text = c.Cin;
                dateTimePicker1.Value = c.Datenaissance;
                comboBox1.Text = c.Sport;
                comboBox2.Text = c.Sexe;
                dateTimePicker2.Value = c.Dateinscription;
            } catch(Exception)
            {
                MessageBox.Show("Client introuvable");
            }
        }

        //modifier
        private void button3_Click(object sender, EventArgs e)
        {
            int ni = 0;
            try
            {
                ni = int.Parse(textBox4.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox4, ex.Message);
            }

            
            try
            {
                Client c = Client.Deserialisation("clients\\" + ni.ToString() + ".xml");
                c.Nom = textBox1.Text;
                c.Prenom = textBox2.Text;
                c.Cin = textBox3.Text;
                c.Datenaissance = dateTimePicker1.Value;
                c.Sport = comboBox1.Text;
                c.Sexe = comboBox2.Text;
                c.Dateinscription = dateTimePicker2.Value;
                c.Numeroinscription = int.Parse(textBox4.Text);
                c.Serialisation(@"clients\" + ni.ToString() + ".xml");
                MessageBox.Show("les informations du client ont été modifié avec succés");
 
            } catch(Exception)
            {
                MessageBox.Show("Client introuvable");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Supprimer
        private void button2_Click(object sender, EventArgs e)
        {
            int ni = 0;
            try
            {
                ni = int.Parse(textBox4.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox4, ex.Message);
            }
            DialogResult réponse = MessageBox.Show("Êtes-vous sûre de vouloir supprimer le client numéro " + ni, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (réponse == DialogResult.Yes)
            {
                try
                {
                    Client c = Client.Deserialisation("clients\\" + ni.ToString() + ".xml");

                    if (File.Exists(@"clients\" + ni.ToString() + ".xml"))
                    {
                        File.Delete(@"clients\" + ni.ToString() + ".xml");
                        //Client.NbrClients--;
                        MessageBox.Show("Le client a été supprimé");
                        vider();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Client introuvable");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Recherchez avec le numéro d'inscription", "Astuce", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        
    }
}
