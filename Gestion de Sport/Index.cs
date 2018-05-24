using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_Sport
{
    public partial class Index : Form
    {
        public Index()
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

        private void LoadData()
        {
            Thread.AllocateDataSlot();
            
            if(Client.NbrClients > 0)
            {
                for (int i = 0; i < Client.NbrClients; i++)
                {
                    try
                    {
                        Client c = Client.Deserialisation(@"clients\" + i + ".xml");
                        dataGridView1.Rows.Add(c.Numeroinscription, c.Nom, c.Prenom, c.Cin);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            if (Personnel.NbrPersonnels > 0)
            {
                for (int i = 0; i < Personnel.NbrPersonnels; i++)
                {
                    try
                    {
                        Personnel p = Personnel.Deserialisation(@"personnels\" + i + ".txt");
                        dataGridView2.Rows.Add(p.Matricule, p.Nom, p.Prenom, p.Discipline);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }
        private void Index_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            using (WaitForm frm = new WaitForm(LoadData))
            {
                frm.ShowDialog(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
