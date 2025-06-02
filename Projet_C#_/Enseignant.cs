namespace Projet_C_
{
    internal class Enseignant
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _motDePasse;

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string MotDePasse { get => _motDePasse; set => _motDePasse = value; }
    }
}
