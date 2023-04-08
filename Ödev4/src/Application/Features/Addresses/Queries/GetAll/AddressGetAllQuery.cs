using Domain.Entities;
using Domain.Enums;
using Domain.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Queries.GetAll
{
    public class AddressGetAllQuery:IRequest<List<AddressGetAllDto>>
    {

  
        public int UserId { get; set; }
      /*  public int CountryId { get; set; }
        public int CityId { get; set; }*/
        public bool? IsDeleted { get; set; }

        public AddressGetAllQuery(int userId, bool? isDeleted)
        {
          /*  CountryId = countryId;
            CityId = cityId;*/
            UserId = userId;
            IsDeleted = isDeleted;
        }

    }
}
