using Conservatoire.Modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.DAL
{
    public class instrumentDAO
    {
        // Attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "conservatoire";
        private static string uid = "root";
        private static string mdp = "";

        private static Connexion maConnexionSql;
        private static MySqlCommand Ocom;

        public static List<Instrument> affichageInstrument()
        {
            List<Instrument> listInstruments = new List<Instrument>();
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "SELECT * FROM instrument ORDER BY LIBELLE";
                Ocom = maConnexionSql.reqExec(req);

                maConnexionSql.openConnection();
                MySqlDataReader reader = Ocom.ExecuteReader();

                Instrument instrument;

                while (reader.Read())
                {
                    string libelle = (string)reader.GetValue(0);

                    instrument = new Instrument(libelle);
                    listInstruments.Add(instrument);
                }
                reader.Close();
                maConnexionSql.closeConnection();

            }

            catch (Exception ex)
            {
                throw (ex);
            }

            return listInstruments;
        }
    }
}