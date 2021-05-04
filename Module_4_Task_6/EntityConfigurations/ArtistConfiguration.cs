using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_Task_6.Entities;

namespace Module_4_Task_6.EntityConfigurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("ArtistId");
            builder.Property(a => a.Name).IsRequired().HasColumnName("Name").HasMaxLength(100);
            builder.Property(a => a.DateOfBirth).IsRequired().HasColumnName("DateOfBirth").HasColumnType("date");
            builder.Property(a => a.Phone).HasColumnName("Phone").HasMaxLength(20);
            builder.Property(a => a.Email).HasColumnName("Email").HasMaxLength(255);
            builder.Property(a => a.InstagramUrl).HasColumnName("InstagramUrl").HasMaxLength(255);
        }
    }
}
