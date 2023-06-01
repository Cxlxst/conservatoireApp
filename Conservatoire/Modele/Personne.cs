using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.Modele
{
    internal class Personne
    {
        //Déclaration des attributs privés de la classe Personne
        private int id;
        private char nom;
        private char prenom;
        private int tel;
        private char mail;
        private char adresse;

        //Constructeur
        public Personne(int id, char nom, char prenom, int tel, char mail, char adresse)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.tel = tel;
            this.mail = mail;
            this.adresse = adresse;
        }
    }
}
