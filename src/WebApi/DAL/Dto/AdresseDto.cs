using Database.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApi.DAL.Dto
{
    public class AdresseDto
    {
        public AdresseDto()
        {
            Postleitzahl = string.Empty;
            Ort = string.Empty;
            Straße = string.Empty;
            Hausnummer = string.Empty;
            GueltigBis = DateTime.MaxValue;
        }

        public long Id { get; set; }

        public long VermittlerId { get; set; }

        public string Straße { get; set; }

        public string Hausnummer { get; set; }

        public string Postleitzahl { get; set; }

        public string Ort { get; set; }

        public DateTime GueltigVon { get; set; }

        public DateTime GueltigBis { get; set; }
    }
}