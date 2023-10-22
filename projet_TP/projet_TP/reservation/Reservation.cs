using Projet_TP.Modele;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TP.reservation
{
    internal class Reservation
    {
        private string sres;
        private string dres;
        private object value;

        public long CodeReservation { get; set; }
        public string StatutReservation { get; set; }
        public string DateReservation { get; set; }
        public long CodePassager { get; set; }
        public Passager Passager { get; set; }

        //public Reservation(long codeReservation, string statutReservation, string dateReservation, long codePassager, Passager passager)
        //{
        //    CodeReservation = codeReservation;
        //    StatutReservation = statutReservation;
        //    DateReservation = dateReservation;
        //    CodePassager = codePassager;
        //    Passager = passager;
        //}

        public Reservation(long codePassager, long codeReservation, string statutreservation, string datereservation, Passager passager)
        {
            CodePassager = codePassager;
            CodeReservation = codeReservation;
            StatutReservation = statutreservation;
            DateReservation = datereservation;
            Passager = passager;
        }

        public Reservation(string sres, string dres, int codePassager, object value)
        {
            this.sres = sres;
            this.dres = dres;
            CodePassager = codePassager;
            this.value = value;
        }

        public override string ToString()
        {
            return CodeReservation + '-' + StatutReservation + '-' + DateReservation+'-'+CodePassager+'-'+Passager;
        }
    }
}
