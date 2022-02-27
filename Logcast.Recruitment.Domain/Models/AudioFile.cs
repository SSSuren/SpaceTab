using System;

namespace Logcast.Recruitment.Domain.Models
{
    public class AudioFile : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string ContentType { get; set; }
        public string Path { get; set; }
    }
}
