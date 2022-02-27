using System;

namespace Logcast.Recruitment.Domain.Models
{
    public class AudioMetaData : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid AudioFileId { get; set; }
        public string TrackTitle { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public DateTime? Released { get; set; }

        public AudioFile AudioFile { get; set; }
    }
}
