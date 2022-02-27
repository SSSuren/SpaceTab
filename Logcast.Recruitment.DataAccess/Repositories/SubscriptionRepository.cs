using System;
using System.Threading.Tasks;
using Logcast.Recruitment.Application.Interfaces.Persistance;
using Logcast.Recruitment.DataAccess.Exceptions;
using Logcast.Recruitment.DataAccess.Factories;
using Logcast.Recruitment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Logcast.Recruitment.DataAccess.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SubscriptionRepository(IDbContextFactory dbContextFactory)
        {
            _applicationDbContext = dbContextFactory.Create();
        }

        public async Task<Guid> RegisterSubscriptionAsync(string name, string email)
        {
            if (await _applicationDbContext.Subscriptions.AnyAsync(s => s.Email == email))
                throw new EmailAlreadyRegisteredException();

            var newSubscription = await _applicationDbContext.Subscriptions.AddAsync(new Subscription(name, email));
            await _applicationDbContext.SaveChangesAsync();

            return newSubscription.Entity.Id;
        }

        public async Task<SubscriberModel> GetSubscription(Guid subscriberId)
        {
            var subscriber = await _applicationDbContext.Subscriptions.FirstOrDefaultAsync(s => s.Id == subscriberId);
            if (subscriber == null) throw new UserNotFoundException();
            return subscriber.ToDomainModel();
        }

        public async Task DeleteSubscription(Guid subscriberId)
        {
            var subscriber = await _applicationDbContext.Subscriptions.FirstOrDefaultAsync(s => s.Id == subscriberId);
            if (subscriber == null) throw new UserNotFoundException();
            _applicationDbContext.Subscriptions.Remove(subscriber);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}