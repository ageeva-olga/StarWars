using Logic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.ModelMapping
{
    public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
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
