using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.SalesDocument;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GACKO.Areas.VirtualAccount.Controllers
{
    [Area("VirtualAccount")]
    public class SalesDocumentController : GackoBaseController
    {
        private readonly UserManager<DaoUser> _userManager;
        private readonly ISalesDocumentService _salesDocumentService;

        public SalesDocumentController(UserManager<DaoUser> userManager,
            ISalesDocumentService salesDocumentService,
            IHttpContextAccessor contextAccessor) : base(userManager, contextAccessor)
        {
            _userManager = userManager;
            _salesDocumentService = salesDocumentService;
        }

        /// <summary>
        /// Upload Expense's Sales Document
        /// </summary>
        /// <param name="fileForm"></param>
        /// <param name="fileName"></param>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> Upload([FromForm]IFormFile fileForm, [FromForm]string fileName, [FromForm]int expenseId)
        {
            return PartialView("_ExpenseList", await _salesDocumentService.Upload(fileForm, fileName, expenseId));
        }
    }
}