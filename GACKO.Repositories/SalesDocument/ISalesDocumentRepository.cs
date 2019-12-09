using GACKO.Shared.Models.SalesDocument;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GACKO.Repositories.SalesDocument
{
    public interface ISalesDocumentRepository
    {
        Task<int> Create(SalesDocumentForm form);
        Task<SalesDocumentModel> Get(int id);
        Task<IList<SalesDocumentModel>> GetAll();
        Task<int> Update(SalesDocumentForm form);
        Task<int> Delete(int id);
    }
}