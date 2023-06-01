using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conservatoire.Controleur;
using Conservatoire.Modele;
using Google.Protobuf.WellKnownTypes;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Conservatoire.Vue
{
    public partial class paiementsEleve : Form
    {
        Mgr elManager = new Mgr();
        List<Trimestre> listTrimestresEleve = new List<Trimestre>();
        public paiementsEleve(int idEleve)
        {
            InitializeComponent();
            List<Trimestre> listTrimestresEleve = elManager.recupTrimestre(idEleve);
            
            listBox1.DataSource = null;
            listBox1.DataSource = listTrimestresEleve;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            this.Close();
        }


   
    }
}
