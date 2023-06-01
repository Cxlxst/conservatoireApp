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
using Conservatoire.Modele;
using Conservatoire.DAL;

namespace Conservatoire.Vue
{
    public partial class FormEleve : Form
    {
        Mgr elManager = new Mgr();

        int check;
        int idEleve;

        public FormEleve()
        {
            InitializeComponent();
            check= 0;
        }


        public FormEleve(int id)
        {
            InitializeComponent();
            check= 1;
            
            Eleve eleve = elManager.recupEleve(id);

            idEleve = eleve.getID;
            textBox1.Text = eleve.getNOM;
            textBox2.Text = eleve.getPRENOM;
            textBox3.Text = eleve.getMAIl;
            textBox4.Text = eleve.getTEL;
            textBox5.Text = eleve.getADRESSE;
            textBox6.Text = Convert.ToString(eleve.getBOURSE);
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (check == 0)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    string nomTB = textBox1.Text;
                    string prenomTB = textBox2.Text;
                    string mailTB = textBox3.Text;
                    string telTB = textBox4.Text;
                    string adresseTB = textBox5.Text;
                    int bourseTB = Convert.ToInt32(textBox6.Text);

                    elManager.addElevePersonne(nomTB, prenomTB, telTB, mailTB, adresseTB, bourseTB);
                    this.Close();
                    MessageBox.Show("Elève ajouté !");
                }

                else
                {
                    MessageBox.Show("Les champs ne sont pas tous rempli !");
                }
            }
            else
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {

                    string nomTB = textBox1.Text;
                    string prenomTB = textBox2.Text;
                    string mailTB = textBox3.Text;
                    string telTB = textBox4.Text;
                    string adresseTB = textBox5.Text;
                    int bourseTB = Convert.ToInt32(textBox6.Text);

                    Console.WriteLine(idEleve);

                    elManager.modifElevePersonne(idEleve, nomTB, prenomTB, mailTB, telTB, adresseTB, bourseTB);
                    this.Close();
                    MessageBox.Show("Elève modifié !");
                }
            }
        }

    }
}