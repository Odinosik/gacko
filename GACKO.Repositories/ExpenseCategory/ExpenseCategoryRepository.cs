using AutoMapper;
using GACKO.DB;
using GACKO.DB.DaoModels;
using GACKO.Shared;
using GACKO.Shared.Models.ExpenseCategory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GACKO.Repositories.ExpenseCategory
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private GackoDbContext _context;
        private IMapper _mapper { get; }
        public ExpenseCategoryRepository(IMapper mapper, IDbContextOptionsFactory optionsFactory)
        {
            _context = new GackoDbContext(optionsFactory.Get());
            _mapper = mapper;
        }

        public async Task<int> Create(ExpenseCategoryForm form)
        {
            var newEntity = _mapper.Map<DaoExpenseCategory>(form);
            var createdEntry = _context.ExpenseCategories.Add(newEntity);
            await _context.SaveChangesAsync();
            return createdEntry.Entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var deletedEntity = await _context.ExpenseCategories.FirstOrDefaultAsync(_ => _.Id == id);
                if (deletedEntity == null)
                    throw new Exception();
                var deletedEntry = _context.ExpenseCategories.Remove(deletedEntity);
                await _context.SaveChangesAsync();
                return deletedEntry.Entity.Id;
            }

            catch (Exception e)
            {
                throw new Exception("Failed to delete model.", e);
            }
        }

        public async Task<ExpenseCategoryModel> Get(int id)
        {
            return _mapper.Map<ExpenseCategoryModel>(await _context.ExpenseCategories.FirstOrDefaultAsync(_ => _.Id == id));
        }

        public async Task<int> Update(ExpenseCategoryForm form)
        {
            try
            {
                var updateEntity = this._mapper.Map<DaoExpenseCategory>(form);

                var updated = await _context.ExpenseCategories.FirstOrDefaultAsync(_ => _.Id == updateEntity.Id);
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
