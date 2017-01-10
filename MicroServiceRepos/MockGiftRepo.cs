using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace MicroServiceRepos
{
    public class MockGiftRepo : IGiftBoxRepo
    {
        IEnumerable<GiftBox> boxes;

        IProductRepo productRepo;

        Random rnd;

        public MockGiftRepo(IProductRepo prodRepo)
        {
            rnd = new Random();
            boxes = CreateBoxes();
            this.productRepo = prodRepo;
        }

        public IEnumerable<GiftBox> Get()
        {
            return boxes.Where(a => a.active == true);
        }

        public IEnumerable<GiftBox> Get(List<int> ids)
        {
            IEnumerable <GiftBox> bs = boxes.Where(b => ids.Contains(b.id));

            List<int?> prodIds = new List<int?>();
            foreach (GiftBox i in bs)
            {
                prodIds.AddRange(i.products.Select(c => c.ThAmCo_Id));
            }

            List<int?> debug = prodIds;
            return boxes.Where(b => ids.Contains(b.id));
        }

        public void Post(GiftBox giftBox)
        {
            throw new NotImplementedException();
        }

        public bool Put(GiftBox giftBox)
        {
            throw new NotImplementedException();
        }

        public void Delete(GiftBox giftBox)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<GiftBox> CreateBoxes()
        {
            List<GiftBox> list = new List<GiftBox>();
            //List<Product> prods1 = new List<Product>();
            //prods1.Add(productRepo.GetById(1));
            //prods1.Add(productRepo.GetById(3));
            //List<Product> prods2 = new List<Product>();
            //prods2.Add(productRepo.GetById(1));
            //prods2.Add(productRepo.GetById(4));
            //prods2.Add(productRepo.GetById(2));
            //List<Product> prods3 = new List<Product>();
            //prods3.Add(productRepo.GetById(1));
            //prods3.Add(productRepo.GetById(3));
            //prods3.Add(productRepo.GetById(3));
            //List<Product> prods4 = new List<Product>();
            //prods4.Add(productRepo.GetById(1));
            //prods4.Add(productRepo.GetById(3));
            list.Add(new GiftBox
            {
                active = true,
                id = 1,
                name = "Best damn giftbox you ever seen",
                products = GenerateRandProducts(3),
                wrapping = GenerateRandWrapping(),
                price = 4
            });
            list.Add(new GiftBox
            {
                active = true,
                id = 2,
                name = "S'aight",
                products = GenerateRandProducts(3),
                wrapping = GenerateRandWrapping(),
                price = 3
            });
            list.Add(new GiftBox
            {
                active = true,
                id = 3,
                name = "Giftbox 1",
                products = GenerateRandProducts(2),
                wrapping = GenerateRandWrapping(),
                price = 5
            });
            list.Add(new GiftBox
            {
                active = true,
                id = 4,
                name = "Chicken box",
                products = GenerateRandProducts(2),
                wrapping = GenerateRandWrapping(),
                price = 6
            });
            list.Add(new GiftBox
            {
                active = true,
                id = 5,
                name = "Whats in the boxxx",
                products = GenerateRandProducts(2),
                wrapping = GenerateRandWrapping(),
                price = 7
            });
            list.Add(new GiftBox
            {
                active = true,
                id = 6,
                name = "Wanna see a magic trick?",
                products = GenerateRandProducts(2),
                wrapping = GenerateRandWrapping(),
                price = 8
            });
            return list.AsEnumerable();
        }

        private Wrapping GenerateRandWrapping()
        {
            return new Wrapping
            {
                id = rnd.Next(1,51),
                name = GenerateRandString(6),
                description = GenerateRandString(15)
            };
        }

        private string GenerateRandString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789,.";
            var stringChars = new char[length];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rnd.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        private Product GenerateRandProduct()
        {
            return new Product
            {
                ThAmCo_Id = 1,
                Ean = GenerateRandString(8),
                Name = GenerateRandString(3),
                Description = GenerateRandString(14),
                Price = rnd.NextDouble(),
                PriceForTen = rnd.NextDouble() *4,
                InStock = true,
                ExpectedRestock = DateTime.UtcNow.AddDays(rnd.Next(90))
            };
        }

        private IEnumerable<Product> GenerateRandProducts(int count)
        {
            List<Product> prods = new List<Product>();
            for (int i=0; i < count; i++)
            {
                prods.Add(GenerateRandProduct());
            }
            return prods.AsEnumerable();
        }
    }
}