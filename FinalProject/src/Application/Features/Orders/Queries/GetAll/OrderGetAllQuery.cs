using Application.Common.Models.General;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllQuery:IRequest<PaginatedList<OrderGetAllDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public OrderGetAllQuery(int pageNumber, int pageSize)
        {
            PageSize= pageSize;
            PageNumber = pageNumber;
        }

    }
}
