using DAL.DTO;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelMapping
{
    public class PlanetConfiguration : IEntityTypeConfiguration<PlanetDTO>
    {
        public void Configure(EntityTypeBuilder<PlanetDTO> builder)
        {
            builder
                .ToTable("Planets")
                .HasKey(x => x.Id);

            builder
                .HasMany(u => u.Characters).WithOne(p => p.Planet)
                .HasForeignKey(x => x.PlanetId);
        }
    }
}
