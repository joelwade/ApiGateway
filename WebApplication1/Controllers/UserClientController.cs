using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MicroServiceRepos;
using Dtos;
using Pages;

namespace WebApplication1.Controllers
{
    public class UserClientController : ApiController
    {
        private readonly IGiftBoxRepo giftRepo;
        private readonly IOrderRepo orderRepo;
        private readonly ICartRepo cartRepo;

        public UserClientController(IGiftBoxRepo giftRepo, IOrderRepo orderRepo, ICartRepo cartRepo)
        {
            this.giftRepo = giftRepo;
            this.orderRepo = orderRepo;
            this.cartRepo = cartRepo;
        }

        /// <summary>
        /// Get Methods
        /// </summary>

        [HttpGet]
        [Route("api/getGiftBox")]
        public IEnumerable<GiftBox> GetGiftBoxes()
        {
            return giftRepo.Get();
        }

        public IEnumerable<GiftBox> GetGiftBoxes(List<int> ids)
        {
            return giftRepo.Get(ids);
        }

        [HttpGet]
        [Route("api/getOrder")]
        public IEnumerable<Order> GetOrdersById(int? id)
        {
            return orderRepo.Get(id);
        }

        [HttpGet]
        [Route("api/getCart")]
        public IEnumerable<Cart> GetCartById(int? id)
        {
            return cartRepo.Get(id);
        }

        [HttpGet]
        [Route("api/getStorePage")]
        public StorePage GetStorePage(int? userId)
        {
            StorePage page = new StorePage();
            IEnumerable<GiftBox> boxes = GetGiftBoxes();
            IEnumerable<Cart> cart = GetCartById(userId);

            page.cart = GetCartWithGiftBoxes(cart, boxes);
            page.giftBox = boxes;

            return page;
        }

        [HttpGet]
        [Route("api/getOrderPage")]
        public OrderPage GetOrderPage(int? userId)
        {
            OrderPage page = new OrderPage();
            IEnumerable<GiftBox> boxes = GetGiftBoxes();
            IEnumerable<Cart> cart = GetCartById(userId);
            IEnumerable<Order> orders = GetOrdersById(userId);

            page.cart = GetCartWithGiftBoxes(cart, boxes);
            page.orders = GetOrderWithGiftBoxes(orders, boxes);

            return page;
        }

        /// <summary>
        ///  Post Methods
        /// </summary>

        [HttpPost]
        [Route("api/postCart")]
        public HttpResponseMessage PostCart(int userId, int giftBoxId, int quantity)
        {
            cartRepo.Post(userId, giftBoxId, quantity);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/postOrder")]
        public HttpResponseMessage PostOrder(int userId, int giftBoxId, int quantity)
        {
            orderRepo.Post(userId, giftBoxId, quantity);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/postGiftBox")]
        public HttpResponseMessage PostGiftBox([FromBody]GiftBox box)
        {
            giftRepo.Post(box);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //http://stackoverflow.com/questions/20226169/how-to-pass-json-post-data-to-web-api-method-as-object

        /// <summary>
        ///  Put Methods
        /// </summary>

        [HttpPut]
        [Route("api/putCart")]
        public HttpResponseMessage PutCart(int cartId, int userId, int giftBoxId, int quantity)
        {
            bool result = cartRepo.Put(cartId, userId, giftBoxId, quantity);

            return CheckResult(result);
        }

        [HttpPut]
        [Route("api/putOrder")]
        public HttpResponseMessage PutOrder(int orderId, int userId, int giftBoxId, int quantity)
        {
            bool result = orderRepo.Put(orderId, userId, giftBoxId, quantity);

            return CheckResult(result);
        }

        [HttpPut]
        [Route("api/putGiftBox")]
        public HttpResponseMessage PutGiftBox([FromBody]GiftBox box)
        {
            bool result = giftRepo.Put(box);

            return CheckResult(result);
        }

        /// <summary>
        ///  Delete Methods
        /// </summary>

        [HttpDelete]
        [Route("api/deleteCart")]
        public HttpResponseMessage DeleteCart(int cartId)
        {
            bool result = cartRepo.Delete(cartId);

            return CheckResult(result);
        }

        [HttpDelete]
        [Route("api/deleteOrder")]
        public HttpResponseMessage DeleteOrder(int orderId)
        {
            bool result = orderRepo.Delete(orderId);

            return CheckResult(result);
        }

        /// <summary>
        /// Private Methods
        /// </summary>

        private HttpResponseMessage CheckResult(bool res)
        {
            if (res)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }

        private IEnumerable<CartWithGiftBoxes> GetCartWithGiftBoxes(IEnumerable<Cart> cart, IEnumerable<GiftBox> boxes)
        {
            List<int> ids = cart.Select(a => a.giftBoxId).Distinct().ToList();

            List<CartWithGiftBoxes> cartWithBoxes = new List<CartWithGiftBoxes>();
            foreach (var item in cart.ToList())
            {
                cartWithBoxes.Add(new CartWithGiftBoxes
                {
                    cartId = item.cartId,
                    giftBoxId = item.giftBoxId,
                    quantity = item.quantity,
                    userId = item.quantity,
                    giftBox = boxes.Where(b => b.id == item.giftBoxId && b.active == true).FirstOrDefault()
                });
            }
            return cartWithBoxes.AsEnumerable();
        }

        private IEnumerable<OrderWithGiftBoxes> GetOrderWithGiftBoxes(IEnumerable<Order> order, IEnumerable<GiftBox> boxes)
        {
            List<int> ids = order.Select(a => a.giftBoxId).Distinct().ToList();

            List<OrderWithGiftBoxes> orderWithBoxes = new List<OrderWithGiftBoxes>();
            foreach (var item in order.ToList())
            {
                orderWithBoxes.Add(new OrderWithGiftBoxes
                {
                    orderId = item.orderId,
                    giftBoxId = item.giftBoxId,
                    quantity = item.quantity,
                    userId = item.quantity,
                    date = item.date,
                    giftBoxes = boxes.Where(x => x.id == item.giftBoxId)
                });
            }
            return orderWithBoxes.AsEnumerable();
        }
    }
}