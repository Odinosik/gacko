using AutoMapper;
using GACKO.DB;
using GACKO.DB.DaoModels;
using GACKO.Shared.Models.VirtualAccount;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GACKO.Repositories.VirtualAccount
{
    public class VirtualAccountRepository : IVirtualAccountRepository
    {
        private GackoDbContext _context;
        private IMapper _mapper { get; }
        public VirtualAccountRepository(IMapper mapper)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GackoDbContext>();
            _context = new GackoDbContext(optionsBuilder.Options);
        }

        public async Task<int> Create(VirtualAccountForm form)
        {
            var newEntity = _mapper.Map<DaoVirtualAccount>(form);
            var createdEntry = _context.VirtualAccounts.Add(newEntity);
            await _context.SaveChangesAsync();
            return createdEntry.Entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var deletedEntity = await _context.VirtualAccounts.FirstOrDefaultAsync(_ => _.Id == id);
                if (deletedEntity == null)
                    throw new Exception();
                var deletedEntry = _context.VirtualAccounts.Remove(deletedEntity);
                await _context.SaveChangesAsync();
                return deletedEntry.Entity.Id;
            }

            catch (Exception e)
            {
                throw new Exception("Failed to delete model.", e);
            }
        }

        public async Task<VirtualAccountModel> Get(int id)
        {
            return _mapper.Map<VirtualAccountModel>(await _context.VirtualAccounts.FirstOrDefaultAsync(_ => _.Id == id));
        }

        public async Task<int> Update(VirtualAccountForm form)
        {
            try
            {
                var updateEntity = this._mapper.Map<DaoVirtualAccount>(form);

                var updated = await _context.VirtualAccounts.FirstOrDefaultAsync(_ => _.Id == updateEntity.Id);
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
