using GACKO.Repositories.Expense;
using GACKO.Repositories.SalesDocument;
using GACKO.Shared.Models;
using GACKO.Shared.Models.Expense;
using GACKO.Shared.Models.SalesDocument;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GACKO.Services.SalesDocument
{
    public class SalesDocumentService : ISalesDocumentService
    {
        private readonly ISalesDocumentRepository _salesDocumentRepository;
        private readonly IExpenseRepository _expenseRepository;

        public SalesDocumentService(ISalesDocumentRepository salesDocumentRepository,
            IExpenseRepository expenseRepository)
        {
            _salesDocumentRepository = salesDocumentRepository;
            _expenseRepository = expenseRepository;
        }

        public async Task<ExpenseListViewModel> Upload(IFormFile fileForm, string fileName, int expenseId)
        {
            var viewModel = new ExpenseListViewModel();
            try
            {
                var expense = await _expenseRepository.Get(expenseId);
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
                        await _salesDocumentRepository.Create(salesDocument);
                    }
                }

                viewModel.VirtualAccountId = expense.VirtualAccountId;
                viewModel.Expenses = await _expenseRepository.GetAll(expense.VirtualAccountId);
            }
            catch (Exception e)
            {
                viewModel.Error = new GackoError(e);
            }

            return viewModel;
        }
        public Task<int> Create(SalesDocumentForm form)
        {
            return _salesDocumentRepository.Create(form);
        }

        public Task<SalesDocumentModel> Get(int id)
        {
            return _salesDocumentRepository.Get(id);
        }

        public Task<IList<SalesDocumentModel>> GetAll(int expenseId)
        {
            return _salesDocumentRepository.GetAll(expenseId);
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
