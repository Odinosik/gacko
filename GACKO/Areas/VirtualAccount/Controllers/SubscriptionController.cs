﻿using AutoMapper;
using GACKO.Controllers;
using GACKO.Services.Subscription;
using GACKO.Shared.Models.Subscription;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GACKO.Areas.VirtualAccount.Controllers
{
    [Area("Subscription")]
    public class SubscriptionController : BaseController
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        public async Task<IActionResult> Index(int virtualAccountId)
        {
            return View("Index", await _subscriptionService.GetAll(virtualAccountId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubscriptionForm subscription, int virtualAccountId)
        {
            subscription.VirtualAccountId = virtualAccountId;
            await _subscriptionService.Create(subscription);
            return View("Index", await _subscriptionService.GetAll(virtualAccountId));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SubscriptionForm subscription, int virtualAccountId)
        {
            subscription.VirtualAccountId = virtualAccountId;
            await _subscriptionService.Update(subscription);
            return View("Index", await _subscriptionService.GetAll(virtualAccountId));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, int virtualAccountId)
        {
            await _subscriptionService.Delete(id);
            return View("Index", await _subscriptionService.GetAll(virtualAccountId));
        }
    }
}