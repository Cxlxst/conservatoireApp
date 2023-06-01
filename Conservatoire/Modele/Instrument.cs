using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.Modele
{
    public class Instrument
    {
        string LIBELLE;

        public Instrument(string libelle)
        { 
            this.LIBELLE = libelle;
        }

        public string getLIBELLE { get => LIBELLE; set => LIBELLE = value; }


        public override string ToString()
        {
            return (this.LIBELLE);
        }

    }
}
