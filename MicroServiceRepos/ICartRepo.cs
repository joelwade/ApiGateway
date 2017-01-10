using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;
using System.Net.Http;

namespace MicroServiceRepos
{
    public interface ICartRepo
    {
        IEnumerable<Cart> Get(int? userId);
        void Post(int userId, int giftBoxId, int quantity);
        bool Put(int cartId, int userId, int giftBoxId, int quantity);
        bool Delete(int cartId);
    }
}
