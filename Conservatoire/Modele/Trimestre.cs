using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.Modele
{
    public class Trimestre
    {
        private int IDELEVE;
        private string LIBELLE;
        private string DATEFIN;
        private string DATEPAIEMENT;
        private int PAYE;

        public Trimestre(string libelle, string dateFin)
        {
            this.LIBELLE = libelle;
            this.DATEFIN = dateFin;
        }

        public Trimestre(int idEleve, string libelle, string datePaiement)
        {
            this.IDELEVE = idEleve;
            this.LIBELLE = libelle;
            this.DATEPAIEMENT = datePaiement;
            this.PAYE = 0;
        }

        public string getLIBELLE { get => LIBELLE; set => LIBELLE = value;}
        public string getDATEFIN { get => DATEFIN; set => DATEFIN = value;}
        public int getIDELEVE { get => IDELEVE; set => IDELEVE = value;}
        public string getDATEPAIEMENT { get => DATEPAIEMENT; set => DATEPAIEMENT = value;}
        public int getPAYE { get => PAYE; set => PAYE = value; }

        public override string ToString()
        {
            if(this.DATEPAIEMENT != null)
            {
                return (this.LIBELLE + " payé le : " + this.DATEPAIEMENT);
            }
            else
            {
                return (this.LIBELLE + " à payer avant le : " + this.DATEFIN);
            }
            
        }


    }


}
