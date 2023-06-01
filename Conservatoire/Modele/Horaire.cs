using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.Modele
{
    public class Horaire
    {
        string TRANCHE;

        public Horaire(string tranche)
        {
            this.TRANCHE = tranche;
        }

        public string getTRANCHE { get => TRANCHE; set => TRANCHE = value; }

        public override string ToString()
        {
            return (this.TRANCHE);
        }
    }
}
