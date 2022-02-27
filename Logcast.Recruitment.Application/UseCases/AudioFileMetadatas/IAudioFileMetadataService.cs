using Logcast.Recruitment.Application.UseCases.AudioFileMetadatas.Models;
using System.Threading.Tasks;

namespace Logcast.Recruitment.Application.UseCases.AudioFileMetadatas
{
    public interface IAudioFileMetadataService
    {
        Task FetchMetadataAsync(SaveAudioMetaDataModel request);
    }
}
