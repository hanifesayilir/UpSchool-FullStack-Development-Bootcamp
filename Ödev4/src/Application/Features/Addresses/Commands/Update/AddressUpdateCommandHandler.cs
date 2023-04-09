
using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.Update
{
    public class AddressUpdateCommandHandler : IRequestHandler<AddressUpdateCommand, Response<int>>
    {

        private readonly IApplicationDbContext _applicationDbContext;
        public AddressUpdateCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<int>> Handle(AddressUpdateCommand request, CancellationToken cancellationToken)
        {
            var address = _applicationDbContext.Addresses.FirstOrDefault(x => x.Id == request.Id && x.UserId == request.UserId);

            if (address == null) { return new Response<int>($"This address can not be found"); }

                address.AddressLine1 = request.AddressLine1;
                address.AddressLine2 = request.AddressLine2;
                address.CityId = request.CityId;
                address.CountryId = request.CountryId;
                address.District = request.District;
                address.PostCode = request.PostCode;
                address.AddressType = request.AddressType;
                address.Name= request.Name;
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>($"The new city \"{address.Name}\"named was succesfully updated.", address.Id);
            
             
        }
    }


}
