using AutoMapper;
using GACKO.DB;
using GACKO.DB.DaoModels;
using GACKO.Shared;
using GACKO.Shared.Models.Subscription;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GACKO.Repositories.Subscription
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private GackoDbContext _context;
        private IMapper _mapper { get; }

        public SubscriptionRepository(IMapper mapper, IDbContextOptionsFactory optionsFactory)
        {
            _context = new GackoDbContext(optionsFactory.Get());
            _mapper = mapper;
        }

        public async Task<int> Create(SubscriptionForm form)
        {
            var newEntity = _mapper.Map<DaoSubscription>(form);
            var createdEntry = _context.Subscriptions.Add(newEntity);
            await _context.SaveChangesAsync();
            return createdEntry.Entity.Id;
        }
        public async Task<int> Delete(int id)
        {
            try
            {
                var deletedEntity = await _context.Subscriptions.FirstOrDefaultAsync(_ => _.Id == id);
                if (deletedEntity == null)
                    throw new Exception();
                var deletedEntry = _context.Subscriptions.Remove(deletedEntity);
                await _context.SaveChangesAsync();
                return deletedEntry.Entity.Id;
            }

            catch (Exception e)
            {
                throw new Exception("Failed to delete model.", e);
            }
        }
        public async Task<SubscriptionModel> Get(int id)
        {
            return _mapper.Map<SubscriptionModel>(await _context.Subscriptions.FirstOrDefaultAsync(_ => _.Id == id));
        }
        public async Task<IList<SubscriptionModel>> GetAll(int virtualAccountId)
        {
            return _mapper.Map<List<SubscriptionModel>>(await _context.Subscriptions.Where(_ => _.VirtualAccountId == virtualAccountId).ToListAsync());
        }
        public async Task<int> Update(SubscriptionForm form)
        {
            try
            {
                var updateEntity = this._mapper.Map<DaoSubscription>(form);

                var updated = await _context.Subscriptions.FirstOrDefaultAsync(_ => _.Id == updateEntity.Id);
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