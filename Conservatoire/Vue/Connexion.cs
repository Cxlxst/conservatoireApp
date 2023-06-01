using Conservatoire.Controleur;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conservatoire
{
    public partial class Connexion : Form
    {
        Mgr elManager = new Mgr();
        public Connexion()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string identifiant = textBox1.Text;
            string mdp = textBox2.Text;

            bool checkConnexion = elManager.connexion(identifiant, mdp);

            if(checkConnexion == true) {

                this.Hide();

                Accueil listeProfesseur = new Accueil();
                listeProfesseur.ShowDialog();

                this.Close();

            }
            else
            {
                MessageBox.Show("Erreur connexion");
            }


        }
    }
}
