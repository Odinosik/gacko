using AutoMapper;
using GACKO.DB.DaoModels;
using GACKO.Shared.Models.BankAccount;
using GACKO.Shared.Models.Expense;
using GACKO.Shared.Models.ExpenseCategory;
using GACKO.Shared.Models.SalesDocument;
using GACKO.Shared.Models.Subscription;
using GACKO.Shared.Models.User;
using GACKO.Shared.Models.VirtualAccount;

namespace GACKO.Shared.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BankAccountModel, DaoBankAccount>().ReverseMap();
            CreateMap<BankAccountForm, DaoBankAccount>();
            CreateMap<VirtualAccountModel, DaoVirtualAccount>().ReverseMap();
            CreateMap<VirtualAccountForm, DaoVirtualAccount>();
            CreateMap<ExpenseModel, DaoExpense>().ReverseMap();
            CreateMap<ExpenseForm, DaoExpense>();
            CreateMap<ExpenseCategoryModel, DaoExpenseCategory>().ReverseMap();
            CreateMap<ExpenseCategoryForm, DaoExpenseCategory>();
            CreateMap<SalesDocumentModel, DaoSalesDocument>().ReverseMap();
            CreateMap<SalesDocumentForm, DaoSalesDocument>();
            CreateMap<UserProfile, DaoUser>().ReverseMap();
            CreateMap<SubscriptionModel, DaoSubscription>();
            CreateMap<SubscriptionForm, DaoSubscription>();
        }
    }
}
