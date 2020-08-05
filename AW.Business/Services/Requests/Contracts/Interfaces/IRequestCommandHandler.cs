using AW.Business.Services.Requests.Contracts.Models;
using MediatR;

namespace AW.Business.Services.Requests.Contracts.Interfaces
{
    public interface IRequestCommandHandler : IRequestHandler<CreateRequest, long>
    {
    }
}
