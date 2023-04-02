using Database.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.RegularExpressions;

namespace WebApi.DAL.Dto
{
    public class AdresseSetDto : IValidatableObject
    {
        public AdresseSetDto()
        {
            Postleitzahl = string.Empty;
            Ort = string.Empty;
            Straße = string.Empty;
            Hausnummer = string.Empty;
            GueltigVon = DateTime.MinValue;
            GueltigBis = DateTime.MaxValue;
        }

        public string Straße { get; set; }

        public string Hausnummer { get; set; }

        public string Postleitzahl { get; set; }

        public string Ort { get; set; }

        public DateTime GueltigVon { get; set; }

        public DateTime GueltigBis { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Regex regex = new Regex(@"^\d{5}$");
            bool plzIsValid = regex.IsMatch(Postleitzahl);
            if (string.IsNullOrEmpty(Straße))
            {
                yield return new ValidationResult("Straße ist Pflicht", new[] { nameof(Straße) });
            }
            if (string.IsNullOrEmpty(Hausnummer))
            {
                yield return new ValidationResult("Hausnummer ist Pflicht", new[] { nameof(Hausnummer) });
            }
            if (!plzIsValid)
            {
                yield return new ValidationResult("Postleitzahl ist Pflicht", new[] { nameof(Postleitzahl) });
            }
            if (string.IsNullOrEmpty(Ort))
            {
                yield return new ValidationResult("Ort ist Pflicht", new[] { nameof(Ort) });
            }
            if (GueltigVon == DateTime.MinValue)
            {
                yield return new ValidationResult("GueltigVon ist Pflicht", new[] { nameof(GueltigVon) });
            }
        }
    }
}