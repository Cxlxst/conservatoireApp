using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.DAL
{
    public class adminDAO
    {
        // Attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "conservatoireApp";
        private static string uid = "root";
        private static string mdp = "";

        private static Connexion maConnexionSql;
        private static MySqlCommand Ocom;

        public static bool connexionAdmin(string identifiant, string mdpAdmin)
        {
            bool etat = false;

            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT COUNT(*) FROM administrateur WHERE MAIL = @identifiant AND MDP = @mdpAdmin";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("identifiant", identifiant);
                Ocom.Parameters.AddWithValue("mdpAdmin", mdpAdmin);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                while(reader.Read())
                {
                    if((Int64) reader.GetValue(0) == 1) {
                        etat = true;
                    }
                }

                reader.Close();

                maConnexionSql.closeConnection();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return etat;
        }
    }
}
