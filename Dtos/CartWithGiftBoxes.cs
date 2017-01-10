﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class CartWithGiftBoxes
    {
        public int? cartId { get; set; }
        public int userId { get; set; }
        public int giftBoxId { get; set; }
        public int quantity { get; set; }
        public GiftBox giftBox { get; set; }
    }
}