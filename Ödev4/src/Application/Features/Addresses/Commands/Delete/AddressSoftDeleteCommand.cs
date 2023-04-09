using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.Delete
{
    public class AddressSoftDeleteCommand: IRequest<Response<int>>
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
