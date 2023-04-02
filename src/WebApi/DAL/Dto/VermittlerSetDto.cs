using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApi.DAL.Dto
{
    public class VermittlerSetDto : IValidatableObject
    {
        public string Name { get; set; }

        public string Vorname { get; set; }

        public DateTime Geburtsdatum { get; set; }

        public string? Funktion { get; set; }

        public string? Kommentar { get; set; }

        public DateTime GueltigVon { get; set; }

        public DateTime GueltigBis { get; set; }

        public VermittlerSetDto()
        {
            Name = string.Empty;
            Vorname = string.Empty;
            Funktion = string.Empty;
            Geburtsdatum = DateTime.MinValue;
            GueltigVon = DateTime.MinValue;
            GueltigBis = DateTime.MaxValue;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Vorname))
            {
                yield return new ValidationResult("Vorname ist Pflicht", new[] { nameof(Vorname) });
            }
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name ist Pflicht", new[] { nameof(Name) });
            }
            if (Geburtsdatum == DateTime.MinValue)
            {
                yield return new ValidationResult("Geburtsdatum ist Pflicht", new[] { nameof(Geburtsdatum) });
            }
            if (GueltigVon == DateTime.MinValue)
            {
                yield return new ValidationResult("GueltigVon ist Pflicht", new[] { nameof(GueltigVon) });
            }
        }
    }
}