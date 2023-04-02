namespace WebApi.DAL.Dto
{
    public class VermittlerDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Vorname { get; set; }

        public DateTime Geburtsdatum { get; set; }

        public string? Funktion { get; set; }

        public string? Kommentar { get; set; }

        public DateTime GueltigVon { get; set; }

        public DateTime GueltigBis { get; set; }

        public List<AdresseDto> Adressen { get; set; }

        public VermittlerDto()
        {
            Name = string.Empty;
            Vorname = string.Empty;
            Funktion = string.Empty;
            GueltigBis = DateTime.MaxValue;
            Adressen = new List<AdresseDto>();
        }
    }
}