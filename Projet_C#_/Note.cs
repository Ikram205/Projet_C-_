using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    internal class Note
    {
        private int Etid;
        private string matiere;
        private string session;
        private double note;

        public int Etid1 { get => Etid; set => Etid = value; }
        public string Matiere { get => matiere; set => matiere = value; }
        public string Session { get => session; set => session = value; }
        public double Noten { get => note; set => note = value; }
    }
}
