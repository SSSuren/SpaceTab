using Logcast.Recruitment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logcast.Recruitment.DataAccess.Entities.Configurations
{
    public class AudioFileConfiguration : IEntityTypeConfiguration<AudioFile>
    {
        public void Configure(EntityTypeBuilder<AudioFile> builder)
        {
            builder.ToTable("AudioFile");
            builder.HasKey(f => f.Id);
            
            builder.Property(f => f.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(f => f.Name).HasMaxLength(50).IsRequired();
            builder.Property(f => f.Size).IsRequired();
            builder.Property(f => f.ContentType).HasMaxLength(50).IsRequired();
            builder.Property(f => f.Path).IsRequired();
        }
    }
}
