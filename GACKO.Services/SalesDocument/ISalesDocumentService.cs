using GACKO.Shared.Models.SalesDocument;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GACKO.Services.SalesDocument
{
    public interface ISalesDocumentService
    {
        Task<int> Create(SalesDocumentForm form);
        Task<SalesDocumentModel> Get(int id);
        Task<IList<SalesDocumentModel>> GetAll();
        Task<int> Update(SalesDocumentForm form);
        Task<int> Delete(int id);
    }
}