using Conservatoire.Modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.DAL
{
    public class trimestreDAO
    {
        // Attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "conservatoire";
        private static string uid = "root";
        private static string mdp = "";

        private static Connexion maConnexionSql;
        private static MySqlCommand Ocom;

        public static List<Trimestre> recupTrimestre()
        {
            List<Trimestre> listTrimestres = new List<Trimestre>();
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT * FROM trim";
                Ocom = maConnexionSql.reqExec(req);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                Trimestre trim;

                while (reader.Read())
                {
                    string libelle = (string)reader.GetValue(0);
                    string dateFin = (string)reader.GetValue(1);

                    trim = new Trimestre(libelle, dateFin);
                    listTrimestres.Add(trim);

                }
                reader.Close();
                maConnexionSql.closeConnection();

            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return listTrimestres;
        }

        public static bool recupPaiement(int idEleve, string libelle)
        {
            bool paiement = false;

            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT COUNT(*) FROM payer WHERE LIBELLE = @libelle AND IDELEVE = @idEleve";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("libelle", libelle);
                Ocom.Parameters.AddWithValue("idEleve", idEleve);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();


                while (reader.Read())
                {
                    if ((Int64)reader.GetValue(0) == 1)
                    {
                        paiement = true;
                    }
                }
                reader.Close();
                maConnexionSql.closeConnection();

            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return paiement;
        }

        public static Trimestre infosPaiement(int idEleve, string libelle)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT * FROM payer WHERE LIBELLE = @libelle AND IDELEVE = @idEleve";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("libelle", libelle);
                Ocom.Parameters.AddWithValue("idEleve", idEleve);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                Trimestre infosPaiementTrimestre = new Trimestre(0, "", "");

                while (reader.Read())
                {
                    string datePaiement = (string)reader.GetValue(2);
                    infosPaiementTrimestre = new Trimestre(idEleve, libelle, datePaiement);
                }
                reader.Close();
                maConnexionSql.closeConnection();

                return infosPaiementTrimestre;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}