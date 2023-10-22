using Microsoft.Win32;
using Projet_TP.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_TP.daoPassager;
using Projet_TP.reservation;

namespace Projet_TP.Utilitaire
{
    internal class utilitaire
    {
        internal static void AfficherData(List<Passager> passagers)
        {

            Console.WriteLine("==================================");
            Console.WriteLine("Liste de tous les passagers");
            Console.WriteLine("==================================");

            Console.WriteLine("{0} enregistrements(s) trouvés:", passagers.Count);

            foreach (Passager passager in passagers)
            {
                Console.WriteLine("code:{0}, nom: {1}, prenom: {2}, adresse: {3}, statut: {4}",
                    passager.CodePassager, passager.Nom, passager.Prenom, passager.Adresse, passager.Statut);
            }

            Console.WriteLine("==================================");
        }


        public static void AfficherPassagersAvecReservations(List<Passager> passagers, List<Reservation> registre1)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Liste des passagers frequent flyer et leur reservation");
            Console.WriteLine("===================================");

            foreach (Passager passager in passagers)
            {
                Console.WriteLine($"code:{passager.CodePassager}, nom: {passager.Nom}, prenom: {passager.Prenom}, " +
                    $"adresse: {passager.Adresse}, statut: {passager.Statut}");
                Console.WriteLine("Réservation(s) pour ce client:");

                foreach (Reservation reservation in registre1)
                {
                    if (reservation.CodePassager == passager.CodePassager)
                    {
                        Console.WriteLine($"code reservation:{reservation.CodeReservation}, " +
                            $"statut de reservation: {reservation.StatutReservation}, " +
                            $"date de reservation: {reservation.DateReservation}");
                    }
                }

                Console.WriteLine("----------------------------");
            }
        }
    }

       
    }


