using Logcast.Recruitment.Application.Interfaces.Persistance;
using Logcast.Recruitment.DataAccess.Repositories.Base;
using Logcast.Recruitment.Domain.Models;

namespace Logcast.Recruitment.DataAccess.Repositories
{
    public class AudioFileRepository : Repository<AudioFile>, IAudioFileRepository
    {
        public AudioFileRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
