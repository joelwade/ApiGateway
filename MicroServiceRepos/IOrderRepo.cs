using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace MicroServiceRepos
{
    public interface IOrderRepo
    {
        IEnumerable<Order> Get(int? id);
        void Post(int userId, int giftBoxId, int quantity);
        bool Put(int cartId, int userId, int giftBoxId, int quantity);
        bool Delete(int orderId);
    }
}
