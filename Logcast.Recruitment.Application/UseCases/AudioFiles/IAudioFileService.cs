using Logcast.Recruitment.Application.UseCases.AudioFiles.Models;
using System;
using System.Threading.Tasks;

namespace Logcast.Recruitment.Application.UseCases.AudioFiles
{
    public interface IAudioFileService
    {
        Task<AudioFileModel> GetAsync(Guid audioId);
        Task<bool> ExistsAsync(Guid audioFileId);
        Task UploadFile(AudioFileUploadModel audioFileUploadModel);
    }
}
