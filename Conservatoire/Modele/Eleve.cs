using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.Modele
{
    public class Eleve
    {
        //Déclaration des attributs privés de la classe Eleve
        private int ID;
        private string NOM;
        private string PRENOM;
        private string TEL;
        private string MAIL;
        private string ADRESSE;
        private int BOURSE;

        //Constructeur
        public Eleve(int id, string nom, string prenom, string tel, string mail, string adresse, int bourse)
        {
            this.ID = id;
            this.NOM = nom;
            this.PRENOM = prenom;
            this.TEL = tel;
            this.MAIL = mail;
            this.ADRESSE = adresse;
            this.BOURSE = bourse;
        }

        public Eleve(int id, string nom, string prenom, string tel, string mail, string adresse)
        {
            this.ID = id;
            this.NOM = nom;
            this.PRENOM = prenom;
            this.TEL = tel;
            this.MAIL = mail;
            this.ADRESSE = adresse;
        }

        public int getID { get => ID; set => ID = value; }
        public string getNOM { get => NOM; set => NOM = value; }
        public string getPRENOM { get => PRENOM; set => PRENOM = value; }
        public string getTEL { get => TEL; set => TEL = value; }
        public string getMAIl { get => MAIL; set => MAIL = value; }
        public string getADRESSE { get => ADRESSE; set => ADRESSE = value; }
        public int getBOURSE { get => BOURSE; set => BOURSE = value; }

        public override string ToString()
        {
            return (this.NOM + " " + this.PRENOM + "  ·  Bourse: " + this.BOURSE + "€  Mail : " + this.MAIL + "  Tel: " + this.TEL + "  Adresse : " + this.ADRESSE);
        }

    }
}
