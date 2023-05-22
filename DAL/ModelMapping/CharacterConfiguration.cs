using DAL.DTO;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelDTO
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder
                .ToTable("Characters")
                .HasKey(x => x.Id);

            builder
                .HasOne(u => u.Planet).WithMany(p => p.Characters)
                .HasForeignKey(x => x.PlanetId);

            builder
                 .HasMany(p => p.Films)
                 .WithMany(p => p.Characters)
                 .UsingEntity(e => e.ToTable("CharactersInFilms"));
        }
    }
}
