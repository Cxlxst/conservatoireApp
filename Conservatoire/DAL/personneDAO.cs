using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservatoire.DAL
{
    public class personneDAO
    {
        // Attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "conservatoire";
        private static string uid = "root";
        private static string mdp = "";

        private static Connexion maConnexionSql;
        private static MySqlCommand Ocom;

        public static int getID()
        {

            int dernierId = 0;

            maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
            string req = "SELECT ID FROM personne WHERE ID = (SELECT MAX(ID) FROM personne)";
            Ocom = maConnexionSql.reqExec(req);

            maConnexionSql.openConnection();
            MySqlDataReader reader = Ocom.ExecuteReader();

            while(reader.Read())
            {
                dernierId = (int)reader.GetValue(0);
            }

            reader.Close();
            maConnexionSql.closeConnection();

            return dernierId;
        }

        public static void addPersonne(string nom, string prenom, string tel, string mail, string adresse)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "INSERT INTO personne (NOM, PRENOM, TEL, MAIL, ADRESSE) VALUES(@nom, @prenom, @tel, @mail, @adresse)";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("nom", nom);
                Ocom.Parameters.AddWithValue("prenom", prenom);
                Ocom.Parameters.AddWithValue("tel", tel);
                Ocom.Parameters.AddWithValue("mail", mail);
                Ocom.Parameters.AddWithValue("adresse", adresse);

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

        public static void suppPersonne(int id)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "DELETE FROM personne WHERE ID = @id";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("ID", id);

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

        public static void modifPersonne(int id, string nom, string prenom, string tel, string mail, string adresse)
        {
            try
            {
                maConnexionSql = Connexion.getInstance(provider, dataBase, uid, mdp);
                string req = "UPDATE personne SET NOM = @nom, PRENOM = @prenom, TEL = @tel, MAIL = @mail, ADRESSE = @adresse WHERE ID = @id";
                Ocom = maConnexionSql.reqExec(req);
                Ocom.Parameters.AddWithValue("id", id);
                Ocom.Parameters.AddWithValue("nom", nom);
                Ocom.Parameters.AddWithValue("prenom", prenom);
                Ocom.Parameters.AddWithValue("tel", tel);
                Ocom.Parameters.AddWithValue("mail", mail);
                Ocom.Parameters.AddWithValue("adresse", adresse);

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
