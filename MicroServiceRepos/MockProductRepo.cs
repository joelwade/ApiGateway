using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace MicroServiceRepos
{
    public class MockProductRepo : IProductRepo
    {
        List<Product> prods;

        public MockProductRepo()
        {
            prods = GetProdsList();
        }

        private List<Product> GetProdsList()
        {
            List<Product> prods = new List<Product>();
            prods.Add(new Product
            {
                ThAmCo_Id = 1,
                Ean = "t43hhyghht5gfhg",
                Name = "Tasty food nom",
                Description = "its tasty, and food, nom",
                Price = 4,
                PriceForTen = 15,
                InStock = true,
                ExpectedRestock = new DateTime()
            });
            prods.Add(new Product
            {
                ThAmCo_Id = 2,
                Ean = "43rgtjio5tgf0vv",
                Name = "Banana",
                Description = "ring ring ring",
                Price = 3,
                PriceForTen = 10,
                InStock = true,
                ExpectedRestock = new DateTime()
            });
            prods.Add(new Product
            {
                ThAmCo_Id = 3,
                Ean = "54trgf6hhhhhh",
                Name = "pancetta",
                Description = "Tasty cheese",
                Price = 6,
                PriceForTen = 22,
                InStock = true,
                ExpectedRestock = new DateTime()
            });
            prods.Add(new Product
            {
                ThAmCo_Id = 4,
                Ean = "99787tgtgfvf",
                Name = "burgers and chips",
                Description = "100% angus beef burger, and proper good chips likehh",
                Price = 9,
                PriceForTen = 35,
                InStock = true,
                ExpectedRestock = new DateTime()
            });
            prods.Add(new Product
            {
                ThAmCo_Id = 5,
                Ean = "6yhgfdfd3e34",
                Name = "Bagek",
                Description = "s'aight",
                Price = 3,
                PriceForTen = 11,
                InStock = true,
                ExpectedRestock = new DateTime()
            });
            return prods;
        }

        public IEnumerable<Product> GetAll()
        {
            return prods.AsEnumerable();
        }

        public Product GetById(int id)
        {
            return prods.Where(a => a.ThAmCo_Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetByIds(List<int> ids)
        {
            List<Product> products = new List<Product>();
            foreach (int i in ids)
            {
                products.Add(prods.Where(x => x.ThAmCo_Id == i).FirstOrDefault());
            }
            return products.AsEnumerable();
        }
    }
}
