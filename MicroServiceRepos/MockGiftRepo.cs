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

        Random rnd;

        public MockGiftRepo()
        {
            rnd = new Random();
            boxes = CreateBoxes();
        }

        public IEnumerable<GiftBox> Get()
        {
            return boxes.Where(a => a.active == true);
        }

        public IEnumerable<GiftBox> Get(List<int> ids)
        {
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
            list.Add(new GiftBox
            {
                active = true,
                id = 1,
                products = GenerateRandProducts(4),
                wrapping = GenerateRandWrapping(),
                price = 4
            });
            list.Add(new GiftBox
            {
                active = true,
                id = 2,
                products = GenerateRandProducts(3),
                wrapping = GenerateRandWrapping(),
                price = 3
            });
            list.Add(new GiftBox
            {
                active = true,
                id = 3,
                products = GenerateRandProducts(2),
                wrapping = GenerateRandWrapping(),
                price = 5
            });
            list.Add(new GiftBox
            {
                active = true,
                id = 4,
                products = GenerateRandProducts(2),
                wrapping = GenerateRandWrapping(),
                price = 6
            });
            list.Add(new GiftBox
            {
                active = true,
                id = 5,
                products = GenerateRandProducts(2),
                wrapping = GenerateRandWrapping(),
                price = 7
            });
            list.Add(new GiftBox
            {
                active = true,
                id = 6,
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
                id = 1,
                ean = GenerateRandString(8),
                categoryId = rnd.Next(1, 50),
                categoryName = GenerateRandString(5),
                brandId = rnd.Next(1, 15),
                brandName = GenerateRandString(4),
                name = GenerateRandString(3),
                description = GenerateRandString(14),
                price = rnd.NextDouble(),
                inStock = true,
                expectedRestock = DateTime.UtcNow.AddDays(rnd.Next(90))
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