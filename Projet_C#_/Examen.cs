using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    internal class Examen
    {
        private int id_exam;
        private string session;
        private string matiere;
        private int id_etudiant;
        private DateTime date;

        public int Id_exam { get => id_exam; set => id_exam = value; }
        public string Session { get => session; set => session = value; }
        public string Matiere { get => matiere; set => matiere = value; }
        public int Id_etudiant { get => id_etudiant; set => id_etudiant = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
