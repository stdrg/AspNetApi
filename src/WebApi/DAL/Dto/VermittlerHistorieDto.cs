using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Dto
{
    public class VermittlerHistorieDto
    {
        public VermittlerHistorieDto()
        {
            Name = string.Empty;
            Vorname = string.Empty;
            Funktion = string.Empty;
            GueltigBis = DateTime.MaxValue;
            GeaendertAM = DateTime.MaxValue;
        }

        public long Id { get; set; }

        public long DatabaseId { get; set; }

        public string Name { get; set; }

        public string Vorname { get; set; }

        public DateTime Geburtsdatum { get; set; }

        public string? Funktion { get; set; }

        public string? Kommentar { get; set; }

        public DateTime GueltigVon { get; set; }

        public DateTime GueltigBis { get; set; }

        public DateTime ErstelltAm { get; set; }

        public DateTime GeaendertAM { get; set; }
    }
}