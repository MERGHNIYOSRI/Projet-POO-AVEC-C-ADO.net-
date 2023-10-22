using MySql.Data.MySqlClient;
using Projet_TP.Modele;
using Projet_TP.reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TP.DaoReservation
{
    internal class ReservationDao
    {

        public MySqlCommand Command { get; set; }
        public MySqlConnection Conn { get; set; }


        public ReservationDao(string cs)
        {
            Conn = new MySqlConnection(cs);
        }

        public int AjouterData(string data, Reservation reservation)
        {
            Conn.Open();


            MySqlParameter parameter1 = new MySqlParameter();
            parameter1.ParameterName = "@sres";
            parameter1.Value = reservation.StatutReservation;

            MySqlParameter parameter2 = new MySqlParameter();
            parameter2.ParameterName = "@dres";
            parameter2.Value = reservation.DateReservation;

            MySqlParameter parameter3 = new MySqlParameter();
            parameter3.ParameterName = "@CodePassager";
            parameter3.Value = reservation.CodePassager;

            Command = new MySqlCommand(data, Conn);

            Command.Parameters.Add(parameter1);
            Command.Parameters.Add(parameter2);
            Command.Parameters.Add(parameter3);

            int lignesReservations = Command.ExecuteNonQuery();

            Conn.Close();

            return lignesReservations;
        }



        public List<Reservation> SelectionnerData1(string req)
        {
            Conn.Open();
            Command = new MySqlCommand(req, Conn);
            MySqlDataReader reader = Command.ExecuteReader();

            List<Reservation> listing1 = new List<Reservation>();
            while (reader.Read())
            {
                long codePassager = reader.GetInt64(0);
                long codeReservation = reader.GetInt64(1);
                string statutreservation = reader.GetString(2);
                string datereservation = reader.GetString(3);

                // Les détails du passager
                string nom = reader.GetString(4);
                string prenom = reader.GetString(5);
                string adresse = reader.GetString(6);
                string telephone = reader.GetString(7);
                string ville = reader.GetString(8);
                string pays = reader.GetString(9);
                string statut = reader.GetString(10);

                Passager passager = new Passager(codePassager, nom, prenom, adresse, telephone, ville, pays, statut);

                Reservation reservation = new Reservation(codePassager, codeReservation, statutreservation, datereservation, passager);
                listing1.Add(reservation);
            }

            Conn.Close();
            return listing1;
        }
    }

    }
