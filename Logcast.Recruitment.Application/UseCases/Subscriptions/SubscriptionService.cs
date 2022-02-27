﻿using Logcast.Recruitment.Application.Interfaces.Persistance;
using Logcast.Recruitment.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Logcast.Recruitment.Application.UseCases.Subscriptions
{
    public interface ISubscriptionService
    {
        Task<Guid> RegisterSubscriptionAsync(string name, string emailAddress);
        Task<SubscriberModel> GetSubscriberAsync(Guid subscriberId);
        Task DeleteSubscriberAsync(Guid subscriberId);
    }

    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<Guid> RegisterSubscriptionAsync(string name, string emailAddress)
        {
            var subscriberId = await _subscriptionRepository.RegisterSubscriptionAsync(name, emailAddress);
            return subscriberId;
        }

        public async Task<SubscriberModel> GetSubscriberAsync(Guid subscriberId)
        {
            var subscriber = await _subscriptionRepository.GetSubscription(subscriberId);
            return subscriber;
        }

        public async Task DeleteSubscriberAsync(Guid subscriberId)
        {
            await _subscriptionRepository.DeleteSubscription(subscriberId);
        }
    }
}
