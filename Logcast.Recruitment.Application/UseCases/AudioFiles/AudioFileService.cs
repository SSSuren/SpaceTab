using Logcast.Recruitment.Application.Interfaces.Persistance;
using Logcast.Recruitment.Application.UseCases.AudioFiles.Models;
using Logcast.Recruitment.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Logcast.Recruitment.Application.UseCases.AudioFiles
{
    public class AudioFileService : IAudioFileService
    {
        private readonly IAudioFileRepository _audioFileRepository;

        public AudioFileService(IAudioFileRepository audioFileRepository)
        {
            _audioFileRepository = audioFileRepository;
        }

        public async Task<AudioFileModel> GetAsync(Guid audioId)
        {
            var audioFile = await _audioFileRepository.GetByIdAsync(audioId);
            if (audioFile == null)
                return null;

            return new AudioFileModel
            {
                Id = audioFile.Id,
                Name = audioFile.Name,
                Path = audioFile.Path
            };
        }

        public async Task<bool> ExistsAsync(Guid audioFileId)
        {
            return await _audioFileRepository.GetByIdAsync(audioFileId) != null;
        }

        public async Task UploadFile(AudioFileUploadModel audioFileUploadModel)
        {
            await _audioFileRepository.InsertAsync(new AudioFile
            {
                Name = audioFileUploadModel.Name,
                Size = (int)audioFileUploadModel.Size,
                ContentType = audioFileUploadModel.ContentType,
                Path = audioFileUploadModel.FilePath
            });
            await _audioFileRepository.SaveAsync();
        }
    }
}
