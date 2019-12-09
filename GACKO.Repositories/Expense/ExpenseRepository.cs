using AutoMapper;
using GACKO.DB;
using GACKO.DB.DaoModels;
using GACKO.Shared;
using GACKO.Shared.Models.Expense;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GACKO.Repositories.Expense
{
    public class ExpenseRepository : IExpenseRepository
    {
        private GackoDbContext _context;
        private IMapper _mapper { get; }
        public ExpenseRepository(IMapper mapper, IDbContextOptionsFactory optionsFactory)
        {
            _context = new GackoDbContext(optionsFactory.Get());
            _mapper = mapper;
        }

        public async Task<int> Create(ExpenseForm form)
        {
            var newEntity = _mapper.Map<DaoExpense>(form);
            var createdEntry = _context.Expenses.Add(newEntity);
            await _context.SaveChangesAsync();
            return createdEntry.Entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var deletedEntity = await _context.Expenses.FirstOrDefaultAsync(_ => _.Id == id);
                if (deletedEntity == null)
                    throw new Exception();
                var deletedEntry = _context.Expenses.Remove(deletedEntity);
                await _context.SaveChangesAsync();
                return deletedEntry.Entity.Id;
            }

            catch (Exception e)
            {
                throw new Exception("Failed to delete model.", e);
            }
        }

        public async Task<ExpenseModel> Get(int id)
        {
            return _mapper.Map<ExpenseModel>(await _context.Expenses.FirstOrDefaultAsync(_ => _.Id == id));
        }

        public async Task<IList<ExpenseModel>> GetAll(int virtualAccountId)
        {
            return _mapper.Map<List<ExpenseModel>>(await _context.Expenses.Where(_ => _.VirtualAccountId == virtualAccountId).ToListAsync());
        }

        public async Task<int> Update(ExpenseForm form)
        {
            try
            {
                var updateEntity = this._mapper.Map<DaoExpenseCategory>(form);

                var updated = await _context.Expenses.FirstOrDefaultAsync(_ => _.Id == updateEntity.Id);
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
