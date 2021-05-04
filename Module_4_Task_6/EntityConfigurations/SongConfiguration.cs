using System.Collections.Generic;
using Module_4_Task_6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module_4_Task_6.EntityConfigurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("SongId");
            builder.Property(s => s.Title).IsRequired().HasColumnName("Title").HasMaxLength(255);
            builder.Property(s => s.DurationSeconds).IsRequired().HasColumnName("DurationSeconds");
            builder.Property(s => s.ReleasedDate).IsRequired().HasColumnName("ReleasedDate").HasColumnType("date");
        }
    }
}
