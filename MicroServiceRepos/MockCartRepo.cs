using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;
using System.Net.Http;

namespace MicroServiceRepos
{
    public class MockCartRepo : ICartRepo
    {
        List<Cart> cart;

        public MockCartRepo()
        {
            cart = CreateCart();
        }

        private List<Cart> CreateCart()
        {
            List<Cart> list = new List<Cart>();
            list.Add(new Cart
            {
                userId = 1,
                cartId = 1,
                giftBoxId = 1,
                quantity = 1
            });
            list.Add(new Cart
            {
                userId = 1,
                cartId = 2,
                giftBoxId = 2,
                quantity = 13
            });
            list.Add(new Cart
            {
                userId = 2,
                cartId = 3,
                giftBoxId = 3,
                quantity = 1
            });
            list.Add(new Cart
            {
                userId = 3,
                cartId = 4,
                giftBoxId = 4,
                quantity = 2
            });
            list.Add(new Cart
            {
                userId = 5,
                cartId = 5,
                giftBoxId = 4,
                quantity = 2
            });

            return list;
        }

        public IEnumerable<Cart> Get(int? userId)
        {
            return cart.Where(a => (userId != null) ? a.userId == userId : true);
        }

        public void Post(int userId, int giftBoxId, int quantity)
        {
            Cart c = new Cart{
                userId = userId,
                giftBoxId = giftBoxId,
                cartId = new Random().Next(1, 70),
                quantity = quantity
            };
            cart.Add(c);
        }

        public bool Put(int cartId, int userId, int giftBoxId, int quantity)
        {
            Cart c = cart.Where(a => a.cartId == cartId).FirstOrDefault();

            if (c != null) {
                cart.Remove(c);
                c.userId = userId;
                c.giftBoxId = giftBoxId;
                c.quantity = quantity;
                cart.Add(c);
                return true;
            } else {
                return false;
            }
        }

        public bool Delete(int cartId)
        {
            Cart c = cart.Where(a => a.cartId == cartId).FirstOrDefault();

            if (c != null) {
                cart.Remove(c);
                return true;
            } else {
                return false;
            }
        }
    }
}
