using System;
using System.Collections.Generic;
using System.IO;

namespace Projet_C_
{
    internal class AdministrateurDao
    {
        string FileAdministrateur = "C:\\Users\\Dell\\source\\repos\\Projet_C#\\Projet_C#\\Administrateurs.csv";
        public void AddAdministrateur(int Adid, string Adnom, string Adprenom, string Admdp)
        {
            StreamWriter sw = new StreamWriter(FileAdministrateur, true);
            sw.WriteLine(Adid + "," + Adnom + "," + Adprenom + "," + Admdp);
            sw.Close();
        }
        public string[] FindAdministrateur(string Adnom, string Admdp)
        {
            StreamReader sr = new StreamReader(FileAdministrateur);
            string ligne = sr.ReadLine();
            while (ligne != null)
            {
                string[] dd = ligne.Split(',');
                if (dd[1] == Adnom && dd[3] == Admdp)
                {
                    sr.Close();
                    return dd;
                }
                ligne = sr.ReadLine();
            }
            sr.Close();
            return null;
        }
        public List<Administrateur> GetAllAdministrateurs()
        {
            List<Administrateur> administrateurs = new List<Administrateur>();
            StreamReader sr = new StreamReader(FileAdministrateur);
            string ligne = sr.ReadLine();
            while (ligne != null)
            {
                string[] dd = ligne.Split(',');
                Administrateur a = new Administrateur();
                a.Adid1 = int.Parse(dd[0]);
                a.Adnom1 = dd[1];
                a.Adprenom1 = dd[2];
                a.Admdp1 = dd[3];
                administrateurs.Add(a);
                ligne = sr.ReadLine();
            }
            sr.Close();
            return administrateurs;
        }
        public void SupprimerAdministrateurParId(int id)
        {
            List<string> lignes = new List<string>();
            StreamReader sr = new StreamReader(FileAdministrateur);
            string ligne = sr.ReadLine();
            while (ligne != null)
            {
                string[] dd = ligne.Split(',');
                if (int.Parse(dd[0]) != id)
                {
                    lignes.Add(ligne);
                }
                ligne = sr.ReadLine();
            }
            sr.Close();

            StreamWriter sw = new StreamWriter(FileAdministrateur, false);
            foreach (string l in lignes)
            {
                sw.WriteLine(l);
            }
            sw.Close();
        }
        public Administrateur FindAdministrateurById(int id)
        {
            Administrateur a = null;
            StreamReader sr = new StreamReader(FileAdministrateur);
            string ligne = sr.ReadLine();
            while (ligne != null)
            {
                string[] dd = ligne.Split(',');
                if (int.Parse(dd[0]) == id)
                {
                    a = new Administrateur();
                    a.Adid1 = id;
                    a.Adnom1 = dd[1];
                    a.Adprenom1 = dd[2];
                    a.Admdp1 = dd[3];
                    break;
                }
                ligne = sr.ReadLine();
            }
            sr.Close();
            return a;
        }
    }
}
