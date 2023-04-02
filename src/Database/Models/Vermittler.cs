using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Vermittler
    {
        public Vermittler()
        {
            Name = string.Empty;
            Vorname = string.Empty;
            Funktion = string.Empty;
            GueltigBis = DateTime.MaxValue;
        }

        [Key]
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Vorname { get; set; }

        [Required]
        public DateTime Geburtsdatum { get; set; }

        public string? Funktion { get; set; }

        public string? Kommentar { get; set; }
        public DateTime GueltigVon { get; set; }

        public DateTime GueltigBis { get; set; }

        // Relation
        public ICollection<Adresse>? Adressen { get; set; }
    }
}