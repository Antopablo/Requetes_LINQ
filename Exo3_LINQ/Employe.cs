using System;
using System.Collections.Generic;
using System.Text;

namespace Exo3_LINQ
{
    class Employe
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private string _poste;
        public string Poste
        {
            get { return _poste; }
            set { _poste = value; }
        }

        private int _ancienete;
        public int Ancienete
        {
            get { return _ancienete; }
            set { _ancienete = value; }
        }

        public Employe(int iD, string nom, string poste, int ancienete)
        {
            ID = iD;
            Nom = nom;
            Poste = poste;
            Ancienete = ancienete;
        }

        public override string ToString()
        {
            return "L'employé " + Nom + "- ID [" + ID + "] occupe le poste " + Poste + " avec " + Ancienete + " années d'anciennetée";
        }
    }
}
