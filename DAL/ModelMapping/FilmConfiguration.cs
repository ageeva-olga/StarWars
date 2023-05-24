﻿using Logic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DAL.ModelMapping
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder
                .ToTable("Films")
                .HasKey(x => x.Id);

            builder
                 .HasMany(p => p.Characters)
                 .WithMany(p => p.Films)
                 .UsingEntity(e => e.ToTable("FilmsWithCharacters"));
        }
    }
}
