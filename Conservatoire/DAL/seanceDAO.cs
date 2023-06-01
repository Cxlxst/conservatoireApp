using Conservatoire.Modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Conservatoire.DAL
{
    public class seanceDAO
    {
        // Attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "conservatoire";
        private static string uid = "root";
        private static string mdp = "";

        private static Connexion maConnexionSql;
        private static MySqlCommand Ocom;

        public static List<Seance> affichageSeance()
        {
            List<Seance> listSeances = new List<Seance>();
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT * FROM seance ORDER BY JOUR, TRANCHE";
                Ocom = maConnexionSql.reqExec(req);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                Seance seance;

                while (reader.Read())
                {
                    int idProf = (int)reader.GetValue(0);
                    int numSeance = (int)reader.GetValue(1);
                    string tranche = (string)reader.GetValue(2);
                    string jour = (string)reader.GetValue(3);
                    int niveau = (int)reader.GetValue(4);
                    int capacite = (int)reader.GetValue(5);


                    seance = new Seance(idProf, numSeance, tranche, jour, niveau, capacite);

                    listSeances.Add(seance);
                }
                reader.Close();
                maConnexionSql.closeConnection();

            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return listSeances;
        }

        public static bool verif(int idSeance)
        {
            bool check = false;
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT COUNT(*) FROM inscription WHERE NUMSEANCE = @idSeance";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("idSeance", idSeance);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                while (reader.Read())
                {
                    if ((Int64)reader.GetValue(0) >= 1)
                    {
                        check = true;
                    }
                    
                }
                reader.Close();
                maConnexionSql.closeConnection();

            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return check;
        }

        public static void suppSeance(int idSeance)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "DELETE FROM seance WHERE NUMSEANCE = @idSeance";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("idSeance", idSeance);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                reader.Close();
                maConnexionSql.closeConnection();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static void addSeance(string jour, int idProf, string tranche, int niveau, int capacite)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "INSERT INTO seance (IDPROF, TRANCHE, JOUR, NIVEAU, CAPACITE) VALUES(@idProf, @tranche, @jour, @niveau, @capacite)";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("idProf", idProf);
                Ocom.Parameters.AddWithValue("tranche", tranche);
                Ocom.Parameters.AddWithValue("jour", jour);
                Ocom.Parameters.AddWithValue("niveau", niveau);
                Ocom.Parameters.AddWithValue("capacite", capacite);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                reader.Close();
                maConnexionSql.closeConnection();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Gestion élèves de la séance
        public static List<Eleve> recupEleveSeance(int idSeance)
        {
            List<Eleve> eV = new List<Eleve>();

            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT * FROM inscription I RIGHT JOIN personne P ON I.IDELEVE = P.ID WHERE NUMSEANCE = @idSeance";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("idSeance", idSeance);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                while (reader.Read())
                {
                    int idEleve = (int)reader.GetValue(4);
                    string nom = (string)reader.GetValue(5);
                    string prenom = (string)reader.GetValue(6);
                    string tel = (string)reader.GetValue(7);
                    string mail = (string)reader.GetValue(8);
                    string adresse = (string)reader.GetValue(9);

                    Eleve eleve = new Eleve(idEleve, nom, prenom, tel, mail, adresse);
                    eV.Add(eleve);
                }
                reader.Close();
                maConnexionSql.closeConnection();

            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return eV;
        }


        public static List<Eleve> recupListeEleveExclu(string heureDebut, string heureFin, string jour)
        {
            List<Eleve> eV = new List<Eleve>();

            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT ID, NOM, PRENOM, MAIL, TEL, ADRESSE " +
                                        "FROM inscription I " +
                                        "INNER JOIN seance S " +
                                        "ON I.NUMSEANCE = S.NUMSEANCE " +
                                        "INNER JOIN personne P " +
                                        "ON I.IDELEVE = P.ID " +
                                        "WHERE S.JOUR = @jourselect " +
                                        "AND(" +

                                            "((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1)) <= (SELECT CAST(@heureDepart AS INT))" +
                                                "AND(SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) <= (SELECT CAST(@heureFin AS INT))" +
                                                "AND(SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) > (SELECT CAST(@heureDepart AS INT)))" +

                                            "OR((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1)) >= (SELECT CAST(@heureDepart AS INT))" +
                                                    "AND(SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) >= (SELECT CAST(@heureFin AS INT)) " +
                                                    "AND(SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1)) < (SELECT CAST(@heureFin AS INT)))" +

                                            "OR((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1)) <= (SELECT CAST(@heureDepart AS INT))" +
                                                    "AND(SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) >= (SELECT CAST(@heureFin AS INT)))" +

                                            "OR((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1)) >= (SELECT CAST(@heureDepart AS INT))" +
                                                    "AND(SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) <= (SELECT CAST(@heureFin AS INT)))" +

                                        ")";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("jourselect", jour);
                Ocom.Parameters.AddWithValue("heureDepart", heureDebut);
                Ocom.Parameters.AddWithValue("heureFin", heureFin);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                while (reader.Read())
                {
                    int idEleve = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string mail = (string)reader.GetValue(3);
                    string tel = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);

                    Eleve eleve = new Eleve(idEleve, nom, prenom, tel, mail, adresse);
                    eV.Add(eleve);
                }
                reader.Close();
                maConnexionSql.closeConnection();

            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return eV;
        }

        public static void ajoutEleveSeance(int idProf, int idEleve, int idSeance)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "INSERT INTO inscription (IDPROF, IDELEVE, NUMSEANCE, DATEINSCRIPTION) VALUES(@idProf, @idEleve, @idSeance, NOW())";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("idProf", idProf);
                Ocom.Parameters.AddWithValue("idEleve", idEleve);
                Ocom.Parameters.AddWithValue("idSeance", idSeance);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                reader.Close();
                maConnexionSql.closeConnection();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static void suppEleveSeance(int idEleve, int idSeance)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "DELETE FROM inscription WHERE IDELEVE = @idEleve AND NUMSEANCE = @idSeance";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("idEleve", idEleve);
                Ocom.Parameters.AddWithValue("idSeance", idSeance);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                reader.Close();
                maConnexionSql.closeConnection();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //Gestion Horaire
        public static List<Horaire> recupTranche()
        {
            List<Horaire> listTranche = new List<Horaire>();

            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT * FROM heure ORDER BY tranche";
                Ocom = maConnexionSql.reqExec(req);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                while (reader.Read())
                {
                    string tranche = (string)reader.GetValue(0);
                    
                    Horaire laTranche = new Horaire(tranche);
                    listTranche.Add(laTranche);
                }
                reader.Close();
                maConnexionSql.closeConnection();

            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return listTranche;
        }

        public static bool affichageTrancheDispo(int idProf, string jour, string heureDepart, string heureFin)
        {

            bool etatHoraire = false;

            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT COUNT(*) " +
                             "FROM seance S " +
                             "WHERE S.JOUR = @jourselect " +
                             "AND S.IDPROF = @idProf " +
                             "AND(" +

                                "((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1)) <= (SELECT CAST(@heureDepart AS INT))" +
                                "AND(SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) <= (SELECT CAST(@heureFin AS INT))" +
                                "AND(SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) > (SELECT CAST(@heureDepart AS INT)))" +

                                "OR((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1)) >= (SELECT CAST(@heureDepart AS INT))" +
                                    "AND(SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) >= (SELECT CAST(@heureFin AS INT)) " +
                                    "AND(SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1)) < (SELECT CAST(@heureFin AS INT)))" +

                                 "OR((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1)) <= (SELECT CAST(@heureDepart AS INT))" +
                                     "AND(SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) >= (SELECT CAST(@heureFin AS INT)))" +

                                 "OR((SELECT SUBSTRING_INDEX(S.TRANCHE, 'h', 1)) >= (SELECT CAST(@heureDepart AS INT))" +
                                     "AND(SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(S.TRANCHE, 'h', 2), '-', -1)) <= (SELECT CAST(@heureFin AS INT)))" +

                                 ")";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("idProf", idProf);
                Ocom.Parameters.AddWithValue("jourselect", jour);
                Ocom.Parameters.AddWithValue("heureDepart", heureDepart);
                Ocom.Parameters.AddWithValue("heureFin", heureFin);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                while (reader.Read())
                {
                    if((Int64)reader.GetValue(0) == 0) 
                    {
                        etatHoraire = true;
                    }
                }
                reader.Close();
                maConnexionSql.closeConnection();

            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return etatHoraire;
        }

        public static void modifSeance(int idSeance, string jour, string horaire, int niveau, int capacite)
        {

            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "UPDATE seance SET TRANCHE='@horaire',JOUR='@jour',NIVEAU='@niveau',CAPACITE='@capacite' WHERE NUMSEANCE = @numseance";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("horaire", horaire);
                Ocom.Parameters.AddWithValue("jour", jour);
                Ocom.Parameters.AddWithValue("niveau", niveau);
                Ocom.Parameters.AddWithValue("capacite", capacite);
                Ocom.Parameters.AddWithValue("numseance", idSeance);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                reader.Close();
                maConnexionSql.closeConnection();
            }

            catch (Exception ex)
            {
                throw (ex);
            }


        }

      }
}
