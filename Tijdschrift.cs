using System;

namespace KlassenEnEvents
{
    public enum Verschijningsperiode
    {
        Dagelijks,
        Wekelijks,
        Maandelijks
    }

    public class Tijdschrift : Boek
    {
        public Verschijningsperiode Periode { get; set; }

        public Tijdschrift(string isbn, string naam, string uitgever, double prijs, Verschijningsperiode periode)
            : base(isbn, naam, uitgever, prijs)
        {
            Periode = periode;
        }
    }
}
