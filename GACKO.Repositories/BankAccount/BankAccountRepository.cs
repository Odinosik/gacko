using AutoMapper;
using GACKO.DB;
using GACKO.DB.DaoModels;
using GACKO.Shared;
using GACKO.Shared.Models.BankAccount;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GACKO.Repositories.BankAccount
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private GackoDbContext _context;
        private IMapper _mapper { get; }
        public BankAccountRepository(IMapper mapper, IDbContextOptionsFactory optionsFactory)
        {
            _context = new GackoDbContext(optionsFactory.Get());
            _mapper = mapper;
        }

        public async Task<int> Create(BankAccountForm form)
        {
            var newEntity = _mapper.Map<DaoBankAccount>(form);
            var createdEntry = _context.BankAccounts.Add(newEntity);
            await _context.SaveChangesAsync();
            return createdEntry.Entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var deletedEntity = await _context.BankAccounts.FirstOrDefaultAsync(_ => _.Id == id);
                if (deletedEntity == null)
                    throw new Exception();
                var deletedEntry = _context.BankAccounts.Remove(deletedEntity);
                await _context.SaveChangesAsync();
                return deletedEntry.Entity.Id;
            }

            catch (Exception e)
            {
                throw new Exception("Failed to delete model.", e);
            }
        }

        public async Task<BankAccountModel> Get(int id)
        {
            return _mapper.Map<BankAccountModel>(await _context.BankAccounts.FirstOrDefaultAsync(_ => _.Id == id));
        }

        public async Task<IList<BankAccountModel>> GetAll(int id)
        {
            return _mapper.Map<List<BankAccountModel>>(await _context.BankAccounts.Where(_ => _.UserId == id).ToListAsync());
        }


        public async Task<int> Update(BankAccountForm form)
        {
            try
            {
                var updateEntity = this._mapper.Map<DaoBankAccount>(form);

                var updated = await _context.BankAccounts.FirstOrDefaultAsync(_ => _.Id == updateEntity.Id);
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
