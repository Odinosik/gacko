using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.VirtualAccount;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GACKO.Areas.VirtualAccount.Controllers
{
    [Area("VirtualAccount")]
    public class VirtualAccountController : BaseController
    {
        private readonly UserManager<DaoUser> _userManager;
        private readonly IVirtualAccountService _virtualAccountService;

        public VirtualAccountController(UserManager<DaoUser> userManager, IVirtualAccountService virtualAccountService)
        {
            _userManager = userManager;
            _virtualAccountService = virtualAccountService;
        }

        [HttpGet]
        public IActionResult Index(int bankAccId)
        {
            //var virtualAccs = _virtualAccountService.GetAll(bankAccId);
            return View("Index");
        }
    }
}