using GACKO.Shared.Models.SalesDocument;
using System.Collections.Generic;
using System.Threading.Tasks;
using GACKO.Shared.Models.Expense;
using Microsoft.AspNetCore.Http;

namespace GACKO.Services.SalesDocument
{
    public interface ISalesDocumentService
    {
        /// <summary>
        /// Upload File to Database
        /// </summary>
        /// <param name="fileForm"></param>
        /// <param name="fileName"></param>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        Task<ExpenseListViewModel> Upload(IFormFile fileForm, string fileName, int expenseId);
        Task<int> Create(SalesDocumentForm form);
        Task<SalesDocumentModel> Get(int id);
        Task<IList<SalesDocumentModel>> GetAll(int expenseId);
        Task<int> Update(SalesDocumentForm form);
        Task<int> Delete(int id);
    }
}