using Logcast.Recruitment.Application.Interfaces.Persistance;
using Logcast.Recruitment.DataAccess.Repositories.Base;
using Logcast.Recruitment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Logcast.Recruitment.DataAccess.Repositories
{
    public class AudioFileMetadataRepository : Repository<AudioMetaData>, IAudioFileMetaDataRepository
    {
        public AudioFileMetadataRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public Task<AudioMetaData> GetByFileIdAsync(Guid audioFileId)
        {
            return _dbSet.Where(m => m.AudioFileId == audioFileId)
                         .FirstOrDefaultAsync();
        }
    }
}
