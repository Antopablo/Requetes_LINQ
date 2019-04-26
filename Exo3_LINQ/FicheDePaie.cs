using System;
using System.Collections.Generic;
using System.Text;

namespace Exo3_LINQ
{
    class FicheDePaie
    {
        private int _ID_FDP;
        public int ID_FDP
        {
            get { return _ID_FDP; }
            set { _ID_FDP = value; }
        }

        private string _nomSalarie;
        public string NomSalarie
        {
            get { return _nomSalarie; }
            set { _nomSalarie = value; }
        }

        private int _nbHeuresTravaille;
        public int NbHeuresTravaille
        {
            get { return _nbHeuresTravaille; }
            set { _nbHeuresTravaille = value; }
        }

        private int _nbHeureSup;
        public int NbHeureSup
        {
            get { return _nbHeureSup; }
            set { _nbHeureSup = value; }
        }

        private int _salaire;
        public int Salaire
        {
            get { return _salaire; }
            set { _salaire = value; }
        }

        public FicheDePaie(int iD_FDP, string nomsalarie, int nbHeuresTravaille, int nbHeureSup, int salaire)
        {
            ID_FDP = iD_FDP;
            NomSalarie = nomsalarie;
            NbHeuresTravaille = nbHeuresTravaille;
            NbHeureSup = nbHeureSup;
            Salaire = salaire;
        }

        public override string ToString()
        {
            return "Cette fiche de paye à l'ID :" + ID_FDP + ". Elle apparatient à " + NomSalarie + " qui a travaillé " + NbHeuresTravaille + " heures + " + NbHeureSup + " heures sup' pour un salaire de " + Salaire + " euros."; 
        }
    }
}
