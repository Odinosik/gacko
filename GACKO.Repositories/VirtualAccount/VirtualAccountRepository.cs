using AutoMapper;
using GACKO.DB;
using GACKO.DB.DaoModels;
using GACKO.Shared;
using GACKO.Shared.Enums;
using GACKO.Shared.Exceptions;
using GACKO.Shared.Models.VirtualAccount;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GACKO.Repositories.VirtualAccount
{
    public class VirtualAccountRepository : IVirtualAccountRepository
    {
        private GackoDbContext _context;
        private IMapper _mapper { get; }
        public VirtualAccountRepository(IMapper mapper, IDbContextOptionsFactory optionsFactory)
        {
            _context = new GackoDbContext(optionsFactory.Get());
            _mapper = mapper;
        }

        public async Task<int> Create(VirtualAccountForm form)
        {
            try
            {
                var newEntity = _mapper.Map<DaoVirtualAccount>(form);
                var createdEntry = _context.VirtualAccounts.Add(newEntity);
                await _context.SaveChangesAsync();
                return createdEntry.Entity.Id;
            }
            catch (Exception e)
            {
                throw new RepositoryException(typeof(DaoVirtualAccount).Name, eRepositoryExceptionType.Create);
            }
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
                throw new RepositoryException(typeof(DaoVirtualAccount).Name, eRepositoryExceptionType.Delete);
            }
        }

        public async Task<VirtualAccountModel> Get(int id)
        {
            try
            {
                return _mapper.Map<VirtualAccountModel>(await _context.VirtualAccounts.FirstOrDefaultAsync(_ => _.Id == id));
            }
            catch (Exception e)
            {
                throw new RepositoryException(typeof(DaoVirtualAccount).Name, eRepositoryExceptionType.Get);
            }
        }

        public async Task<IList<VirtualAccountModel>> GetAll(int bankAccountId)
        {
            try
            {
                return _mapper.Map<List<VirtualAccountModel>>(await _context.VirtualAccounts.Where(_ => _.BankAccountId == bankAccountId).ToListAsync());
            }
            catch (Exception e)
            {
                throw new RepositoryException(typeof(DaoVirtualAccount).Name, eRepositoryExceptionType.Get);
            }
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
                throw new RepositoryException(typeof(DaoVirtualAccount).Name, eRepositoryExceptionType.Update);
            }
        }
    }
}
