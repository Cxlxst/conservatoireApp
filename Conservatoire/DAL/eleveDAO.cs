using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conservatoire.Modele;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;

namespace Conservatoire.DAL
{
    public class eleveDAO
    {
        // Attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "conservatoire";
        private static string uid = "root";
        private static string mdp = "";

        private static Connexion maConnexionSql;
        private static MySqlCommand Ocom;

        public static List<Eleve> affichageEleve()
        {
            List<Eleve> listEleves = new List<Eleve>();
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT * FROM eleve E INNER JOIN personne P ON P.ID = E.IDELEVE ORDER BY NOM";
                Ocom = maConnexionSql.reqExec(req);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                Eleve eleve;

                while (reader.Read())
                {
                    int id = (int)reader.GetValue(0);
                    int bourse = (int)reader.GetValue(1);
                    string nom = (string)reader.GetValue(3);
                    string prenom = (string)reader.GetValue(4);
                    string tel = (string)reader.GetValue(5);
                    string mail = (string)reader.GetValue(6);
                    string adresse = (string)reader.GetValue(7);


                    eleve = new Eleve(id, nom, prenom, tel, mail, adresse, bourse);

                    listEleves.Add(eleve);
                
                }
                reader.Close();
                maConnexionSql.closeConnection();

            }
            
            catch (Exception ex)
            {
                throw (ex);
            }

            return listEleves;
        }

        public static void addEleve(int idEleve, int bourse)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "INSERT INTO eleve (IDELEVE, BOURSE) VALUES(@idEleve, @bourse)";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("idEleve", idEleve);
                Ocom.Parameters.AddWithValue("bourse", bourse);

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

        public static bool verif(int idEleve)
        {
            bool etatSupression = false;

            try{

                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT COUNT(*) FROM inscription WHERE IDELEVE = @idEleve";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("idEleve", idEleve);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();


                while (reader.Read())
                {
                    if ((Int64)reader.GetValue(0) == 0)
                    {
                        etatSupression = true;
                    }
                }
                reader.Close();
                maConnexionSql.closeConnection();

            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return etatSupression;
        }

        public static void suppEleve(int idEleve)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "DELETE FROM eleve WHERE IDELEVE = @idEleve";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("idEleve", idEleve);

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
        public static Eleve recupEleve(int id)
        {
            Eleve eleve = new Eleve(0,"","","","","",0);
            maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
            string req = "SELECT * FROM eleve INNER JOIN personne WHERE ID = @id ORDER BY NOM";
            Ocom = maConnexionSql.reqExec(req);
            Ocom.Parameters.AddWithValue("id", id);

            maConnexionSql.openConnection();
            MySqlDataReader reader = Ocom.ExecuteReader();

            while (reader.Read())
            {
                int bourse = (int)reader.GetValue(1);
                string nom = (string)reader.GetValue(3);
                string prenom = (string)reader.GetValue(4);
                string tel = (string)reader.GetValue(5);
                string mail = (string)reader.GetValue(6);
                string adresse = (string)reader.GetValue(7);
                eleve = new Eleve(id, nom, prenom, tel, mail, adresse, bourse);
            }

            reader.Close();
            maConnexionSql.closeConnection();

            return eleve;
        }

        public static void modifEleve(int id, int bourse)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "UPDATE eleve SET BOURSE = @bourse WHERE IDELEVE = @id";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("id", id);
                Ocom.Parameters.AddWithValue("bourse", bourse);

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
