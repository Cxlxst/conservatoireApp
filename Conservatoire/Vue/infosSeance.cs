using Conservatoire.Controleur;
using Conservatoire.DAL;
using Conservatoire.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conservatoire.Vue
{
    public partial class infosSeance : Form
    {
        Mgr elManager = new Mgr();
        Seance laSeance;
        public infosSeance()
        {
            InitializeComponent();
        }
        public infosSeance(Seance seance)
        {
            InitializeComponent();
            laSeance = seance;
            int idSeance = seance.getNUMSEANCE;

            List<Eleve> listElevesSeance = elManager.recupEleveSeance(idSeance);
            listBox1.DataSource = listElevesSeance;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ajoutEleveSeance aES = new ajoutEleveSeance(laSeance);
            aES.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Eleve eleve = (Eleve)listBox1.SelectedItem;
            int idEleve = eleve.getID;
            int idSeance = laSeance.getNUMSEANCE;

            elManager.suppEleveSeance(idEleve, idSeance);
            MessageBox.Show("Suppression effectuée");
        }
    }
}
