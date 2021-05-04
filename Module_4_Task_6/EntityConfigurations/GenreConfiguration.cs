using System.Collections.Generic;
using Module_4_Task_6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module_4_Task_6.EntityConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre").HasKey(g => g.Id);
            builder.Property(g => g.Id).HasColumnName("GenreId");
            builder.Property(g => g.Title).IsRequired().HasColumnName("Title").HasMaxLength(100);

            builder.HasMany(g => g.Songs)
                .WithOne(s => s.Genre)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
