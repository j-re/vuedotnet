using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vue.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace vue.Features.Orders
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly VueContext _db;
        public OrdersController(VueContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _db.Users.SingleAsync(x => x.UserName == HttpContext.User.Identity.Name);
            var order = new Order
            {
                DeliveryAddress = new Address
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    TownCity = model.TownCity,
                    County = model.County,
                    Postcode = model.Postcode
                },
                Items = model.Items.Select(x => new OrderItem
                {
                    ProductId = x.ProductId,
                    ColourId = x.ColourId,
                    StorageId = x.StorageId,
                    Quantity = x.Quantity
                }).ToList()
            };
            user.Orders.Add(order);
            await _db.SaveChangesAsync();
        }

    }
}