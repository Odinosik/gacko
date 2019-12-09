using GACKO.Services.SalesDocument;
using GACKO.Shared.Models.SalesDocument;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GACKO.Tests.SalesDocument
{
    public class SalesDocumentServiceTest : BaseUnitTest
    {
        private readonly ISalesDocumentService _salesDocumentService;

        public SalesDocumentServiceTest(GackoWebApplicationFactory<TestStartup> factory) : base(factory)
        {
            using (var scope = _factory.Server.Host.Services.CreateScope())
            {
                _salesDocumentService = scope.ServiceProvider.GetRequiredService<ISalesDocumentService>();
            }
        }

        [Fact]
        public async void IsVirtualAccountCreatePossible()
        {
            var form = new SalesDocumentForm()
            {
                Name = "Test",
                FilePath = "",
                ExpenseId = 1

            };
            var result = await _salesDocumentService.Create(form);
            Assert.NotEqual(0, result);
        }
    }
}
