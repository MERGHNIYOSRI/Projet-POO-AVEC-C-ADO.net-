using Projet_TP.Modele;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projet_TP.reservation;

namespace Projet_TP.daoPassager
{
    internal class PassagerDAO
    {
        public MySqlCommand Command { get; set; }
        public MySqlConnection Conn { get; set; }


        public PassagerDAO(string cs)
        {
            Conn = new MySqlConnection(cs);
        }

        public int ModifierData(string cde, Passager passager)
        {
            Conn.Open();

           // MySqlParameter parameter1 = new MySqlParameter();
           // parameter1.ParameterName = "@codePassager";
            //parameter1.Value = passager.CodePassager;

            MySqlParameter parameter2 = new MySqlParameter();
            parameter2.ParameterName = "@nom";
            parameter2.Value = passager.Nom;


            MySqlParameter parameter3 = new MySqlParameter();
            parameter3.ParameterName = "@pre";
            parameter3.Value = passager.Prenom;

            MySqlParameter parameter4 = new MySqlParameter();
            parameter4.ParameterName = "@adr";
            parameter4.Value = passager.Adresse;

            MySqlParameter parameter5 = new MySqlParameter();
            parameter5.ParameterName = "@tel";
            parameter5.Value = passager.Telephone;

            MySqlParameter parameter6 = new MySqlParameter();
            parameter6.ParameterName = "@ville";
            parameter6.Value = passager.Ville;

            MySqlParameter parameter7 = new MySqlParameter();
            parameter7.ParameterName = "@pays";
            parameter7.Value = passager.Pays;

            MySqlParameter parameter8 = new MySqlParameter();
            parameter8.ParameterName = "@statut";
            parameter8.Value = passager.Statut;

            Command = new MySqlCommand(cde, Conn);


            Command.Parameters.Add(parameter2);
            Command.Parameters.Add(parameter3);
            Command.Parameters.Add(parameter4);
            Command.Parameters.Add(parameter5);
            Command.Parameters.Add(parameter6);
            Command.Parameters.Add(parameter7);
            Command.Parameters.Add(parameter8);

            int lignes = Command.ExecuteNonQuery();




            return lignes;
        }



        public List<Passager> SelectionnerData(string sql)
        {

            //Open Conn
            Conn.Open();
            //Command
            Command = new MySqlCommand(sql, Conn);
            //Execution 
            MySqlDataReader reader = Command.ExecuteReader();

            List<Passager> listing = new List<Passager>();
            string nom, prenom, adresse, telephone,  statut;
            while (reader.Read())
            {

                int codepassager = reader.GetInt32(0); // Récupère la valeur INT de la  colonne "CodePassager"
                nom = reader.GetString(1);
                prenom = reader.GetString(2);
                adresse = reader.GetString(3);
                telephone = reader.GetString(4);
               // ville = reader.GetString(5);
               // pays = reader.GetString(5);
                statut = reader.GetString(5);

                listing.Add(new Passager(codepassager, nom, prenom, adresse, telephone,  statut));

            }
            //Fermeture
            Conn.Close();
            return listing;

        }

    }
}
