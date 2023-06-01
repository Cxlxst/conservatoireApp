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
using Conservatoire.DAL;
using Conservatoire.Vue;

namespace Conservatoire
{
    public partial class Accueil : Form
    {

        Mgr elManager = new Mgr();
        List<Eleve> listEleves = new List<Eleve>();
        public Accueil()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Accueil_Load(object sender, EventArgs e)
        {
            List<Eleve> eleve = elManager.ChargementListeEleves();

            listBox1.DataSource = null;
            listBox1.DataSource = eleve;

            comboBox1.Text = "Liste élèves";
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string choixComboxBox = comboBox1.Text;
            Console.WriteLine(choixComboxBox);

            if(choixComboxBox == "Liste élèves")
            {
                List<Eleve> eleve = elManager.ChargementListeEleves();

                listBox1.DataSource = null;
                listBox1.DataSource = eleve;
            }

            else if(choixComboxBox == "Liste professeurs")
            {
                List<Prof> prof = elManager.ChargementListeProfs();

                listBox1.DataSource = null;
                listBox1.DataSource = prof;
            }

            else
            {
                List<Seance> seance = elManager.ChargementListeSeances();

                listBox1.DataSource = null;
                listBox1.DataSource = seance;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string choixComboxBox = comboBox1.Text;
            Console.WriteLine(choixComboxBox);

            if (choixComboxBox == "Liste élèves")
            {
                FormEleve formEleve = new FormEleve();
                formEleve.ShowDialog();
            }

            else if (choixComboxBox == "Liste professeurs")
            {
                FormProf formProf = new FormProf();
                formProf.ShowDialog();
            }

            else
            {
                FormSeance formSeance = new FormSeance();
                formSeance.ShowDialog();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string choixComboxBox = comboBox1.Text;
            Console.WriteLine(choixComboxBox);

            if (choixComboxBox == "Liste élèves")
            {
                Eleve eL = (Eleve)listBox1.SelectedItem;
                int idEleve = eL.getID;

                bool etatSupp = elManager.suppElevePersonne(idEleve);

                if (etatSupp == true)
                {
                    MessageBox.Show("Elève supprimé avec succès");
                }
                else
                {
                    MessageBox.Show("Imposssible de supprimer cet élève car il est inscrit dans une séance");
                }
            }

            else if (choixComboxBox == "Liste professeurs")
            {
                Prof prof = (Prof)listBox1.SelectedItem;
                int idProf = prof.getID;

                bool etatSupp = elManager.suppProfPersonne(idProf);

                if (etatSupp == false)
                {
                    MessageBox.Show("Professeur supprimé avec succès");
                }
                else
                {
                    MessageBox.Show("Imposssible de supprimer ce professeur car il est intervenant dans une séance");
                }
            }

            else
            {
                Seance seance = (Seance)listBox1.SelectedItem;
                int idSeance = seance.getNUMSEANCE;
                Console.WriteLine(idSeance);
                bool etatSupp = elManager.suppSeance(idSeance);

                if(etatSupp == false)
                {
                    MessageBox.Show("Séance supprimée avec succès");
                }

                else
                {
                    MessageBox.Show("Impossible de supprimer cette séance car des élèves y sont inscrits");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string choixComboxBox = comboBox1.Text;
            Console.WriteLine(choixComboxBox);

            if (choixComboxBox == "Liste élèves")
            {
                Eleve eL = (Eleve)listBox1.SelectedItem;
                int idEleve = eL.getID;

                FormEleve formEleve = new FormEleve(idEleve);
                formEleve.ShowDialog();
            }

            else if (choixComboxBox == "Liste professeurs")
            {
                Prof prof = (Prof)listBox1.SelectedItem;
                int idProf = prof.getID;

                FormProf formProf = new FormProf(idProf);
                formProf.ShowDialog();
            }

            else
            {
                Seance seance = (Seance)listBox1.SelectedItem;

                modifSeance modifSeance = new modifSeance(seance);
                modifSeance.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string choixComboxBox = comboBox1.Text;
            Console.WriteLine(choixComboxBox);

            if (choixComboxBox == "Liste élèves")
            {
                Eleve eleve = (Eleve)listBox1.SelectedItem;
                int idEleve = eleve.getID;

                paiementsEleve pE = new paiementsEleve(idEleve);
                pE.ShowDialog();
            }

            else if (choixComboxBox == "Liste professeurs")
            {
                
            }

            else
            {
                Seance seance = (Seance)listBox1.SelectedItem;
               
                infosSeance iS = new infosSeance(seance);
                iS.ShowDialog();
            }
        }
    }
}
