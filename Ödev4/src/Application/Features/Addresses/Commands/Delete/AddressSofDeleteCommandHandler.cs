using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.Delete
{
    public class AddressSofDeleteCommandHandler : IRequestHandler<AddressSoftDeleteCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AddressSofDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext= applicationDbContext;
        }
        public async Task<Response<int>> Handle(AddressSoftDeleteCommand request, CancellationToken cancellationToken)
        {
            var address = await _applicationDbContext.Addresses.FirstOrDefaultAsync(x =>x.Id== request.Id);
          /*  if (address== null) { }
            else
            {
                _applicationDbContext.Addresses.ExecuteUpdate();
            }
*/
            /* _applicationDbContext.Addresses.Update()
             await _applicationDbContext.SaveChangesAsync(cancellationToken);
             return new Response<int>($"The new city \"{address.Id}\"named was succesfully deleted.", address.Id);*/
            return new Response<int>($"The new city \"{address.Id}\"named was succesfully deleted.", address.Id);
        }
    }
}
