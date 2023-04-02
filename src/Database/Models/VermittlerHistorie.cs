using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class VermittlerHistorie
    {
        public VermittlerHistorie()
        {
            Name = string.Empty;
            Vorname = string.Empty;
            Funktion = string.Empty;
            GueltigBis = DateTime.MaxValue;
            GeaendertAm = DateTime.MaxValue;
        }

        [Key]
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

        public DateTime GeaendertAm { get; set; }
    }
}