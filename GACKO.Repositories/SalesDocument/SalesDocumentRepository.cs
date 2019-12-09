using AutoMapper;
using GACKO.DB;
using GACKO.DB.DaoModels;
using GACKO.Shared;
using GACKO.Shared.Models.SalesDocument;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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
            var newEntity = _mapper.Map<DaoSalesDocument>(form);
            var createdEntry = _context.SalesDocuments.Add(newEntity);
            await _context.SaveChangesAsync();
            return createdEntry.Entity.Id;
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
                throw new Exception("Failed to delete model.", e);
            }
        }

        public async Task<SalesDocumentModel> Get(int id)
        {
            return _mapper.Map<SalesDocumentModel>(await _context.SalesDocuments.FirstOrDefaultAsync(_ => _.Id == id));
        }

        public async Task<IList<SalesDocumentModel>> GetAll()
        {
            return _mapper.Map<List<SalesDocumentModel>>(await _context.SalesDocuments.ToListAsync());
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
                throw new Exception("Failed to update model.", e);
            }
        }
    }
}
