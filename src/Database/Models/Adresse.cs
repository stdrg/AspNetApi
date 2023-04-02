using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Adresse
    {
        public Adresse()
        {
            Postleitzahl = string.Empty;
            Ort = string.Empty;
            Straße = string.Empty;
            Hausnummer = string.Empty;
            GueltigBis = DateTime.MaxValue;
        }

        [Key]
        public long Id { get; set; }

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

        // Relation
        public Vermittler? Vermittler { get; set; }

        public long VermittlerId { get; set; }
    }
}