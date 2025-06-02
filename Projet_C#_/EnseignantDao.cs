using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet_C_
{
    internal class EnseignantDao
    {
        string FileEnseignant = "C:\\Users\\Dell\\source\\repos\\Projet_C#\\Projet_C#\\Enseignants.csv";
        public void AddEnseignant(int id, string nom, string prenom, string motDePasse)
        {
            StreamWriter writer = new StreamWriter(FileEnseignant, true);
            writer.WriteLine(id + "," + nom + "," + prenom + "," + motDePasse);
            writer.Close();
        }
        public string[] FindEnseignant(string nom, string motDePasse)
        {
            StreamReader reader = new StreamReader(FileEnseignant);
            string ligne = reader.ReadLine();
            while (ligne != null)
            {
                string[] dd = ligne.Split(",");
                if (dd[1] == nom && dd[3] == motDePasse)
                {
                    reader.Close();
                    return dd;
                }
                ligne = reader.ReadLine();
            }
            reader.Close();
            return null;
        }
        public List<Enseignant> GetAllEnseignants()
        {
            List<Enseignant> enseignants = new List<Enseignant>();
            StreamReader reader = new StreamReader(FileEnseignant);
            string ligne = reader.ReadLine();
            while (ligne != null)
            {
                string[] dd = ligne.Split(",");

                Enseignant ens = new Enseignant();
                ens.Id = int.Parse(dd[0]);
                ens.Nom = dd[1];
                ens.Prenom = dd[2];
                ens.MotDePasse = dd[3];

                enseignants.Add(ens);
                ligne = reader.ReadLine();
            }
            reader.Close();
            return enseignants;
        }
        public void SupprimerEnseignantParId(int id)
        {
            List<string> lignes = new List<string>();
            StreamReader reader = new StreamReader(FileEnseignant);
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

            StreamWriter writer = new StreamWriter(FileEnseignant, false);
            foreach (string l in lignes)
            {
                writer.WriteLine(l);
            }
            writer.Close();
        }
        public Enseignant FindEnseignantById(int id)
        {
            Enseignant ens = null;
            StreamReader reader = new StreamReader(FileEnseignant);
            string ligne = reader.ReadLine();
            while (ligne != null)
            {
                string[] dd = ligne.Split(",");
                if (int.Parse(dd[0]) == id)
                {
                    ens = new Enseignant();
                    ens.Id = id;
                    ens.Nom = dd[1];
                    ens.Prenom = dd[2];
                    ens.MotDePasse = dd[3];
                    break;
                }
                ligne = reader.ReadLine();
            }
            reader.Close();
            return ens;
        }
    }
}
