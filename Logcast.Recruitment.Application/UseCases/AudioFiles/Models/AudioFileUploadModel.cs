namespace Logcast.Recruitment.Application.UseCases.AudioFiles.Models
{
    public class AudioFileUploadModel
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string ContentType { get; set; }
        public string FilePath { get; set; }
    }
}
