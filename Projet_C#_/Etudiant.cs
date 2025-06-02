using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    internal class Etudiant
    {
        private int id;
        private string nom;
        private string prenom;
        private string motDePasse;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }
    }
}

