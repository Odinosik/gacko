using GACKO.Shared.Models.Email;
using GACKO.Shared.Models.Expense;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GACKO.Services.Mail
{
    public interface IEmailService
    {
        Task SendMailAsync(CancellationToken cancellationToken, params EmailDefinition[] emailDefinitions);
        List<string> CreateBody(List<ExpenseForm> entitiesViewModel);
    }
}
