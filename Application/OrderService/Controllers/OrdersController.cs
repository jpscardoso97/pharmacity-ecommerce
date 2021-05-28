using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using OrderService.InputTypes;
    using OrderService.Models;
    using OrderService.QueryHandlers;

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderCreationQueryHandler _queryHandler;
        
        public OrdersController(OrderCreationQueryHandler queryHandler)
        {
            _queryHandler = queryHandler;
        }
        
        [HttpPost("products")]
        public async Task<IActionResult> CreateProductsOrder([FromBody] NewProductsOrderInput order)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(await _queryHandler.CreateProductsOrder(order.Order, order.CartId)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default;
            }
        }
        
        [HttpPost]
        [Route("prescription")]
        public async Task<IActionResult> CreatePrescriptionOrder([FromBody] NewPrescriptionOrderInput order)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(await _queryHandler.CreatePrescriptionOrder(order.Order, order.CartId)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default;
            }
        }
    }
}