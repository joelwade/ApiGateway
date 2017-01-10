using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace Pages
{
    public class OrderPage
    {
        public IEnumerable<CartWithGiftBoxes> cart { get; set; }
        public IEnumerable<OrderWithGiftBoxes> orders { get; set; }
    }
}
