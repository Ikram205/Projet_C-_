using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    internal class NoteDao
    {
        string FileNote = "C:\\Users\\Dell\\source\\repos\\Projet_C#\\Projet_C#\\Notes.csv";
        public void AddNote(int Etid1, string Matiere, string Session, double Noten)
        {
            StreamWriter sw = new StreamWriter(FileNote, true);
            sw.WriteLine(Etid1 + "," + Matiere + "," + Session + "," + Noten.ToString(System.Globalization.CultureInfo.InvariantCulture));
            sw.Close();
        }
        public Note FindNotesById(int id)
        {
            Note e = null;
            StreamReader sd = new StreamReader(FileNote);
            string line = sd.ReadLine();
            while (line != null)
            {
                string[] dd = line.Split(",");
                if (Int32.Parse(dd[0]) == id)
                {
                    e = new Note();
                    e.Etid1 = id;
                    e.Matiere = dd[1];
                    e.Session = dd[2];
                    e.Noten = Double.Parse(dd[3], System.Globalization.CultureInfo.InvariantCulture);
                    break;
                }
                line = sd.ReadLine();
            }
            sd.Close();
            return e;
        }
        public List<Note> GetAllNotes(int id)
        {
            List<Note> notes = new List<Note>();
            StreamReader sr = new StreamReader(FileNote);
            string line = sr.ReadLine();

            while (line != null)
            {
                string[] dd = line.Split(",");
                if (Int32.Parse(dd[0]) == id)
                {
                    Note note = new Note();
                    note.Etid1 = id;
                    note.Matiere = dd[1];
                    note.Session = dd[2];
                    note.Noten = Double.Parse(dd[3], System.Globalization.CultureInfo.InvariantCulture);
                    notes.Add(note);
                }
                line = sr.ReadLine();
            }
            sr.Close();
            return notes;
        }
        public List<Note> AllNoteBy(string matiere, string session)
        {
            List<Note> notes = new List<Note>();
            StreamReader sr = new StreamReader(FileNote);
            string line = sr.ReadLine();

            while (line != null)
            {
                string[] dd = line.Split(",");
                int id = Int32.Parse(dd[0]);
                string matierem = dd[1];
                string sessions = dd[2];
                double note = Double.Parse(dd[3], System.Globalization.CultureInfo.InvariantCulture);

                if (matierem == matiere || sessions == session)
                {
                    notes.Add(new Note
                    {
                        Etid1 = id,
                        Matiere = matierem,
                        Session = sessions,
                        Noten = note
                    });
                }
                line = sr.ReadLine();
            }
            sr.Close();
            return notes;
        }
        public double Moyenne(string Rechmatiere)
        {
            double total = 0;
            int count = 0;

            StreamReader sr = new StreamReader(FileNote);
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] dd = line.Split(",");
                if (dd[1] == Rechmatiere)
                {
                    double note = Double.Parse(dd[3], System.Globalization.CultureInfo.InvariantCulture);
                    total += note;
                    count++;
                }
                line = sr.ReadLine();
            }
            sr.Close();

            if (count == 0) return 0;
            return total / count;
        }
        public double CalculerTauxReussite(string Rechmatiere)
        {
            int total = 0;
            int reussites = 0;

            StreamReader sr = new StreamReader(FileNote);
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] dd = line.Split(",");
                if (dd[1] == Rechmatiere)
                {
                    double note = Double.Parse(dd[3], System.Globalization.CultureInfo.InvariantCulture);
                    total++;
                    if (note >= 10) reussites++;
                }
                line = sr.ReadLine();
            }
            sr.Close();

            if (total == 0) return 0;
            return (100.0 * reussites) / total;
        }
    }
}

