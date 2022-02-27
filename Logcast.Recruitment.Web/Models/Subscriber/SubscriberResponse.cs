using Logcast.Recruitment.Domain.Models;
using System;

namespace Logcast.Recruitment.Web.Models.Subscriber
{
    public class SubscriberResponse
    {
        public SubscriberResponse(SubscriberModel subscriberModel)
        {
            Name = subscriberModel.Name;
            UserId = subscriberModel.Id;
        }

        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}