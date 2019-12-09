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
        private readonly ISalesDocumentService _salesDocumentService;

        public SalesDocumentController(ISalesDocumentService salesDocumentService)
        {
            _salesDocumentService = salesDocumentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var salesDocs = await _salesDocumentService.GetAll();

            salesDocs.Add(new SalesDocumentModel()
            {
                Id = 1,
                Name = "Zabka zakupy",
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
        [HttpPost]
        public async Task<IActionResult> Create(SalesDocumentForm salesDocument)
        {
            await _salesDocumentService.Create(salesDocument);
            return View();
        }
    }
}
