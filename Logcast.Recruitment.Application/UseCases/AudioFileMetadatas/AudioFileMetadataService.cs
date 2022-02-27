using Logcast.Recruitment.Application.Interfaces.Persistance;
using Logcast.Recruitment.Application.UseCases.AudioFileMetadatas.Models;
using Logcast.Recruitment.Domain.Models;
using System.Threading.Tasks;

namespace Logcast.Recruitment.Application.UseCases.AudioFileMetadatas
{
    public class AudioFileMetadataService : IAudioFileMetadataService
    {
        private readonly IAudioFileMetaDataRepository _audioFileMetaDataRepository;
        public AudioFileMetadataService(IAudioFileMetaDataRepository audioFileMetaDataRepository)
        {
            _audioFileMetaDataRepository = audioFileMetaDataRepository;
        }

        public async Task FetchMetadataAsync(SaveAudioMetaDataModel request)
        {
            var metaData = await _audioFileMetaDataRepository.GetByFileIdAsync(request.AudioFileId);
            if (metaData == null)
            {
                await _audioFileMetaDataRepository.InsertAsync(new AudioMetaData
                {
                    AudioFileId = request.AudioFileId,
                    TrackTitle = request.TrackTitle,
                    Artist = request.Artist,
                    Album = request.Album,
                    Released = request.Released
                });
            }
            else
            {
                metaData.TrackTitle = request.TrackTitle;
                metaData.Artist = request.Artist;
                metaData.Album = request.Album;
                metaData.Released = request.Released;
                _audioFileMetaDataRepository.Update(metaData);
            }

            await _audioFileMetaDataRepository.SaveAsync();
        }
    }
}
