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
using Conservatoire.DAL;
using Conservatoire.Modele;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Conservatoire.Vue
{
    public partial class FormSeance : Form
    {
        Mgr elManager = new Mgr();
        string jour;
        int idProf;

        public FormSeance()
        {
            InitializeComponent();
            List<Prof> listProfs = elManager.ChargementListeProfs();
            comboBox2.DataSource = listProfs;
            comboBox3.Enabled = false;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            jour = comboBox1.Text;
            if(jour != null && comboBox2.Text != null)
            {
                comboBox3.Enabled = true;
                List<Horaire> listTranches = elManager.affichageTrancheDispo(jour, idProf);
                comboBox3.DataSource = listTranches;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Prof prof = (Prof)comboBox2.SelectedItem;
            idProf = prof.getID;

            if (comboBox2.Text != null && comboBox1.Text != null)
            {
                comboBox3.Enabled = true;
                List<Horaire> listTranches = elManager.affichageTrancheDispo(jour, idProf);
                comboBox3.DataSource = listTranches;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tranche = comboBox3.Text;
            int niveau = Convert.ToInt32(comboBox4.Text);
            int capacite = Convert.ToInt32(textBox1.Text);

            elManager.addSeance(jour, idProf, tranche, niveau, capacite);
            MessageBox.Show("Ajout de séance effectué");
        }
    }
}
