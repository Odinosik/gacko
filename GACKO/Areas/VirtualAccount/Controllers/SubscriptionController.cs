using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.Subscription;
using GACKO.Shared.Models.Subscription;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GACKO.Areas.VirtualAccount.Controllers
{
    [Area("VirtualAccount")]
    public class SubscriptionController : GackoBaseController
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService,
            UserManager<DaoUser> userManager,
            IHttpContextAccessor contextAccessor) : base(userManager, contextAccessor)
        {
            _subscriptionService = subscriptionService;
        }
        public async Task<IActionResult> Index(int virtualAccountId)
        {
            return View("Index", await _subscriptionService.GetAll(virtualAccountId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubscriptionForm subscription)
        {
            subscription.AddedDate = DateTime.Now;
            await _subscriptionService.Create(subscription);
            var viewModel = new SubscriptionListViewModel()
            {
                VirtualAccountId = subscription.VirtualAccountId,
                Subscriptions = await _subscriptionService.GetAll(subscription.VirtualAccountId)
            };
            return PartialView("_SubscriptionList", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SubscriptionForm subscription, int virtualAccountId)
        {
            subscription.VirtualAccountId = virtualAccountId;
            await _subscriptionService.Update(subscription);
            return View("Index", await _subscriptionService.GetAll(virtualAccountId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {

            var subscription = await _subscriptionService.Get(id);
            await _subscriptionService.Delete(id);
            var viewModel = new SubscriptionListViewModel()
            {
                VirtualAccountId = subscription.VirtualAccountId,
                Subscriptions = await _subscriptionService.GetAll(subscription.VirtualAccountId)
            };
            return PartialView("_SubscriptionList", viewModel);
        }
    }
}
