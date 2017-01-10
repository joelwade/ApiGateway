using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace MicroServiceRepos
{
    public class MockOrderRepo : IOrderRepo
    {
        List<Order> orders;

        public MockOrderRepo()
        {
            orders = CreateOrders();
        }

        private List<Order> CreateOrders()
        {
            List<Order> list = new List<Order>();
            list.Add(new Order
            {
                orderId = 1,
                userId = 1,
                giftBoxId = 1,
                quantity = 4,
                date = new DateTime(DateTime.Now.Year, 5, 14)
            });
            list.Add(new Order
            {
                orderId = 2,
                userId = 2,
                giftBoxId = 2,
                quantity = 3,
                date = new DateTime(DateTime.Now.Year, 6, 15)
            });
            list.Add(new Order
            {
                orderId = 3,
                userId = 2,
                giftBoxId = 6,
                quantity = 1,
                date = new DateTime(DateTime.Now.Year, 6, 15)
            });
            list.Add(new Order
            {
                orderId = 4,
                userId = 3,
                giftBoxId = 3,
                quantity = 2,
                date = new DateTime(DateTime.Now.Year, 7, 16)
            });
            list.Add(new Order
            {
                orderId = 5,
                userId = 4,
                giftBoxId = 4,
                quantity = 1,
                date = new DateTime(DateTime.Now.Year, 8, 17)
            });

            return list;
        }

        public IEnumerable<Order> Get(int? userId)
        {
            return orders.Where(a => (userId != null)? a.userId == userId : true );

            //if (id == null)
            //{
            //    return orders;
            //} else
            //{
            //    return orders.Where(a => a.id == id);
            //}
        }

        public void Post(int userId, int giftBoxId, int quantity)
        {
            Order o = new Order
            {
                orderId = orders.Count() + 1,
                userId = userId,
                giftBoxId = giftBoxId,
                quantity = quantity,
                date = System.DateTime.Now
            };
            
            orders.Add(o);
        }

        public bool Put(int orderId, int userId, int giftBoxId, int quantity)
        {
            Order c = orders.Where(a => a.orderId == orderId).FirstOrDefault();

            if (c != null)
            {
                orders.Remove(c);
                c.userId = userId;
                c.giftBoxId = giftBoxId;
                c.quantity = quantity;
                orders.Add(c);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int orderId)
        {
            Order c = orders.Where(a => a.orderId == orderId).FirstOrDefault();

            if (c != null)
            {
                orders.Remove(c);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
