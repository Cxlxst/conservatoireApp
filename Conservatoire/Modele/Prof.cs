using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.Modele
{
    public class Prof
    {
        //Déclaration des attributs privés de la classe Prof
        private int ID;
        private string NOM;
        private string PRENOM;
        private string TEL;
        private string MAIL;
        private string ADRESSE;
        private string INSTRUMENT;
        private float SALAIRE;

        //Constructeur
        public Prof(int id, string nom, string prenom, string tel, string mail, string adresse, string instrument, float salaire)
        {
            this.ID = id;
            this.NOM = nom;
            this.PRENOM = prenom;
            this.TEL = tel;
            this.MAIL = mail;
            this.ADRESSE = adresse;
            this.INSTRUMENT = instrument;
            this.SALAIRE = salaire;
        }

        public int getID { get => ID; set => ID = value; }
        public string getNOM { get => NOM; set => NOM = value; }
        public string getPRENOM { get => PRENOM; set => PRENOM = value; }
        public string getTEL { get => TEL; set => TEL = value; }
        public string getMAIL { get => MAIL; set => MAIL = value; }
        public string getADRESSE { get => ADRESSE; set => ADRESSE = value; }
        public string getINSTRUMENT { get => INSTRUMENT; set => INSTRUMENT = value; }
        public float getSALAIRE { get => SALAIRE; set => SALAIRE = value; }

        public override string ToString()
        {
            return (this.NOM + " " + this.PRENOM + "  ·  " + this.INSTRUMENT + "  ·  Mail: " + this.MAIL + "  Tel: " + this.TEL + "  Adresse: " + this.ADRESSE + "  Salaire: " + this.SALAIRE);
        }

    }
}
