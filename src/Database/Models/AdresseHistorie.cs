using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class AdresseHistorie
    {
        public AdresseHistorie()
        {
            Postleitzahl = string.Empty;
            Ort = string.Empty;
            Straße = string.Empty;
            Hausnummer = string.Empty;
            GueltigBis = DateTime.MaxValue;
            GeaendertAm = DateTime.MaxValue;
        }

        [Key]
        public long Id { get; set; }

        public long DatabaseId { get; set; }
        public long VermittlerDatabaseId { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Postleitzahl muss 5 Ziffern enthalten.")]
        public string Postleitzahl { get; set; }

        [Required]
        public string Ort { get; set; }

        [Required]
        public string Straße { get; set; }

        [Required]
        public string Hausnummer { get; set; }

        [Required]
        public DateTime GueltigVon { get; set; }

        public DateTime GueltigBis { get; set; }

        [Required]
        public DateTime ErstelltAm { get; set; }

        public DateTime? GeaendertAm { get; set; }
    }
}