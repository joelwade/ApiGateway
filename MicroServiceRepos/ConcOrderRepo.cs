using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;
using RestSharp;

namespace MicroServiceRepos
{
    public class ConcOrderRepo : IOrderRepo
    {
        string url = "http://localhost:51359/";
        int timeout = 2000;
        public IEnumerable<Order> Get(int? id)
        {
            var client = new RestClient(url);
            client.Timeout = timeout;
            client.ReadWriteTimeout = timeout;

            //This is incorrect as Luke hasn't done his microservice.
            var request = new RestRequest("api/cart/get/" + id, Method.GET);
            var queryResult = client.Execute<List<Order>>(request).Data;

            return queryResult;
        }

        public bool Delete(int orderId)
        {
            var client = new RestClient(url);
            client.Timeout = timeout;
            client.ReadWriteTimeout = timeout;

            //This is incorrect as Luke hasn't done his microservice.
            var requestString = "api/Cart/Delete?cartId=" + orderId;
            var request = new RestRequest(requestString, Method.DELETE);

            client.Execute(request);

            return true;
        }

        public void Post(int userId, int giftBoxId, int quantity)
        {
            throw new NotImplementedException();
        }

        public bool Put(int cartId, int userId, int giftBoxId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
