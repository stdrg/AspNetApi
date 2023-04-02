using Microsoft.AspNetCore.Http.HttpResults;
using WebApi.DAL.Dto;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DAL
{
    public class VermittlerRepository
    {
        private DatabaseContext _databaseContext;
        private DatabaseHistorieContext _databaseHistorieContext;

        public VermittlerRepository(DatabaseContext databaseContext, DatabaseHistorieContext databaseHistorieContext)
        {
            _databaseContext = databaseContext;
            _databaseHistorieContext = databaseHistorieContext;
        }

        public VermittlerDto? GetVermittler(long id)
        {
            var vermittler = _databaseContext.Vermittler.FirstOrDefault(x => x.Id == id);
            var adressen = _databaseContext.Adressen.Where(x => x.VermittlerId == id).ToList();

            if (vermittler == null)
            {
                return null;
            }

            var v = ConvertToVermittlerDto(vermittler);
            if (adressen != null)
            {
                var a = adressen.ConvertAll(a => ConvertToAdressenDto(a));
                v.Adressen = a;
            }
            return v;
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

        public VermittlerDto? PostVermittler(VermittlerSetDto vermittlerDto)
        {
            var vermittler = new Vermittler
            {
                Name = vermittlerDto.Name,
                Vorname = vermittlerDto.Vorname,
                Geburtsdatum = vermittlerDto.Geburtsdatum,
                GueltigVon = vermittlerDto.GueltigVon,
                GueltigBis = (vermittlerDto == null) ? DateTime.MaxValue : vermittlerDto.GueltigBis,
                Funktion = vermittlerDto.Funktion,
                Kommentar = vermittlerDto.Kommentar
            };

            if (vermittlerDto == null)
            {
                return null;
            }
            else
            {
                long nextId = _databaseContext.Vermittler.Any() ? _databaseContext.Vermittler.Max(x => x.Id) + 1 : 1;
                _databaseContext.Vermittler.Add(vermittler);
                _databaseContext.SaveChanges();
                _databaseHistorieContext.VermittlerHistorie.Add(new VermittlerHistorie()
                {
                    Name = vermittler.Name,
                    Vorname = vermittler.Vorname,
                    DatabaseId = nextId,
                    Funktion = vermittler.Funktion,
                    Kommentar = vermittler.Kommentar,
                    Geburtsdatum = vermittler.Geburtsdatum,
                    GueltigVon = vermittler.GueltigVon,
                    GueltigBis = vermittler.GueltigBis,
                    ErstelltAm = DateTime.Now,
                });
                _databaseHistorieContext.SaveChanges();
                return ConvertToVermittlerDto(vermittler);
            }
        }

        public List<VermittlerDto> GetAllVermittler()
        {
            return _databaseContext.Vermittler.ToList().ConvertAll(x => ConvertToVermittlerDto(x));
        }

        private VermittlerDto ConvertToVermittlerDto(Vermittler vermittler)
        {
            return new VermittlerDto
            {
                Id = vermittler.Id,
                Name = vermittler.Name,
                Vorname = vermittler.Vorname,
                Funktion = vermittler.Funktion,
                Geburtsdatum = vermittler.Geburtsdatum,
                GueltigBis = vermittler.GueltigBis,
                GueltigVon = vermittler.GueltigVon,
                Kommentar = vermittler.Kommentar
            };
        }

        public VermittlerDto? PutVermittler(long id, VermittlerSetDto vermittler)
        {
            var dbVermittler = _databaseContext.Vermittler.FirstOrDefault(x => x.Id == id);
            if (dbVermittler == null)
                return null;
            dbVermittler.Name = string.IsNullOrEmpty(vermittler.Name) ? dbVermittler.Name : vermittler.Name;
            dbVermittler.Vorname = string.IsNullOrEmpty(vermittler.Vorname) ? dbVermittler.Vorname : vermittler.Vorname;
            dbVermittler.Kommentar = string.IsNullOrEmpty(vermittler.Kommentar) ? dbVermittler.Kommentar : vermittler.Kommentar;
            dbVermittler.Funktion = string.IsNullOrEmpty(vermittler.Kommentar) ? dbVermittler.Funktion : vermittler.Funktion;
            dbVermittler.GueltigVon = vermittler.GueltigVon == DateTime.MinValue ? dbVermittler.GueltigVon : vermittler.GueltigVon;
            dbVermittler.GueltigBis = vermittler.GueltigBis == DateTime.MaxValue ? dbVermittler.GueltigBis : vermittler.GueltigBis;
            dbVermittler.Geburtsdatum = vermittler.Geburtsdatum == DateTime.MinValue ? dbVermittler.Geburtsdatum : vermittler.Geburtsdatum;
            _databaseContext.Update(dbVermittler);
            _databaseContext.SaveChanges();
            // History
            CreateNewHistEntry(dbVermittler);

            return ConvertToVermittlerDto(dbVermittler);
        }

        private void CreateNewHistEntry(Vermittler dbVermittler)
        {
            // ändere GeaendertAM im Letzten entrag
            var lastHistEntry = _databaseHistorieContext.VermittlerHistorie.Where(x => x.DatabaseId == dbVermittler.Id)
                .OrderByDescending(x => x.ErstelltAm).FirstOrDefault();
            var createTime = DateTime.Now;
            if (lastHistEntry != null)
            {
                lastHistEntry.GeaendertAm = createTime;
                _databaseHistorieContext.VermittlerHistorie.Update(lastHistEntry);
                _databaseHistorieContext.SaveChanges();
            }
            // fügen neuen datensatz hinzu
            _databaseHistorieContext.VermittlerHistorie.Add(new VermittlerHistorie()
            {
                Name = dbVermittler.Name,
                Vorname = dbVermittler.Vorname,
                DatabaseId = dbVermittler.Id,
                Funktion = dbVermittler.Funktion,
                Kommentar = dbVermittler.Kommentar,
                Geburtsdatum = dbVermittler.Geburtsdatum,
                GueltigVon = dbVermittler.GueltigVon,
                GueltigBis = dbVermittler.GueltigBis,
                ErstelltAm = createTime,
            });
            _databaseHistorieContext.SaveChanges();
        }

        public VermittlerDto? DeleteVermittler(long id)
        {
            var vermittler = _databaseContext.Vermittler.FirstOrDefault(x => x.Id == id);
            if (vermittler != null)
            {
                _databaseContext.Remove(vermittler);
                _databaseContext.SaveChanges();
                var lastHistEntry = _databaseHistorieContext.VermittlerHistorie.Where(x => x.DatabaseId == vermittler.Id)
               .OrderByDescending(x => x.ErstelltAm).FirstOrDefault();
                lastHistEntry.GeaendertAm = DateTime.Now;
                _databaseHistorieContext.VermittlerHistorie.Update(lastHistEntry);
                _databaseHistorieContext.SaveChanges();
                return ConvertToVermittlerDto(vermittler);
            }
            else return null;
        }
    }
}