using Microsoft.AspNetCore.Http.HttpResults;
using WebApi.DAL.Dto;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace WebApi.DAL
{
    public class AdressenRepository
    {
        private DatabaseContext _databaseContext;
        private DatabaseHistorieContext _databaseHistorieContext;

        public AdressenRepository(DatabaseContext databaseContext, DatabaseHistorieContext databaseHistorieContext)
        {
            _databaseContext = databaseContext;
            _databaseHistorieContext = databaseHistorieContext;
        }

        public AdresseDto? GetAdresse(long id)
        {
            var adresse = _databaseContext.Adressen.FirstOrDefault(x => x.Id == id);

            if (adresse == null)
            {
                return null;
            }

            return ConvertToAdressenDto(adresse);
        }

        private AdresseDto ConvertToAdressenDto(Adresse adresse)
        {
            return new AdresseDto
            {
                Id = adresse.Id,
                VermittlerId = adresse.VermittlerId,
                Straße = adresse.Straße,
                Hausnummer = adresse.Hausnummer,
                Postleitzahl = adresse.Postleitzahl,
                Ort = adresse.Ort,
                GueltigVon = adresse.GueltigVon,
                GueltigBis = adresse.GueltigBis
            };
        }

        public AdresseDto? PostAdresse(AdresseSetDto adresseDto, long VermittlerId)
        {
            var vermittler = _databaseContext.Vermittler.FirstOrDefault(x => x.Id == VermittlerId);
            if (vermittler == null)
                return null;
            // Validiere PLZ

            var adresse = new Adresse
            {
                VermittlerId = VermittlerId,
                Straße = adresseDto.Straße,
                Hausnummer = adresseDto.Hausnummer,
                Postleitzahl = adresseDto.Postleitzahl,
                Ort = adresseDto.Ort,
                GueltigVon = adresseDto.GueltigVon,
                GueltigBis = adresseDto.GueltigBis,
            };

            if (adresseDto == null)
            {
                return null;
            }
            else
            {
                long nextId = _databaseContext.Adressen.Any() ? _databaseContext.Adressen.Max(x => x.Id) + 1 : 1;
                _databaseContext.Add(adresse);
                _databaseContext.SaveChanges();
                _databaseHistorieContext.AdressenHistorie.Add(new AdresseHistorie()
                {
                    DatabaseId = nextId,
                    VermittlerDatabaseId = VermittlerId,
                    Straße = adresse.Straße,
                    Hausnummer = adresse.Hausnummer,
                    Postleitzahl = adresse.Postleitzahl,
                    Ort = adresse.Ort,
                    GueltigVon = adresse.GueltigVon,
                    GueltigBis = adresse.GueltigBis,
                    ErstelltAm = DateTime.Now,
                });
                _databaseHistorieContext.SaveChanges();

                return ConvertToAdressenDto(adresse);
            }
        }

        public AdresseDto? PutAdresse(long id, AdresseSetDto adresse)
        {
            var dbAdresse = _databaseContext.Adressen.FirstOrDefault(x => x.Id == id);
            if (dbAdresse == null)
                return null;

            dbAdresse.Straße = string.IsNullOrEmpty(adresse.Straße) ? dbAdresse.Straße : adresse.Straße;
            dbAdresse.Hausnummer = string.IsNullOrEmpty(adresse.Hausnummer) ? dbAdresse.Hausnummer : adresse.Hausnummer;
            dbAdresse.Postleitzahl = string.IsNullOrEmpty(adresse.Postleitzahl) ? dbAdresse.Postleitzahl : adresse.Postleitzahl;
            dbAdresse.Ort = string.IsNullOrEmpty(adresse.Ort) ? dbAdresse.Ort : adresse.Ort;
            dbAdresse.GueltigVon = adresse.GueltigVon == DateTime.MinValue ? dbAdresse.GueltigVon : adresse.GueltigVon;
            dbAdresse.GueltigBis = adresse.GueltigBis == DateTime.MaxValue ? dbAdresse.GueltigBis : adresse.GueltigBis;
            _databaseContext.Update(dbAdresse);
            _databaseContext.SaveChanges();

            CreateNewHistEntry(dbAdresse);
            return ConvertToAdressenDto(dbAdresse);
        }

        private void CreateNewHistEntry(Adresse dbAdresse)
        {
            var createTime = DateTime.Now;
            // ändere GeaendertAM im Letzten entrag
            var lastHistEntry = _databaseHistorieContext.AdressenHistorie.Where(x => x.DatabaseId == dbAdresse.Id)
                .OrderByDescending(x => x.ErstelltAm).FirstOrDefault();

            if (lastHistEntry != null)
            {
                lastHistEntry.GeaendertAm = createTime;
                _databaseHistorieContext.AdressenHistorie.Update(lastHistEntry);
                _databaseHistorieContext.SaveChanges();
            }
            // fügen neuen datensatz hinzu
            _databaseHistorieContext.AdressenHistorie.Add(new AdresseHistorie()
            {
                DatabaseId = dbAdresse.Id,
                VermittlerDatabaseId = dbAdresse.VermittlerId,
                Straße = dbAdresse.Straße,
                Hausnummer = dbAdresse.Hausnummer,
                Postleitzahl = dbAdresse.Postleitzahl,
                Ort = dbAdresse.Ort,
                GueltigVon = dbAdresse.GueltigVon,
                GueltigBis = dbAdresse.GueltigBis,
                ErstelltAm = createTime,
            });
            _databaseHistorieContext.SaveChanges();
        }

        public List<AdresseDto> GetAllAdressen()
        {
            return _databaseContext.Adressen.ToList().ConvertAll(x => ConvertToAdressenDto(x));
        }

        public AdresseDto? DeleteAdresse(long id)
        {
            var adresse = _databaseContext.Adressen.FirstOrDefault(x => x.Id == id);
            if (adresse != null)
            {
                _databaseContext.Remove(adresse);
                _databaseContext.SaveChanges();
                var lastHistEntry = _databaseHistorieContext.AdressenHistorie.Where(x => x.DatabaseId == adresse.Id)
               .OrderByDescending(x => x.ErstelltAm).FirstOrDefault();
                lastHistEntry.GeaendertAm = DateTime.Now;
                _databaseHistorieContext.AdressenHistorie.Update(lastHistEntry);
                _databaseHistorieContext.SaveChanges();
                return ConvertToAdressenDto(adresse);
            }
            else return null;
        }
    }
}