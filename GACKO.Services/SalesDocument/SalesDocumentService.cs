using GACKO.Repositories.SalesDocument;
using GACKO.Shared.Models.SalesDocument;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GACKO.Services.SalesDocument
{
    public class SalesDocumentService : ISalesDocumentService
    {
        private readonly ISalesDocumentRepository _salesDocumentRepository;

        public SalesDocumentService(ISalesDocumentRepository salesDocumentRepository)
        {
            _salesDocumentRepository = salesDocumentRepository;
        }

        public Task<int> Create(SalesDocumentForm form)
        {
            return _salesDocumentRepository.Create(form);
        }

        public Task<SalesDocumentModel> Get(int id)
        {
            return _salesDocumentRepository.Get(id);
        }

        public Task<IList<SalesDocumentModel>> GetAll()
        {
            return _salesDocumentRepository.GetAll();
        }

        public Task<int> Update(SalesDocumentForm form)
        {
            return _salesDocumentRepository.Update(form);
        }

        public Task<int> Delete(int id)
        {
            return _salesDocumentRepository.Delete(id);
        }
    }
}
