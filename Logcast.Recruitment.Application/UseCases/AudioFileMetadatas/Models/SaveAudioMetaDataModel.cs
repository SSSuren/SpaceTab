using System;

namespace Logcast.Recruitment.Application.UseCases.AudioFileMetadatas.Models
{
    public class SaveAudioMetaDataModel
    {
        public Guid AudioFileId { get; set; }
        public string TrackTitle { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public DateTime? Released { get; set; }
    }
}
