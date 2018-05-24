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
    public partial class FormPersonnel : Form
    {
        
        public FormPersonnel()
        {
            InitializeComponent();
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

        private void vider()
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        
        }

     
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //Ajouter
        private void button1_Click(object sender, EventArgs e)
        {

            Personnel p = new Personnel(textBox1.Text,textBox3.Text, textBox4.Text, dateTimePicker1.Value, comboBox1.Text);
            p.Serialisation("personnels\\" + p.Id.ToString() + ".txt");
            MessageBox.Show("Personnel Ajoute");
        }

        //Modifier
        private void button4_Click(object sender, EventArgs e)
        {
            string matricule_recherché = textBox1.Text;
            bool trouve = false;

            for (int i = 0; i < Personnel.NbrPersonnels; i++)
            {
                try
                {
                    Personnel p = Personnel.Deserialisation("personnels\\" + i.ToString() + ".txt");

                    if (p.Matricule == matricule_recherché)
                    {
                        trouve = true;
                        textBox1.Text = p.Matricule;
                        textBox3.Text = p.Nom;
                        textBox4.Text = p.Prenom;
                        dateTimePicker1.Value = p.Datenaissance;
                        comboBox1.Text = p.Discipline;
                        break;
                    }
                    else
                    {
                        continue;
                    }


                }
                catch (Exception)
                {
                    continue;
                }
            }

            if (trouve == false)
            {
                MessageBox.Show("Personnel introuvable");
            }
        }

        //Supprimer
        private void button3_Click(object sender, EventArgs e)
        {
            string matricule_recherché = textBox1.Text;
            bool trouve = false;
    
            DialogResult réponse = MessageBox.Show("Êtes-vous sûre de vouloir supprimer le personnel " + matricule_recherché, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (réponse == DialogResult.Yes)
            {
                for (int i = 0; i < Personnel.NbrPersonnels; i++)
                {
                    try
                    {
                        Personnel p = Personnel.Deserialisation("personnels\\" + i.ToString() + ".txt");

                        if (p.Matricule == matricule_recherché)
                        {
                            trouve = true;
                            if (File.Exists(@"personnels\" + i.ToString() + ".txt"))
                            {
                                File.Delete(@"personnels\" + i.ToString() + ".txt");
                                //Personnel.NbrPersonnels--;
                                MessageBox.Show("Le personnel a été supprimé");
                                vider();
                            }
                            break;
                        }
                        else
                        {
                            continue;
                        }


                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                if (trouve == false)
                {
                    MessageBox.Show("Personnel introuvable");
                }
            }
        }

        //Rechercher
        private void button2_Click(object sender, EventArgs e)
        {
            string matricule_recherché = textBox1.Text;
            bool trouve = false;

            for (int i = 0; i < Personnel.NbrPersonnels; i++)
            {
                try
                {
                    Personnel p = Personnel.Deserialisation("personnels\\" + i.ToString() + ".txt");

                    if (p.Matricule == matricule_recherché)
                    {
                        trouve = true;
                        p.Matricule = textBox1.Text;
                        p.Nom= textBox3.Text;
                        p.Prenom =textBox4.Text;
                        p.Datenaissance = dateTimePicker1.Value ;
                        p.Discipline = comboBox1.Text;
                        p.Serialisation(@"personnels\" + i + ".txt");
                        break;
                    }
                    else
                    {
                        continue;
                    }


                }
                catch (Exception)
                {
                    continue;
                }
            }

            if (trouve == false)
            {
                MessageBox.Show("Personnel introuvable");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void FormPersonnel_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Recherchez avec le matricule", "Astuce", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
