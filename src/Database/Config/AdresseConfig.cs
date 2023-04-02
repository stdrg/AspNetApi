using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;

namespace Database.Config
{
    internal class AdresseConfig : IEntityTypeConfiguration<Adresse>
    {
        public void Configure
            (EntityTypeBuilder<Adresse> entity)
        {
            entity.HasOne(a => a.Vermittler)
                .WithMany(v => v.Adressen)
                .HasForeignKey(a => a.VermittlerId);
        }
    }
}