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

namespace Conservatoire.Vue
{
    public partial class FormProf : Form
    {
        int varForm = 0;
        int idProf;
        Mgr elManager = new Mgr();
        public FormProf()
        {
            InitializeComponent();
            varForm = 0;   
            
            List<Instrument> listInstruments = elManager.chargementListeInstruments();

            comboBox1.DataSource = null;
            comboBox1.DataSource = listInstruments;
        }

        public FormProf(int id)
        {
            InitializeComponent();
            varForm = 1;

            List<Instrument> listInstruments = elManager.chargementListeInstruments();

            comboBox1.DataSource = null;
            comboBox1.DataSource = listInstruments;

            Prof prof = elManager.recupProf(id);

            idProf = id;
            textBox1.Text = prof.getNOM;
            textBox2.Text = prof.getPRENOM;
            textBox3.Text = prof.getMAIL;
            textBox4.Text = prof.getTEL;
            comboBox1.Text = prof.getINSTRUMENT;
            textBox5.Text = Convert.ToString(prof.getSALAIRE);
            textBox6.Text = prof.getADRESSE;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(varForm== 0)
            {
                string nomTB = textBox1.Text;
                string prenomTB = textBox2.Text;
                string mailTB = textBox3.Text;
                string telTB = textBox4.Text;
                string instrumentTB = comboBox1.Text;
                int salaireTB = Convert.ToInt32(textBox5.Text);
                string adresseTB = textBox6.Text;

                elManager.addProfPersonne(nomTB, prenomTB, telTB, mailTB, adresseTB, instrumentTB, salaireTB);
                this.Close();
                MessageBox.Show("Professeur ajouté");
            }
            else
            {
                string nomTB = textBox1.Text;
                string prenomTB = textBox2.Text;
                string mailTB = textBox3.Text;
                string telTB = textBox4.Text;
                string instrumentTB = comboBox1.Text;
                int salaireTB = Convert.ToInt32(textBox5.Text);
                string adresseTB = textBox6.Text;

                elManager.modifProfPersonne(idProf, nomTB, prenomTB, telTB, mailTB, adresseTB, instrumentTB, salaireTB);
                this.Close();
                MessageBox.Show("Professeur modifié");
            }
            
        }
    }
}
