using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class OrderWithGiftBoxes
    {
        public int orderId { get; set; }
        public int userId { get; set; }
        public int giftBoxId { get; set; }
        public int quantity { get; set; }
        public DateTime date { get; set; }
        public IEnumerable<GiftBox> giftBoxes { get; set; }
    }
}
