using Microsoft.AspNetCore.Http.HttpResults;
using WebApi.DAL.Dto;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace WebApi.DAL
{
    public class HistorieRepository
    {
        private DatabaseHistorieContext _databaseContext;

        public HistorieRepository(DatabaseHistorieContext databaseHistorieContext)
        {
            _databaseContext = databaseHistorieContext;
        }

        public List<AdresseHistorieDto>? GetAddressHistory(long VermittlerId)
        {
            var hist = _databaseContext.AdressenHistorie.Where(x => x.VermittlerDatabaseId == VermittlerId).ToList();
            return hist.ConvertAll(y => ConvertToAdressenHistorieDto(y));
        }

        public List<VermittlerHistorieDto>? GetVermittlerHistory(long VermittlerId)
        {
            var hist = _databaseContext.VermittlerHistorie.Where(x => x.DatabaseId == VermittlerId).ToList();

            return hist.ConvertAll(y => ConvertToVermittlerHistorieDto(y));
        }

        private AdresseHistorieDto ConvertToAdressenHistorieDto(AdresseHistorie adresse)
        {
            return new AdresseHistorieDto
            {
                Id = adresse.Id,
                DatabaseId = adresse.DatabaseId,
                VermittlerDatabaseId = adresse.VermittlerDatabaseId,
                Straße = adresse.Straße,
                Hausnummer = adresse.Hausnummer,
                Postleitzahl = adresse.Postleitzahl,
                Ort = adresse.Ort,
                GueltigVon = adresse.GueltigVon,
                GueltigBis = adresse.GueltigBis,
                ErstelltAm = adresse.ErstelltAm,
                GeaendertAm = adresse.GeaendertAm,
            };
        }

        private VermittlerHistorieDto ConvertToVermittlerHistorieDto(VermittlerHistorie vermittler)
        {
            return new VermittlerHistorieDto
            {
                Id = vermittler.Id,
                DatabaseId = vermittler.DatabaseId,
                Name = vermittler.Name,
                Vorname = vermittler.Vorname,
                Funktion = vermittler.Funktion,
                Geburtsdatum = vermittler.Geburtsdatum,
                GueltigBis = vermittler.GueltigBis,
                GueltigVon = vermittler.GueltigVon,
                Kommentar = vermittler.Kommentar,
                ErstelltAm = vermittler.ErstelltAm,
                GeaendertAM = vermittler.GeaendertAm
            };
        }
    }
}