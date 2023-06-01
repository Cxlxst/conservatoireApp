using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conservatoire.DAL;
using Conservatoire.Modele;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Conservatoire.Controleur
{
    internal class Mgr
    {
        public Mgr()
        {

        }

        public bool connexion(string identifiant, string mdp)
        {
            bool etat = adminDAO.connexionAdmin(identifiant, mdp);

            return etat;
        }

        public List<Eleve> ChargementListeEleves()
        {
            List<Eleve> eleve = eleveDAO.affichageEleve();

            return eleve;
        }

        public List<Prof> ChargementListeProfs()
        {
            List<Prof> prof = profDAO.affichageProf();

            return prof;
        }

        public List<Seance> ChargementListeSeances()
        {
            List<Seance> seance = seanceDAO.affichageSeance();

            return seance;
        }

        public List<Instrument> chargementListeInstruments()
        {
            List<Instrument> instrument = instrumentDAO.affichageInstrument();
            return instrument;
        }


        public void addElevePersonne(string nom, string prenom, string tel, string mail, string adresse, int bourse)
        {
            personneDAO.addPersonne(nom, prenom, tel, mail, adresse);

            int dernierID = personneDAO.getID();

            eleveDAO.addEleve(dernierID, bourse);
        }


        public bool suppElevePersonne(int id)
        {
            bool retourControle = eleveDAO.verif(id);

            if (retourControle == true)
            {
                eleveDAO.suppEleve(id);
                personneDAO.suppPersonne(id);
                return retourControle;
            }

            else
            {
                return retourControle;
            }
        }

        public Eleve recupEleve(int id)
        {
            Eleve eleve = eleveDAO.recupEleve(id);
            return eleve;
        }

        public void modifElevePersonne(int id, string nom, string prenom, string mail, string tel, string adresse, int bourse)
        {
            eleveDAO.modifEleve(id, bourse);
            personneDAO.modifPersonne(id, nom, prenom, tel, mail, adresse);
        }

        public void addProfPersonne(string nom, string prenom, string tel, string mail, string adresse, string instrument, int salaire)
        {
            personneDAO.addPersonne(nom, prenom, tel, mail, adresse);

            int dernierID = personneDAO.getID();

            profDAO.addProf(dernierID, instrument, salaire);
        }

        public bool suppProfPersonne(int id)
        {
            bool retourControle = profDAO.verif(id);

            if (retourControle == false)
            {
                profDAO.suppProf(id);
                personneDAO.suppPersonne(id);
                return retourControle;
            }

            else
            {
                return retourControle;
            }

        }
        public Prof recupProf(int id)
        {
            Prof prof = profDAO.recupProf(id);
            return prof;
        }

        public void modifProfPersonne(int id, string nom, string prenom, string mail, string tel, string adresse, string instrument, int salaire)
        {
            profDAO.modifProf(id, instrument, salaire);
            personneDAO.modifPersonne(id, nom, prenom, tel, mail, adresse);
        }

        public List<Trimestre> recupTrimestre(int idEleve)
        {
            List<Trimestre> listTrimestres = trimestreDAO.recupTrimestre();
            List<Trimestre> listTrimestresGlobale = new List<Trimestre>();
            foreach (Trimestre unTrimestre in listTrimestres)
            {
                string libelleTrimestre = unTrimestre.getLIBELLE;
                bool paiementTrimestre = trimestreDAO.recupPaiement(idEleve, libelleTrimestre);

                if (paiementTrimestre == true)
                {
                    Trimestre infosPaiementTrimestre = trimestreDAO.infosPaiement(idEleve, libelleTrimestre);
                    listTrimestresGlobale.Add(infosPaiementTrimestre);
                }
                else
                {
                    listTrimestresGlobale.Add(unTrimestre);
                }
            }


            return listTrimestresGlobale;
        }

        public bool suppSeance(int idSeance)
        {
            bool retourControle = seanceDAO.verif(idSeance);

            if (retourControle == false)
            {
                seanceDAO.suppSeance(idSeance);
                return retourControle;
            }
            else
            {
                return retourControle;
            }
        }

        public List<Eleve> recupEleveSeance(int idSeance)
        {
            List<Eleve> eV = seanceDAO.recupEleveSeance(idSeance);
            return eV;
        }

        public List<Eleve> listEleveDispo(string tranche, string jour)
        {
            List<Eleve> elevesExclus = new List<Eleve>();
            List<Eleve> elevesDispo = new List<Eleve>();
            List<Eleve> elevesTotal = new List<Eleve>();
            string[] traitementHeure = Convert.ToString(tranche).Split('h');
            string heureDepart = traitementHeure[0];

            string[] traitementHeureFin = traitementHeure[1].Split('-');
            string heureFin = traitementHeureFin[1];

            elevesExclus = seanceDAO.recupListeEleveExclu(heureDepart, heureFin, jour);

            elevesTotal = eleveDAO.affichageEleve();
            foreach(Eleve eleveDispo in elevesTotal)
            {
                int compteur = 0;
                int numeroEleveDispo = eleveDispo.getID;

                foreach(Eleve eleveExclu in elevesExclus)
                {
                    int numeroEleveExclu = eleveExclu.getID;
                    if(numeroEleveExclu != numeroEleveDispo)
                    {
                        compteur++;
                    }
                }

                if(compteur == elevesExclus.Count)
                {
                    elevesDispo.Add(eleveDispo);
                }
            }
            return elevesDispo;
        }

        public void ajoutEleveSeance(int idProf, int idEleve, int idSeance)
        {
            seanceDAO.ajoutEleveSeance(idProf, idEleve, idSeance);
        }

        public void suppEleveSeance(int idEleve, int idSeance) { 
            seanceDAO.suppEleveSeance(idEleve, idSeance);
        }

        public List<Horaire> affichageTrancheDispo(string jour, int idProf)
        {
            //seanceDAO.affichageTranche(jour, idProf);
            
            List<Horaire> listHoraireTotale;
            List<Horaire> listHoraireDispo = new List<Horaire>();

            listHoraireTotale = seanceDAO.recupTranche();

            foreach(Horaire trancheTraitee in listHoraireTotale)
            {
                string[] traitementHeure = Convert.ToString(trancheTraitee).Split('h');
                string heureDepart = traitementHeure[0];

                string[] traitementHeureFin = traitementHeure[1].Split('-');
                string heureFin = traitementHeureFin[1];

                bool dispoHoraire = seanceDAO.affichageTrancheDispo(idProf, jour, heureDepart, heureFin);

                if(dispoHoraire == true) 
                {
                    listHoraireDispo.Add(trancheTraitee);
                }
            }

            return listHoraireDispo;
        }

        public void addSeance(string jour, int idProf, string tranche, int niveau, int capacite)
        {
            seanceDAO.addSeance(jour, idProf, tranche, niveau, capacite);
        }

        public void modifSeance(int idSeance, string jour, string horaire, int niveau, int capacite)
        {
            seanceDAO.modifSeance(idSeance, jour, horaire, niveau, capacite);
        }
    }
}