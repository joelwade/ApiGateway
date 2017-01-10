using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace MicroServiceRepos
{
    public interface IGiftBoxRepo
    {
        IEnumerable<GiftBox> Get();
        IEnumerable<GiftBox> Get(List<int> ids);
        void Post(GiftBox giftBox);
        bool Put(GiftBox giftBox);
        void Delete(GiftBox giftBox);
    }
}