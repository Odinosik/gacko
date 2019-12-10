using AutoMapper;
using GACKO.DB;
using GACKO.DB.DaoModels;
using GACKO.Shared;
using GACKO.Shared.Enums;
using GACKO.Shared.Exceptions;
using GACKO.Shared.Models.ExpenseCategory;
using Microsoft.EntityFrameworkCore;
using System;
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
            try
            {
                var newEntity = _mapper.Map<DaoExpenseCategory>(form);
                var createdEntry = _context.ExpenseCategories.Add(newEntity);
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
                var deletedEntity = await _context.ExpenseCategories.FirstOrDefaultAsync(_ => _.Id == id);
                if (deletedEntity == null)
                    throw new Exception();
                var deletedEntry = _context.ExpenseCategories.Remove(deletedEntity);
                await _context.SaveChangesAsync();
                return deletedEntry.Entity.Id;
            }
            catch (Exception e)
            {
                throw new RepositoryException(typeof(DaoBankAccount).Name, eRepositoryExceptionType.Delete);
            }
        }

        public async Task<ExpenseCategoryModel> Get(int id)
        {
            try
            {
                return _mapper.Map<ExpenseCategoryModel>(await _context.ExpenseCategories.FirstOrDefaultAsync(_ => _.Id == id));
            }
            catch (Exception e)
            {
                throw new RepositoryException(typeof(DaoBankAccount).Name, eRepositoryExceptionType.Get);
            }
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
                throw new RepositoryException(typeof(DaoBankAccount).Name, eRepositoryExceptionType.Update);
            }
        }
    }
}
