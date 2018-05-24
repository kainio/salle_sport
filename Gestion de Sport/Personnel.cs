using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gestion_de_Sport
{
    [Serializable]
    public class Personnel
    {
         private int _id;
         private string _matricule;
         private string _nom;
         private string _prenom;
         private DateTime _datenaissance;
         private string _discipline;

        public Personnel()
        {
             this.Id = 0;
             this.Matricule = "";
             this.Nom = "";
             this.Prenom = "";
             this.Discipline = "";
             this.Datenaissance = DateTime.Now;
         }

        public Personnel(string mat, string nom, string prenom, DateTime datenaissance, string discipline)
        {
            this.Matricule = mat;
            this.Id = NbrPersonnels;
            NbrPersonnels++;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Datenaissance = datenaissance;
            this.Discipline = discipline;
        }

        public static int NbrPersonnels
        {
            get
            {
                StreamReader st = new StreamReader(@"personnels\nbrPersonnels.txt");
                string ligne = st.ReadLine();
                st.Close();
                return int.Parse(ligne);
            }

            set
            {
                StreamWriter st = new StreamWriter(@"personnels\nbrPersonnels.txt");
                st.WriteLine(value);
                st.Close();
            }

        }

        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string Matricule
        {
            get { return this._matricule; }
            set { this._matricule = value; }
        }
        
        public string Nom
        {
            get { return this._nom; }
            set { this._nom = value; }
        }

        public string Prenom
        {
            get { return this._prenom; }
            set { this._prenom = value; }
        }


        public string Discipline
        {
            get { return this._discipline; }
            set { this._discipline = value; }
        }

        public DateTime Datenaissance
        {
            get { return this._datenaissance; }
            set { this._datenaissance = value; }
        }

        public void Serialisation(string nomfichier)
        {
            FileStream fichier = File.Open(nomfichier, FileMode.OpenOrCreate);
            BinaryFormatter s = new BinaryFormatter();
            s.Serialize(fichier, this);
            fichier.Close();
        }

        public static Personnel Deserialisation(string nomfichier)
        {
            FileStream fichier = File.Open(nomfichier, FileMode.OpenOrCreate);
            BinaryFormatter s = new BinaryFormatter();
            Personnel p = (Personnel)s.Deserialize(fichier);
            fichier.Close();
            return p;
        }

    }
}
