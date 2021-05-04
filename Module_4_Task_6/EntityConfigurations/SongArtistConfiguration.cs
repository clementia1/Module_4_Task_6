using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_Task_6.Entities;

namespace Module_4_Task_6.EntityConfigurations
{
    public class SongArtistConfiguration : IEntityTypeConfiguration<SongArtist>
    {
        public void Configure(EntityTypeBuilder<SongArtist> builder)
        {
            builder.ToTable("SongArtist").HasKey(sa => new { sa.SongId, sa.ArtistId });

            builder.HasOne(h => h.Artist)
                .WithMany(w => w.Songs)
                .HasForeignKey(h => h.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(h => h.Song)
                .WithMany(w => w.Artists)
                .HasForeignKey(h => h.SongId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
