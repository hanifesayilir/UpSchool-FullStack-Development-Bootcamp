using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.SoftDelete
{
    public class AddressSofDeleteCommandHandler : IRequestHandler<AddressSoftDeleteCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressSofDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<int>> Handle(AddressSoftDeleteCommand request, CancellationToken cancellationToken)
        {
            var address = await _applicationDbContext.Addresses.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (address == null) { return new Response<int>($"This id does not exist."); }
            else
            {
              
                address.IsDeleted = true;
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new Response<int>($"The address \"{address.Name}\"s status has been succesfully made false", address.Id);

            }

        }
    }
}
