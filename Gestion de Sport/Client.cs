using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Gestion_de_Sport
{
    [Serializable]
    public class Client
    {
         private string _nom;
         private string _prenom;
         private string _cin;
         private DateTime _datenaissance;
         private string _sport;
         private string _sexe;
         private DateTime _dateinscription;
         private int _numeroinscription; 
         
     public Client()
        {
             this._nom = "";
             this._prenom = "";
             this._cin = "";
             this._datenaissance = DateTime.Now;
             this._sport = "";
             this._sexe = "";
             this._dateinscription = DateTime.Now;
             this._numeroinscription = 0;
         }

        public Client(string nom,string prenom,string cin,DateTime daten,string sport,string sexe,DateTime datei)
        {
            this._nom = nom;
            this._prenom = prenom;
            this._cin = cin;
            this._datenaissance = daten;
            this._sport = sport;
            this._sexe = sexe;
            this._dateinscription = datei;
            this._numeroinscription = NbrClients;
            NbrClients++;
        }

        public static int NbrClients
        {
            get 
            {
                StreamReader st = new StreamReader(@"clients\nbrClients.txt");
                string ligne = st.ReadLine();
                st.Close();
                return int.Parse(ligne);
            }

            set
            {
                StreamWriter st = new StreamWriter(@"clients\nbrClients.txt");
                st.WriteLine(value);
                st.Close();
            }

        }
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public string Cin
        {
            get { return _cin; }
            set { _cin = value; }
        }
        
        public DateTime Datenaissance
        {
            get { return _datenaissance ; }
            set { _datenaissance = value; }
        }

        public string Sport
        {
            get { return this._sport; }
            set { this._sport = value; }
        }

        public string Sexe
        {
            get { return this._sexe; }
            set { this._sexe = value; }
        }

        public DateTime Dateinscription
        {
            get { return this._dateinscription; }
            set { this._dateinscription = value; }
        }

        public int Numeroinscription
        {
            get { return this._numeroinscription; }
            set { this._numeroinscription = value; }
        }

        public void Serialisation(string nomfichier)
        {
            FileStream fichier = File.Open(nomfichier, FileMode.Create);
            XmlSerializer s = new XmlSerializer(typeof(Client));
            s.Serialize(fichier, this);
            fichier.Close();
        }

        public static Client Deserialisation(string nomfichier)
        {
            FileStream fichier = File.Open(nomfichier, FileMode.OpenOrCreate);
            XmlSerializer s = new XmlSerializer(typeof(Client));
            Client c = (Client)s.Deserialize(fichier);
            fichier.Close();

            return c;
        }

    }
}
