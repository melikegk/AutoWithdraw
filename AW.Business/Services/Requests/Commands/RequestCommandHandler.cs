using AW.Business.Services.Requests.Contracts.Interfaces;
using AW.Business.Services.Requests.Contracts.Models;
using AW.Data.Context;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AW.Business.Services.Requests.Commands
{
    public class RequestCommandHandler : IRequestCommandHandler
    {
        private readonly WithdrawDbContext _context;
        public RequestCommandHandler(WithdrawDbContext context)
        {
            _context = context;
        }
        public async Task<long> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            var entity = new Data.Domain.Request
            {
                ClientPlatformId = request.ClientPlatformId,
                Amount = request.Amount,
                Description = request.Description,
                AccountHolder = request.AccountHolder,
                AccountNo = request.AccountNo,
                AccountNumber = request.AccountNumber,
                BankName = request.BankName,
                RequestDate = DateTime.UtcNow,
                SwiftCode = request.SwiftCode,
                ProvinceBank = request.ProvinceBank,
                CityBank = request.CityBank,
                BranchName = request.BranchName
            };
            await _context.Requests.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
