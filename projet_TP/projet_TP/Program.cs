using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_TP.daoPassager;
using Projet_TP.Modele;
using Projet_TP.Utilitaire;
using Projet_TP.reservation;
using Projet_TP.DaoReservation;
using Microsoft.Win32;


namespace Projet_TP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cs = "server=localhost;user=root;" +
          "database=northwindmysql;port=3306;";

            PassagerDAO dao = new PassagerDAO(cs);
            ReservationDao daoReservation = new ReservationDao(cs);

                              //   Insertion dans la table passager


            //   string cde = "insert into Passager (Nom,Prenom, Adresse,Telephone,Ville,Pays,Statut) values(@nom,@pre,@adr,@tel,@ville,@pays,@statut)";

            //   Console.WriteLine("saisir le nom:");
            //   string nom = Console.ReadLine();

            //   Console.WriteLine("saisir le prenom:");
            //   string pre = Console.ReadLine();

            //   Console.WriteLine("saisir l'adresse:");
            //   string adr = Console.ReadLine();

            //   Console.WriteLine("saisir le numero de telephone:");
            //   string tel = Console.ReadLine();

            //   Console.WriteLine("saisir la ville:");
            //   string ville = Console.ReadLine();

            //   Console.WriteLine("saisir le pays:");
            //   string pays = Console.ReadLine();

            //   Console.WriteLine("saisir le statut:");
            //   string statut = Console.ReadLine();

            //   Passager passager = new Passager(nom, pre, adr, tel, ville, pays,statut);


            //   int lignes = dao.ModifierData(cde,passager);
            //   Console.WriteLine("Nbre de lignes modifiées:{0}", lignes);






                               // Insérer dans la table réservation
            //string data = "INSERT INTO Reservation (StatutReservation, DateReservation, CodePassager) VALUES (@sres, @dres, @codePassager)";

            //Console.WriteLine("Saisir l'état de réservation du client:");
            //string sres = Console.ReadLine();

            //Console.WriteLine("Saisir la date de réservation du client (au format yyyy-MM-dd) :");
            //string dres = Console.ReadLine();

            //Console.WriteLine("Saisir le code du passager pour la réservation : ");
            //int codePassager = Convert.ToInt32(Console.ReadLine());

            //Reservation reservation = new Reservation(sres, dres, codePassager, null);

            //int lignesReservation = daoReservation.AjouterData(data, reservation);
            //Console.WriteLine("Nbre de lignes insérées pour la réservation : {0}", lignesReservation);









            //Selectionner Les Données

          //  string sql = "select CodePassager,Nom,Prenom,Adresse,Telephone,Ville,Pays,Statut from Passager";
            //List<Passager> registre = dao.SelectionnerData(sql);


            //Afficher les categories
           // utilitaire.AfficherData(registre);


            string req = "SELECT p.CodePassager, r.CodeReservation, r.StatutReservation, r.DateReservation, " +
             "p.Nom, p.Prenom, p.Adresse, p.Telephone, p.Ville, p.Pays, p.Statut " +
             "FROM Passager p LEFT JOIN Reservation r ON p.CodePassager = r.CodePassager WHERE p.Statut = 'Frequent Flyer'";

            string sqlPassagers = "SELECT CodePassager, Nom, Prenom, Adresse,Telephone, Statut FROM Passager";
            List<Passager> passagers = dao.SelectionnerData(sqlPassagers);
            List<Reservation> registre1 = daoReservation.SelectionnerData1(req);
            

            utilitaire.AfficherData(passagers);
            utilitaire.AfficherPassagersAvecReservations(passagers, registre1);


        }
    }
}



