using KlassenEnEvents;
using System;
using System.Collections.Generic;



class Program
{
    static List<Boek> boeken = new List<Boek>();
    static List<Tijdschrift> tijdschriften = new List<Tijdschrift>();
    static List<Bestelling<object>> bestellingen = new List<Bestelling<object>>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Voeg een boek toe");
            Console.WriteLine("2. Voeg een tijdschrift toe");
            Console.WriteLine("3. Plaats een bestelling");
            Console.WriteLine("4. Afsluiten");

            string keuze = Console.ReadLine();

            switch (keuze)
            {
                case "1":
                    VoegItemToe(boeken, "Boek");
                    break;
                case "2":
                    VoegItemToe(tijdschriften, "Tijdschrift");
                    break;
                case "3":
                    PlaatsBestelling();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                    break;
            }
        }
    }


    static void VoegItemToe<T>(List<T> lijst, string itemType) where T : class
    {
        Console.WriteLine($"Voer ISBN in voor het {itemType}:");
        string isbn = Console.ReadLine();
        Console.WriteLine($"Voer de naam in voor het {itemType}:");
        string naam = Console.ReadLine();
        Console.WriteLine($"Voer de uitgever in voor het {itemType}:");
        string uitgever = Console.ReadLine();
        Console.WriteLine($"Voer de prijs in voor het {itemType}:");
        double prijs = double.Parse(Console.ReadLine());


        if (typeof(T) == typeof(Boek))
        {
            var boek = new Boek(isbn, naam, uitgever, prijs);
            boeken.Add(boek);
        }
        else if (typeof(T) == typeof(Tijdschrift))
        {
            Console.WriteLine($"Kies de verschijningsperiode (1 voor Dagelijks, 2 voor Wekelijks, 3 voor Maandelijks) voor het {itemType}:");
            int periodeIndex = int.Parse(Console.ReadLine());
            Verschijningsperiode periode = (Verschijningsperiode)(periodeIndex - 1);

            var tijdschrift = new Tijdschrift(isbn, naam, uitgever, prijs, periode);
            tijdschriften.Add(tijdschrift);
        }

        Console.WriteLine($"{itemType} '{naam}' is toegevoegd.");
    }

    static void PlaatsBestelling()
    {
        Console.WriteLine("Selecteer een item om te bestellen:");
        Console.WriteLine("1. Boek");
        Console.WriteLine("2. Tijdschrift");
        string keuze = Console.ReadLine();

        if (keuze == "1")
        {
            BestelItem(boeken, "Boek");
        }
        else if (keuze == "2")
        {
            BestelItem(tijdschriften, "Tijdschrift");
        }
        else
        {
            Console.WriteLine("Ongeldige keuze.");
        }
    }

    static void BestelItem<T>(List<T> lijst, string itemType) where T : class
    {
        Console.WriteLine($"Beschikbare {itemType}en:");
        for (int i = 0; i < lijst.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {lijst[i]}");
        }

        Console.WriteLine($"Kies een {itemType} om te bestellen (1-{lijst.Count}):");
        int index = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("Voer de bestelhoeveelheid in:");
        int aantal = int.Parse(Console.ReadLine());

        var bestelling = new Bestelling<object>(lijst[index], DateTime.Now, aantal);
        bestellingen.Add(bestelling);

        Console.WriteLine($"Bestelling voor {itemType} '{lijst[index]}' is geplaatst.");
    }
}