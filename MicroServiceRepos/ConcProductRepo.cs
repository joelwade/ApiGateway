using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;
using RestSharp;

namespace MicroServiceRepos
{
    public class ConcProductRepo : IProductRepo
    {
        string url = "http://localhost:13879/";
        int timeout = 2000;
        public IEnumerable<Product> GetAll()
        {
            var client = new RestClient(url);
            client.Timeout = timeout;
            client.ReadWriteTimeout = timeout;

            var request = new RestRequest("api/product", Method.GET);
            var queryResult = client.Execute<List<Product>>(request).Data;

            return queryResult.AsEnumerable();
        }

        public Product GetById(int id)
        {
            var client = new RestClient(url);
            client.Timeout = timeout;
            client.ReadWriteTimeout = timeout;

            var request = new RestRequest("api/product" + id, Method.GET);
            var queryResult = client.Execute<Product>(request).Data;

            return queryResult;
        }

        public IEnumerable<Product> GetByIds(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}