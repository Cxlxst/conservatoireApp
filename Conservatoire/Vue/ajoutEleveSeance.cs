using Conservatoire.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conservatoire.Modele;
using Conservatoire.Controleur;
using System.Management.Instrumentation;

namespace Conservatoire.Vue
{
    public partial class ajoutEleveSeance : Form
    {
        Mgr elManager = new Mgr();
        Seance laSeance;
        public ajoutEleveSeance(Seance seance)
        {
            InitializeComponent();
            string tranche = seance.getTRANCHE;
            string jour = seance.getJOUR;
            laSeance = seance;
            
            List<Eleve> listElevesDispo = elManager.listEleveDispo(tranche, jour);
            listBox1.DataSource = listElevesDispo;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idProf = laSeance.getIDPROF;
            Eleve eleve = (Eleve)listBox1.SelectedItem;
            int idEleve = eleve.getID;
            int idSeance = laSeance.getNUMSEANCE;
            elManager.ajoutEleveSeance(idProf, idEleve, idSeance);
            MessageBox.Show("Inscription validée");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
