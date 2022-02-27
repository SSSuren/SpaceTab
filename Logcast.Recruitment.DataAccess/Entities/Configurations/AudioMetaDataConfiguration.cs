using Logcast.Recruitment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logcast.Recruitment.DataAccess.Entities.Configurations
{
    public class AudioMetaDataConfiguration : IEntityTypeConfiguration<AudioMetaData>
    {
        public void Configure(EntityTypeBuilder<AudioMetaData> builder)
        {
            builder.ToTable("AudioMetaData");
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.AudioFile)
                   .WithMany()
                   .HasForeignKey(m => m.AudioFileId);
            
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(m => m.TrackTitle).HasMaxLength(50).IsRequired();
            builder.Property(m => m.Artist).HasMaxLength(50).IsUnicode().IsRequired(false);
            builder.Property(m => m.Album).HasMaxLength(50).IsUnicode().IsRequired(false);
            builder.Property(m => m.Released).IsRequired(false);
        }
    }
}
