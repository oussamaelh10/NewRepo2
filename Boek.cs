using System;

namespace KlassenEnEvents
{
    public class Boek
    {
        public string Isbn { get; set; }
        public string Naam { get; set; }
        public string Uitgever { get; set; }
        private double prijs;

        public double Prijs
        {
            get { return prijs; }
            set
            {
                if (value >= 5 && value <= 50)
                    prijs = value;
                else
                    throw new ArgumentOutOfRangeException("Prijs moet tussen 5€ en 50€ liggen.");
            }
        }

        public Boek(string isbn, string naam, string uitgever, double prijs)
        {
            Isbn = isbn;
            Naam = naam;
            Uitgever = uitgever;
            Prijs = prijs;
        }

        public override string ToString()
        {
            return $"ISBN: {Isbn}, Naam: {Naam}, Uitgever: {Uitgever}, Prijs: {Prijs}€";
        }

        public void Lees()
        {
            Console.WriteLine($"Je leest het boek '{Naam}'.");
        }
    }
}
