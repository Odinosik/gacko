using AutoMapper;
using GACKO.Controllers;
using GACKO.Services.Subscription;
using Microsoft.AspNetCore.Mvc;

namespace GACKO.Areas.Subscription.Controllers
{
    [Area("Subscription")]
    public class SubscriptionController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionService _subscriptionService = null;

        public SubscriptionController(ISubscriptionService subscriptionService, IMapper mapper)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
        }
    }
}
