using System;
using System.Collections.Generic;

namespace KlassenEnEvents
{
    public class Bestelling<T>
    {
        public event EventHandler<Tuple<string, int, double>> ItemBesteld;

        private static int volgnummer = 1;
        private T t;
        private DateTime now;

        public int Id { get; }
        public T Item { get; }
        public DateTime Datum { get; }
        public int Aantal { get; }
        public Verschijningsperiode? Periode { get; }

        public Bestelling(T item, int aantal, Verschijningsperiode? periode = null)
        {
            Id = volgnummer++;
            Item = item;
            Datum = DateTime.Now;
            Aantal = aantal;
            Periode = periode;
        }

        public Bestelling(T t, DateTime now, int aantal)
        {
            this.t = t;
            this.now = now;
            Aantal = aantal;
        }

        public Tuple<string, int, double> Bestel()
        {
            double totalePrijs;
            string isbn;

            if (Item is Boek boek)
            {
                totalePrijs = Aantal * boek.Prijs;
                isbn = boek.Isbn;
            }
            else if (Item is Tijdschrift tijdschrift)
            {
                totalePrijs = Aantal * tijdschrift.Prijs;
                isbn = tijdschrift.Isbn;
            }
            else
            {
                throw new InvalidOperationException("Ongeldig itemtype.");
            }

            Tuple<string, int, double> bestellingInfo = Tuple.Create(isbn, Aantal, totalePrijs);

            // Trigger het event voor elk type item
            OnItemBesteld(bestellingInfo);

            return bestellingInfo;
        }

        protected virtual void OnItemBesteld(Tuple<string, int, double> bestellingInfo)
        {
            ItemBesteld?.Invoke(this, bestellingInfo);
        }
    }
}
