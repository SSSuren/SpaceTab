using Logcast.Recruitment.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Logcast.Recruitment.Application.Interfaces.Persistance
{
    public interface ISubscriptionRepository
    {
        Task<Guid> RegisterSubscriptionAsync(string firstName, string email);
        Task<SubscriberModel> GetSubscription(Guid subscriberId);
        Task DeleteSubscription(Guid subscriberId);
    }
}
