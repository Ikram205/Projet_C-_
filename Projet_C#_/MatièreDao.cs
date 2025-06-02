using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    internal class MatièreDao
    {
        string FileMatière = "C:\\Users\\Dell\\source\\repos\\Projet_C#\\Projet_C#\\Matières.csv";
        public void AjouterM(int matiereId, string nomMatiere, int etudiantId, int enseignantId)
        {
            StreamWriter sw = new StreamWriter(FileMatière, true);
            sw.WriteLine(matiereId + "," + nomMatiere + "," + etudiantId + "," + enseignantId);
            sw.Close();
        }
        public List<Matière> Lister()
        {
            List<Matière> matieres = new List<Matière>();

            StreamReader sr = new StreamReader(FileMatière);
            string ligne = sr.ReadLine();

            while (ligne != null)
            {
                string[] col = ligne.Split(',');
                if (col.Length < 4)
                {
                    ligne = sr.ReadLine();
                    continue;
                }

                Matière matiere = new Matière
                {
                    Mid1 = int.Parse(col[0]),
                    NomM = col[1],
                    Etid1 = int.Parse(col[2]),
                    Enid1 = int.Parse(col[3])
                };
                matieres.Add(matiere);
                ligne = sr.ReadLine();
            }
            sr.Close();
            return matieres;
        }
        public void SupprimerMatiereParId(int id)
        {
            List<string> lignes = new List<string>();

            StreamReader sr = new StreamReader(FileMatière);
            string ligne = sr.ReadLine();
            while (ligne != null)
            {
                string[] col = ligne.Split(',');
                if (int.Parse(col[0]) != id)
                {
                    lignes.Add(ligne);
                }
                ligne = sr.ReadLine();
            }
            sr.Close();

            StreamWriter sw = new StreamWriter(FileMatière, false);
            foreach (string l in lignes)
            {
                sw.WriteLine(l);
            }
            sw.Close();
        }
        public List<Matière> ObtenirToutesLesMatières()
        {
            List<Matière> matieres = new List<Matière>();

            StreamReader sr = new StreamReader(FileMatière);
            string ligne = sr.ReadLine();

            while (ligne != null)
            {
                string[] col = ligne.Split(',');
                if (col.Length < 4)
                {
                    ligne = sr.ReadLine();
                    continue;
                }

                Matière matiere = new Matière
                {
                    Mid1 = int.Parse(col[0]),
                    NomM = col[1],
                    Etid1 = int.Parse(col[2]),
                    Enid1 = int.Parse(col[3])
                };
                matieres.Add(matiere);
                ligne = sr.ReadLine();
            }
            sr.Close();
            return matieres;
        }
        public void ModifierEnseignant(string nomMatiere, int enseignantId)
        {
            List<string> lignesModifiees = new List<string>();

            StreamReader sr = new StreamReader(FileMatière);
            string ligne = sr.ReadLine();

            while (ligne != null)
            {
                string[] col = ligne.Split(',');
                if (col[1] == nomMatiere)
                {
                    col[3] = enseignantId.ToString();
                }
                string nouvelleLigne = col[0] + "," + col[1] + "," + col[2] + "," + col[3];
                lignesModifiees.Add(nouvelleLigne);
                ligne = sr.ReadLine();
            }
            sr.Close();

            StreamWriter sw = new StreamWriter(FileMatière, false);
            foreach (string l in lignesModifiees)
            {
                sw.WriteLine(l);
            }
            sw.Close();
        }
    }
}

