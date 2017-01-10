using System.Collections.Generic;
using Dtos;
using System.Net.Http;
using Newtonsoft.Json;
using System;
using RestSharp;

namespace MicroServiceRepos
{
    public class ConcCartRepo : ICartRepo
    {
        string url = "http://localhost:51359/";
        int timeout = 2000;
        public IEnumerable<Cart> Get(int? userId)
        {
            var client = new RestClient(url);
            client.Timeout = timeout;
            client.ReadWriteTimeout = timeout;

            var request = new RestRequest("api/cart/get/" + userId, Method.GET);
            var queryResult = client.Execute<List<Cart>>(request).Data;

            return queryResult;
        }

        public IEnumerable<CartWithGiftBoxes> Get2(int? userId)
        {
            var client = new RestClient(url);
            client.Timeout = timeout;
            client.ReadWriteTimeout = timeout;

            var request = new RestRequest("api/cart/get/" + userId, Method.GET);
            var queryResult = client.Execute<List<Cart>>(request).Data;

            //Now get all giftboxes that are in the cart, and do verification on it.
            //create new Get call in the giftbox microservice that takes a list of id's and returns them.

            //return queryResult;

            throw new NotImplementedException();
        }

        public void Post(int userId, int giftBoxId, int quantity)
        {
            var client = new RestClient(url);
            client.Timeout = timeout;
            client.ReadWriteTimeout = timeout;

            var requestString = "api/cart/post?userid=" + userId + "&giftboxid=" + giftBoxId + "&quantity=" + quantity;
            var request = new RestRequest(requestString, Method.POST);

            client.Execute(request);
        }

        public bool Put(int cartId, int userId, int giftBoxId, int quantity)
        {
            var client = new RestClient(url);
            client.Timeout = timeout;
            client.ReadWriteTimeout = timeout;

            var requestString = "api/Cart/Put?userId=" + userId + "&giftBoxId=" + giftBoxId + "&quantity=" + quantity;
            var request = new RestRequest(requestString, Method.PUT);

            client.Execute(request);

            return true;
        }

        public bool Delete(int cartId)
        {
            var client = new RestClient(url);
            client.Timeout = timeout;
            client.ReadWriteTimeout = timeout;

            var requestString = "api/Cart/Delete?cartId=" + cartId;
            var request = new RestRequest(requestString, Method.DELETE);

            client.Execute(request);
            
            return true;
        }
    }
}