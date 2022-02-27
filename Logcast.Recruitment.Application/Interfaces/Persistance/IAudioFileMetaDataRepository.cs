using Logcast.Recruitment.Application.Interfaces.Base;
using Logcast.Recruitment.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Logcast.Recruitment.Application.Interfaces.Persistance
{
    public interface IAudioFileMetaDataRepository : IRepository<AudioMetaData>
    {
        Task<AudioMetaData> GetByFileIdAsync(Guid audioFileId);
    }
}
