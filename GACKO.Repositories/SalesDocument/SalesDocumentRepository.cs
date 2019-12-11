using AutoMapper;
using GACKO.DB;
using GACKO.DB.DaoModels;
using GACKO.Shared;
using GACKO.Shared.Enums;
using GACKO.Shared.Exceptions;
using GACKO.Shared.Models.SalesDocument;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GACKO.Repositories.SalesDocument
{
    public class SalesDocumentRepository : ISalesDocumentRepository
    {
        private GackoDbContext _context;
        private IMapper _mapper { get; }
        public SalesDocumentRepository(IMapper mapper, IDbContextOptionsFactory optionsFactory)
        {
            _context = new GackoDbContext(optionsFactory.Get());
            _mapper = mapper;
        }

        public async Task<int> Create(SalesDocumentForm form)
        {
            try
            {
                var newEntity = _mapper.Map<DaoSalesDocument>(form);
                var createdEntry = _context.SalesDocuments.Add(newEntity);
                await _context.SaveChangesAsync();
                return createdEntry.Entity.Id;
            }
            catch (Exception e)
            {
                throw new RepositoryException(typeof(DaoBankAccount).Name, eRepositoryExceptionType.Create);
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var deletedEntity = await _context.SalesDocuments.FirstOrDefaultAsync(_ => _.Id == id);
                if (deletedEntity == null)
                    throw new Exception();
                var deletedEntry = _context.SalesDocuments.Remove(deletedEntity);
                await _context.SaveChangesAsync();
                return deletedEntry.Entity.Id;
            }
            catch (Exception e)
            {
                throw new RepositoryException(typeof(DaoBankAccount).Name, eRepositoryExceptionType.Delete);
            }
        }

        public async Task<SalesDocumentModel> Get(int id)
        {
            try
            {
                return _mapper.Map<SalesDocumentModel>(await _context.SalesDocuments.FirstOrDefaultAsync(_ => _.Id == id));
            }
            catch (Exception e)
            {
                throw new RepositoryException(typeof(DaoBankAccount).Name, eRepositoryExceptionType.Get);
            }
        }

        public async Task<IList<SalesDocumentModel>> GetAll(int expenseId)
        {
            try
            {
                return _mapper.Map<List<SalesDocumentModel>>(await _context.SalesDocuments.Where(_ => _.ExpenseId == expenseId).ToListAsync());
            }
            catch (Exception e)
            {
                throw new RepositoryException(typeof(DaoBankAccount).Name, eRepositoryExceptionType.Get);
            }
        }


        public async Task<int> Update(SalesDocumentForm form)
        {
            try
            {
                var updateEntity = this._mapper.Map<DaoSalesDocument>(form);

                var updated = await _context.SalesDocuments.FirstOrDefaultAsync(_ => _.Id == updateEntity.Id);
                _context.Entry(updated).CurrentValues.SetValues(updateEntity);

                await _context.SaveChangesAsync();

                return updated.Id;
            }
            catch (Exception e)
            {
                throw new RepositoryException(typeof(DaoBankAccount).Name, eRepositoryExceptionType.Update);
            }
        }
    }
}
