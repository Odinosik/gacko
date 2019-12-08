using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.SalesDocument;
using GACKO.Shared.Models.SalesDocument;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GACKO.Areas.SalesDocument.Controllers
{
    [Area("SalesDocument")]
    public class SalesDocumentController : BaseController
    {
        private readonly UserManager<DaoUser> _userManager;
        private readonly ISalesDocumentService _salesDocumentService;

        public SalesDocumentController(UserManager<DaoUser> userManager, ISalesDocumentService salesDocumentService)
        {
            _userManager = userManager;
            _salesDocumentService = salesDocumentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var salesDocs = await _salesDocumentService.GetAll();

            salesDocs.Add(new SalesDocumentModel()
            {
                Id = 1,
                Name = "IKEA",
                FilePath = ""
            });

            salesDocs.Add(new SalesDocumentModel()
            {
                Id = 2,
                Name = "IKEA",
                FilePath = ""
            });

            return View("Index", salesDocs);
        }
    }
}
