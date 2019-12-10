using GACKO.Controllers;
using GACKO.DB.DaoModels;
using GACKO.Services.Expense;
using GACKO.Services.SalesDocument;
using GACKO.Services.VirtualAccount;
using GACKO.Shared.Models.SalesDocument;
using GACKO.Shared.Models.VirtualAccount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using GACKO.Shared.Models.Expense;

namespace GACKO.Areas.VirtualAccount.Controllers
{
    [Area("VirtualAccount")]
    public class SalesDocumentController : BaseController
    {
        private readonly UserManager<DaoUser> _userManager;
        private readonly ISalesDocumentService _salesDocumentService;
        private readonly IExpenseService _expenseService;
        private readonly IVirtualAccountService _virtualAccountService;

        public SalesDocumentController(UserManager<DaoUser> userManager,
            ISalesDocumentService salesDocumentService,
            IExpenseService expenseService,
            IVirtualAccountService virtualAccountService,
            IHttpContextAccessor contextAccessor) : base(userManager, contextAccessor)
        {
            _userManager = userManager;
            _salesDocumentService = salesDocumentService;
            _expenseService = expenseService;
            _virtualAccountService = virtualAccountService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> Upload([FromForm]IFormFile fileForm, [FromForm]string fileName, [FromForm]int expenseId)
        {
            var expense = await _expenseService.Get(expenseId);
            if (fileForm != null && fileForm.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    fileForm.CopyTo(ms);
                    var fileRawData = ms.ToArray();
                    var salesDocument = new SalesDocumentForm()
                    {
                        ExpenseId = expenseId,
                        Name = fileName,
                        FileRawData = fileRawData
                    };
                    await _salesDocumentService.Create(salesDocument);
                }
            }

            var viewModel = new ExpenseListViewModel()
            {
                VirtualAccountId = expense.VirtualAccountId,
                Expenses = await _expenseService.GetAll(expense.VirtualAccountId)
            };
            return PartialView("_ExpenseList", viewModel);
        }
    }
}