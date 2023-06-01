using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Conservatoire.Modele
{
    public class Seance
    {
        //Déclaration des attributs privés de la classe Seance
        private int IDPROF;
        private int NUMSEANCE;
        private string TRANCHE;
        private string JOUR;
        private int NIVEAU;
        private int CAPACITE;

        //Constructeur
        public Seance(int idProf, int numSeance, string tranche, string jour, int niveau, int capacite)
        {
            this.IDPROF = idProf;
            this.NUMSEANCE = numSeance;
            this.TRANCHE = tranche;
            this.JOUR = jour;
            this.NIVEAU = niveau;
            this.CAPACITE = capacite;
        }
        public int getIDPROF { get => IDPROF; set => IDPROF = value; }
        public int getNUMSEANCE { get => NUMSEANCE; set => NUMSEANCE = value; }
        public string getTRANCHE { get => TRANCHE; set => TRANCHE = value; }
        public string getJOUR { get => JOUR; set => JOUR = value; }
        public int getNIVEAU { get => NIVEAU; set => NIVEAU = value; }
        public int getCAPACITE { get => CAPACITE; set => CAPACITE = value; }

        public override string ToString()
        {
            return ("Séance n°" + this.NUMSEANCE + "  le " + this.JOUR + ", " + this.TRANCHE + "  ·  ID Prof: " + this.IDPROF + "   Niveau: " + this.NIVEAU + "   Cap. max: " + this.CAPACITE);
        }
    }
}
