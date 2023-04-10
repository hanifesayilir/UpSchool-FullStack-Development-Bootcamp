using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.Delete
{
    public class AddressDeleteCommandHandler : IRequestHandler<AddressDeleteCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext= applicationDbContext;
        }

        public async Task<Response<int>> Handle(AddressDeleteCommand request, CancellationToken cancellationToken)
        {
            var address = await _applicationDbContext.Addresses.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
            if (address == null) { return new Response<int>($"This id does not exist."); }
            _applicationDbContext.Addresses.Remove(address);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new Response<int>($"The address named \"{address.Name}\" has been succesfully deleted.", address.Id);
        }
    }
}
