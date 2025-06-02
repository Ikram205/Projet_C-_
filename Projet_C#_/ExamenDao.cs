using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    internal class ExamenDao
    {
        string FileExamen = "C:\\Users\\Dell\\source\\repos\\Projet_C#_\\Projet_C#_\\Examens.csv";
        public void AjouterE(int Exid1, string Session, string Matiere, int Etid1, DateTime Date)
        {
            StreamWriter sw = new StreamWriter(FileExamen, true);
            sw.WriteLine(Exid1 + "," + Session + "," + Matiere + "," + Etid1 + "," + Date.ToString("yyyy-MM-dd"));
            sw.Close();
        }
        public List<string> ObtenirEtudiantsParExamen(string nomSession)
        {
            List<string> resultatEtudiants = new List<string>();
            EtudiantDao accesEtudiant = new EtudiantDao();

            StreamReader sr = new StreamReader(FileExamen);
            string ligne = sr.ReadLine();
            while (ligne != null)
            {
                string[] col = ligne.Split(',');

                if (col.Length < 5)
                {
                    ligne = sr.ReadLine();
                    continue;
                }

                string sessionActuelle = col[1];
                string matiereActuelle = col[2];
                int identifiantEtudiant = Int32.Parse(col[3]);
                DateTime dateActuelle = DateTime.Parse(col[4]);

                if (sessionActuelle == nomSession)
                {
                    Etudiant etudiant = accesEtudiant.FindEtudiantById(identifiantEtudiant);

                    if (etudiant != null)
                    {
                        string InfoEtudiant = $"Nom: {etudiant.Nom}, Prénom: {etudiant.Prenom}, Matière: {matiereActuelle}, Date: {dateActuelle.ToShortDateString()}, Session: {sessionActuelle}";
                        resultatEtudiants.Add(InfoEtudiant);
                    }
                }
                ligne = sr.ReadLine();
            }
            sr.Close();
            return resultatEtudiants;
        }
    }
}

