using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TP.Modele
{
    internal class Passager
    {
        public  long  CodePassager { get; set; }
        public  string Nom { get; set; }
        public  string Prenom { get; set; }
        public  string Adresse { get; set; }
        public  string Telephone { get; set; }
        public  string Ville { get; set; }
        public  string Pays { get; set; }
        public  string Statut { get; set; }

        public Passager(long codePassager, string nom, string prenom, string adresse, string telephone, string ville, string pays, string statut)
        {
            CodePassager = codePassager;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Telephone = telephone;
            Ville = ville;
            Pays = pays;
            Statut = statut;
        }

        public Passager()
        {
        }

        public Passager(int codepassager, string nom, string prenom, string adresse, string telephone, string statut)
        {
            CodePassager = codepassager;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Telephone = telephone;
            Statut = statut;
        }

        public override string ToString()
        {
            return CodePassager+'-'+Nom + '-'+Prenom+'-'+Adresse+'-'+Telephone+'-'+Ville+'-'+Pays+'-'+Statut;
        }
    }
}
