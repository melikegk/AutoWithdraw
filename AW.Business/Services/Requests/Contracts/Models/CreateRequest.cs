using MediatR;

namespace AW.Business.Services.Requests.Contracts.Models
{
    public class CreateRequest : IRequest<long>
    {
        public int ClientPlatformId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string AccountNo { get; set; }
        public string AccountHolder { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string ProvinceBank { get; set; }
        public string CityBank { get; set; }
        public string SwiftCode { get; set; }
    }
}
