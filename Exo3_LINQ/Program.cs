using System;
using System.Collections.Generic;
using System.Linq;

namespace Exo3_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Liste_Prenom
            List<string> ListePrenom = new List<string>();
            ListePrenom.Add("Anto");
            ListePrenom.Add("Nico");
            ListePrenom.Add("Alexis");
            ListePrenom.Add("Luc");
            ListePrenom.Add("Frank");
            ListePrenom.Add("Maxime");
            ListePrenom.Add("Dorian");
            ListePrenom.Add("Bastien");
            ListePrenom.Add("Giovanni");
            #endregion
            #region Liste_Poste
            List<string> ListePoste = new List<string>();
            ListePoste.Add("Directeur");
            ListePoste.Add("Actionnaire");
            ListePoste.Add("Responsable qualité");
            ListePoste.Add("Chef des ventes");
            ListePoste.Add("Commercial");
            ListePoste.Add("Vendeur");
            ListePoste.Add("Stagiaire");
            #endregion

            List<FicheDePaie> ListeFicheDePaye = new List<FicheDePaie>();
            List<Employe> ListeEmploye = new List<Employe>();

            for (int i = 0; i < 100; i++)
            {
                int rnd = RandomMaison.Instance.Next(100, 10000);
                int Nomrnd = RandomMaison.Instance.Next(0, ListePrenom.Count);
                int Jobrnd = RandomMaison.Instance.Next(0, ListePoste.Count);
                int anciennete = RandomMaison.Instance.Next(1, 35);
                ListeEmploye.Add(new Employe(rnd, ListePrenom[Nomrnd]+(i+1), ListePoste[Jobrnd], anciennete));
            }

            foreach (Employe item in ListeEmploye)
            {
                for (int i = 1; i < item.Ancienete*12; i++)
                {
                    ListeFicheDePaye.Add(new FicheDePaie(RandomMaison.Instance.Next(100, 5000)+i, item.Nom, RandomMaison.Instance.Next(10, 152), RandomMaison.Instance.Next(0, 40), RandomMaison.Instance.Next(1128, 5000)));
                }
            }

            while (true)
            {
                Console.WriteLine("Que faire ?\r\n1: Connaitre le salaire moyen de la société\r\n2: Avoir toutes les fiches de paies pour un employé\r\n3: Connaitre l'ancienneté moyenne de la société\r\n4: Trier les emplyés par leur ancienneté\r\n5: Le salaire moyen par poste");
                int Choice = Int32.Parse(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        SalaireMoyen(ListeFicheDePaye);
                        break;
                    case 2:
                        FicheDePayePourUnEmploye(ListeFicheDePaye);
                        break;
                    case 3:
                        AncienneteMoyenne(ListeEmploye);
                        break;
                    case 4:
                        TrieAnciennete(ListeEmploye);
                        break;
                    case 5:
                        SalaireMoyenParPoste(ListeEmploye, ListeFicheDePaye);
                        break;
                    default:
                        Console.WriteLine("Commande non reconnue");
                        break;
                }
            }
        }

        public static void SalaireMoyen(List<FicheDePaie> listeFDP)
        {
            IEnumerable<FicheDePaie> QuerrySalaireMoyen =
                from moyen in listeFDP
                select moyen;

            int total = 0;
            foreach (FicheDePaie item in QuerrySalaireMoyen)
            {
                total += item.Salaire;
            }
            Console.WriteLine("Le salaire moyen de tous les employés est de : " +total / QuerrySalaireMoyen.Count<FicheDePaie>() + " euros.\r\n");
        }

        public static void FicheDePayePourUnEmploye(List<FicheDePaie> liste_FDP)
        {
            Console.WriteLine("Pour quel employé voulez-vous les fiches de payes?\r\n");
            string Choice = Console.ReadLine();

            IEnumerable<FicheDePaie> QuerryFicheDePaye =
                from FDP in liste_FDP
                where FDP.NomSalarie == Choice
                select FDP;

            Console.WriteLine("Pour l'employé nommé " +Choice+ ", voici ces fiches de payes :"+ "\r\n\r\n");
            foreach (FicheDePaie item in QuerryFicheDePaye)
            {
                Console.WriteLine("["+item.ID_FDP+"]" + item);
            }
        }

        public static void AncienneteMoyenne(List<Employe> LlisteEmpl)
        {
            IEnumerable<Employe> QuerryAncienneteMoyen =
                from moyen in LlisteEmpl
                select moyen;

            float total = 0;
            foreach (Employe item in QuerryAncienneteMoyen)
            {
                total += item.Ancienete;
            }
            Console.WriteLine("L'anciennetée moyenne de tous les employés est de : " + total / QuerryAncienneteMoyen.Count<Employe>() + " années.\r\n");

        }

        public static void TrieAnciennete(List<Employe> LlisteEmpl)
        {
            IEnumerable<Employe> QuerryTrieAnciennete =
               from moyen in LlisteEmpl
               orderby moyen.Ancienete ascending
               select moyen;

            foreach (Employe item in QuerryTrieAnciennete)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\r\n");
        }

        public static void SalaireMoyenParPoste(List<Employe> listeEmpl, List<FicheDePaie> listFDP)
        {
            Console.WriteLine("Pour quel poste ?\r\n");
            string Choice = Console.ReadLine();

            IEnumerable<FicheDePaie> QuerrySalaireMoyenParPoste =
                from emp in listeEmpl
                from fdp in listFDP
                where emp.Poste == Choice && fdp.NomSalarie == emp.Nom
                select fdp;

            double total = 0;
            foreach (FicheDePaie item in QuerrySalaireMoyenParPoste)
            {
                total += item.Salaire;
            }
            Console.WriteLine("La moyenne des salaires pour le poste : " +Choice+ " est de : {0:F2} euros.\r\n", total/QuerrySalaireMoyenParPoste .Count());
        }
    }
}
