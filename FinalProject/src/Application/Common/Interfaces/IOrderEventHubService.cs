using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
   public interface IOrderEventHubService
    {
        Task AddedAsync(OrderEvent orderEvent, CancellationToken cancellationToken);
    }
}
