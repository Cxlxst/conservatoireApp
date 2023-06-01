using Conservatoire.Modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.DAL
{
    public class profDAO
    {
        // Attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "conservatoire";
        private static string uid = "root";
        private static string mdp = "";

        private static Connexion maConnexionSql;
        private static MySqlCommand Ocom;

        public static List<Prof> affichageProf()
        {
            List<Prof> listProfs = new List<Prof>();
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT * FROM prof PR INNER JOIN personne P ON P.ID = PR.IDPROF ORDER BY NOM";
                Ocom = maConnexionSql.reqExec(req);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                Prof prof;

                while (reader.Read())
                {
                    int id = (int)reader.GetValue(0);
                    string instrument = (string)reader.GetValue(1);
                    float salaire = (float)reader.GetValue(2);
                    string nom = (string)reader.GetValue(4);
                    string prenom = (string)reader.GetValue(5);
                    string tel = (string)reader.GetValue(6);
                    string mail = (string)reader.GetValue(7);
                    string adresse = (string)reader.GetValue(8);


                    prof = new Prof(id, nom, prenom, tel, mail, adresse, instrument, salaire);

                    listProfs.Add(prof);
                }
                reader.Close();
                maConnexionSql.closeConnection();

            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return listProfs;
        }

        public static void addProf(int idProf, string instrument, int salaire)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "INSERT INTO prof (IDPROF, INSTRUMENT, SALAIRE) VALUES(@idProf, @instrument, @salaire)";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("idProf", idProf);
                Ocom.Parameters.AddWithValue("instrument", instrument);
                Ocom.Parameters.AddWithValue("salaire", salaire);

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

        public static bool verif(int id)
        {
            bool res = false;

            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT COUNT(*) FROM seance WHERE IDPROF = @id";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("id", id);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                while (reader.Read())
                {
                    Int64 nbInscriptions = (Int64)reader.GetValue(0);

                    if (nbInscriptions >= 1)
                    {
                        res = true;
                    }
                }

                reader.Close();
                maConnexionSql.closeConnection();
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }

        public static void suppProf(int idProf)
        {
            Console.WriteLine(idProf);
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "DELETE FROM prof WHERE IDPROF = @idProf";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("idProf", idProf);

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

        public static Prof recupProf(int idProf)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT * FROM prof PR INNER JOIN personne P ON P.ID = PR.IDPROF WHERE PR.IDPROF = @idProf";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("idProf", idProf);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                Prof prof = new Prof(0, "", "", "", "", "", "", 0);

                while (reader.Read())
                {
                    int id = (int)reader.GetValue(0);
                    string instrument = (string)reader.GetValue(1);
                    float salaire = (float)reader.GetValue(2);
                    string nom = (string)reader.GetValue(4);
                    string prenom = (string)reader.GetValue(5);
                    string tel = (string)reader.GetValue(6);
                    string mail = (string)reader.GetValue(7);
                    string adresse = (string)reader.GetValue(8);


                    prof = new Prof(id, nom, prenom, tel, mail, adresse, instrument, salaire);
                }
                reader.Close();
                maConnexionSql.closeConnection();
                return prof;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static void modifProf(int id, string instrument, int salaire)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "UPDATE prof SET INSTRUMENT = @instrument, SALAIRE = @salaire WHERE IDPROF = @id";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("id", id);
                Ocom.Parameters.AddWithValue("instrument", instrument);
                Ocom.Parameters.AddWithValue("salaire", salaire);

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