using Conservatoire.Controleur;
using Conservatoire.Modele;
using Org.BouncyCastle.Asn1;
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
    public partial class modifSeance : Form
    {
        Mgr elManager = new Mgr();
        Seance laSeance;
     

        public modifSeance(Seance seance)
        {
            InitializeComponent();
            laSeance = seance;
            int idSeance = seance.getNUMSEANCE;
            int idProf = seance.getIDPROF;
            string jour = seance.getJOUR;
            string horaire = seance.getTRANCHE;
            int niveau = seance.getNIVEAU;
            int capacite = seance.getCAPACITE;

            comboBox1.Text = jour;
            //comboBox3.Text = horaire;
            //comboBox3.DataSource = elManager.affichageTrancheDispo(jour, idProf);
            comboBox4.Text = Convert.ToString(niveau);
            textBox1.Text = Convert.ToString(capacite);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idSeance = laSeance.getNUMSEANCE;
            string jour = comboBox1.Text;
            string horaire = comboBox3.Text;
            int niveau = Convert.ToInt32(comboBox4.Text);
            int capacite = Convert.ToInt32(textBox1.Text);
            elManager.modifSeance(idSeance, jour, horaire, niveau, capacite);
            MessageBox.Show("Modification effectuée");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jour = comboBox1.Text;
            int idProf = laSeance.getIDPROF;
            comboBox3.DataSource = null;
            List<Horaire> listHoraireDispo = elManager.affichageTrancheDispo(jour, idProf);

            Horaire horaireActuelle = new Horaire(laSeance.getTRANCHE);
            listHoraireDispo.Add(horaireActuelle);
            comboBox3.DataSource = listHoraireDispo;

        }
    }
}