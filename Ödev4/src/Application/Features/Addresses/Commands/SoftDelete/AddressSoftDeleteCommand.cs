using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.SoftDelete
{
    public class AddressSoftDeleteCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
