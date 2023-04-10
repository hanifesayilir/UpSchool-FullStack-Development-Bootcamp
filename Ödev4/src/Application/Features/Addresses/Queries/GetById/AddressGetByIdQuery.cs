using Application.Features.Addresses.Queries.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Queries.GetById
{
    public class AddressGetByIdQuery:IRequest<List<AddressGetAllDto>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool? IsDeleted { get; set; }

        public AddressGetByIdQuery(int userId, int id, bool? isDeleted )
        {
            UserId = userId;
            Id = id;
            IsDeleted = isDeleted;

        }



    }
}
