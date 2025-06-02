using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    internal class EtudiantDao
    {
        string FileEtudiant = "C:\\Users\\Dell\\source\\repos\\Projet_C#\\Projet_C#\\Etudiants.csv";
        public void AddEtudiant(int id, string nom, string prenom, string motDePasse)
        {
            StreamWriter writer = new StreamWriter(FileEtudiant, true);
            writer.WriteLine(id + "," + nom + "," + prenom + "," + motDePasse);
            writer.Close();
        }
        public Etudiant FindEtudiant(string nom, string motDePasse)
        {
            StreamReader reader = new StreamReader(FileEtudiant);
            string ligne = reader.ReadLine();
            while (ligne != null)
            {
                string[] dd = ligne.Split(",");
                if (dd[1] == nom && dd[3] == motDePasse)
                {
                    Etudiant et = new Etudiant();
                    et.Id = int.Parse(dd[0]);
                    et.Nom = dd[1];
                    et.Prenom = dd[2];
                    et.MotDePasse = dd[3];

                    reader.Close();
                    return et;
                }
                ligne = reader.ReadLine();
            }
            reader.Close();
            return null;
        }
        public Etudiant FindEtudiantById(int id)
        {
            Etudiant et = null;
            StreamReader reader = new StreamReader(FileEtudiant);
            string ligne = reader.ReadLine();
            while (ligne != null)
            {
                string[] dd = ligne.Split(",");
                if (int.Parse(dd[0]) == id)
                {
                    et = new Etudiant();
                    et.Id = id;
                    et.Nom = dd[1];
                    et.Prenom = dd[2];
                    et.MotDePasse = dd[3];
                    break;
                }
                ligne = reader.ReadLine();
            }
            reader.Close();
            return et;
        }
        public List<Etudiant> GetAllEtudiants()
        {
            List<Etudiant> etudiants = new List<Etudiant>();
            StreamReader reader = new StreamReader(FileEtudiant);
            string ligne = reader.ReadLine();
            while (ligne != null)
            {
                string[] dd = ligne.Split(",");

                Etudiant et = new Etudiant();
                et.Id = int.Parse(dd[0]);
                et.Nom = dd[1];
                et.Prenom = dd[2];
                et.MotDePasse = dd[3];

                etudiants.Add(et);
                ligne = reader.ReadLine();
            }
            reader.Close();
            return etudiants;
        }
        public void SupprimerEtudiantParId(int id)
        {
            List<string> lignes = new List<string>();
            StreamReader reader = new StreamReader(FileEtudiant);
            string ligne = reader.ReadLine();

            while (ligne != null)
            {
                string[] dd = ligne.Split(",");
                if (int.Parse(dd[0]) != id)
                {
                    lignes.Add(ligne);
                }
                ligne = reader.ReadLine();
            }
            reader.Close();

            StreamWriter writer = new StreamWriter(FileEtudiant, false);
            foreach (string l in lignes)
            {
                writer.WriteLine(l);
            }
            writer.Close();
        }
    }
}



