using Microsoft.EntityFrameworkCore;
using Database;
using Database.Models;

namespace WebApi.Seeding
{
    public static class SeedData
    {
        public static void InitializeDatabaseContext(DatabaseContext context)
        {
            context.Adressen.Add(new Adresse
            {
                Id = 1,
                VermittlerId = 1,
                Postleitzahl = "12627",
                Ort = "Berlin",
                Straße = "Riesaer Straße",
                Hausnummer = "2A",
                GueltigVon = new DateTime(2015, 5, 20),
                GueltigBis = new DateTime(2023, 5, 20),
            });
            context.Adressen.Add(new Adresse
            {
                Id = 2,
                VermittlerId = 1,
                Postleitzahl = "13125",
                Ort = "Berlin",
                Straße = "Wiltbergstraße",
                Hausnummer = "18b",
                GueltigVon = new DateTime(2015, 5, 20)
            });
            context.Adressen.Add(new Adresse
            {
                Id = 3,
                VermittlerId = 2,
                Postleitzahl = "22587",
                Ort = "Hamburg",
                Straße = "Am Klingenberg",
                Hausnummer = "90",
                GueltigVon = new DateTime(2021, 5, 20),
            });
            context.Vermittler.Add(new Vermittler
            {
                Id = 1,
                Vorname = "Hans",
                Name = "Maiser",
                Funktion = "Moderator",
                Geburtsdatum = new DateTime(1950, 2, 21),
                GueltigVon = new DateTime(2015, 5, 20),
                GueltigBis = new DateTime(2023, 5, 20),
            });
            context.Vermittler.Add(new Vermittler
            {
                Id = 2,
                Vorname = "Benjamin",
                Name = "Linus",
                Funktion = "Vertriebsassistent",
                Geburtsdatum = new DateTime(1956, 5, 30),
                GueltigVon = new DateTime(2022, 7, 20),
            });

            context.SaveChanges();
        }

        public static void InitializeDatabaseContext(DatabaseHistorieContext context)
        {
            context.AdressenHistorie.Add(new AdresseHistorie
            {
                Id = 1,
                DatabaseId = 1,
                VermittlerDatabaseId = 1,
                Postleitzahl = "12627",
                Ort = "Berlin",
                Straße = "Riesaer Straße",
                Hausnummer = "2A",
                GueltigVon = new DateTime(2015, 5, 20),
                GueltigBis = new DateTime(2023, 5, 20),
                ErstelltAm = new DateTime(2015, 5, 20)
            });
            context.AdressenHistorie.Add(new AdresseHistorie
            {
                Id = 2,
                DatabaseId = 2,
                VermittlerDatabaseId = 1,
                Postleitzahl = "13125",
                Ort = "Berlin",
                Straße = "Wiltbergstraße",
                Hausnummer = "18b",
                GueltigVon = new DateTime(2015, 5, 20),
                ErstelltAm = new DateTime(2015, 5, 20)
            });
            context.AdressenHistorie.Add(new AdresseHistorie
            {
                Id = 3,
                DatabaseId = 3,
                VermittlerDatabaseId = 2,
                Postleitzahl = "22587",
                Ort = "Hamburg",
                Straße = "Am Klingenberg",
                Hausnummer = "90",
                GueltigVon = new DateTime(2021, 5, 20),
                ErstelltAm = new DateTime(2021, 5, 20)
            });
            context.VermittlerHistorie.Add(new VermittlerHistorie
            {
                Id = 1,
                DatabaseId = 1,
                Vorname = "Hans",
                Name = "Maiser",
                Funktion = "Moderator",
                Geburtsdatum = new DateTime(1950, 2, 21),
                GueltigVon = new DateTime(2015, 5, 20),
                GueltigBis = new DateTime(2023, 5, 20),
                ErstelltAm = new DateTime(2023, 5, 20)
            });
            context.VermittlerHistorie.Add(new VermittlerHistorie
            {
                Id = 2,
                DatabaseId = 2,
                Vorname = "Benjamin",
                Name = "Linus",
                Funktion = "Vertriebsassistent",
                Geburtsdatum = new DateTime(1956, 5, 30),
                GueltigVon = new DateTime(2022, 7, 20),
                ErstelltAm = new DateTime(2022, 7, 20),
            });

            context.SaveChanges();
        }
    }
}