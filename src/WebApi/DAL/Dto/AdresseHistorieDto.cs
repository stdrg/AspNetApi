using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Dto
{
    public class AdresseHistorieDto
    {
        public AdresseHistorieDto()
        {
            Postleitzahl = string.Empty;
            Ort = string.Empty;
            Straße = string.Empty;
            Hausnummer = string.Empty;
            GueltigBis = DateTime.MaxValue;
            GeaendertAm = DateTime.MaxValue;
        }

        public long Id { get; set; }

        public long DatabaseId { get; set; }

        public long VermittlerDatabaseId { get; set; }

        public string Postleitzahl { get; set; }

        public string Ort { get; set; }

        public string Straße { get; set; }

        public string Hausnummer { get; set; }

        public DateTime GueltigVon { get; set; }

        public DateTime GueltigBis { get; set; }

        public DateTime ErstelltAm { get; set; }

        public DateTime? GeaendertAm { get; set; }
    }
}