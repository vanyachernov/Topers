using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

namespace Topers.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController(
        IOrdersService orderService
    ) : ControllerBase
    {
        private readonly IOrdersService _ordersService = orderService;

        [HttpGet]
        [SwaggerResponse(200, Description = "Returns an orders list.", Type = typeof(IEnumerable<OrderResponseDto>))]
        [SwaggerResponse(400, Description = "Orders not found.")]
        public async Task<ActionResult<List<OrderResponseDto>>> GetOrders()
        {
            var orders = await _ordersService.GetAllOrdersAsync();

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        [HttpGet("{orderId:guid}")]
        [SwaggerResponse(200, Description = "Returns an orders list.", Type = typeof(OrderResponseDto))]
        [SwaggerResponse(400, Description = "Orders not found.")]
        public async Task<ActionResult<OrderResponseDto>> GetOrderById([FromRoute] Guid orderId)
        {
            var order = await _ordersService.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost("create")]
        [SwaggerResponse(200, Description = "Create a new order.")]
        [SwaggerResponse(400, Description = "There are some errors in the model.")]
        public async Task<ActionResult<OrderResponseDto>> CreateGood([FromBody] OrderRequestDto order)
        {
            var newOrder = new Order
            (
                Guid.Empty,
                order.Date,
                order.CustomerId,
                0
            );

            var newOrderEntity = await _ordersService.CreateOrderAsync(newOrder);

            return Ok(newOrderEntity);
        }

        [HttpPut("{orderId:guid}")]
        [SwaggerResponse(200, Description = "Update an existing order.")]
        [SwaggerResponse(400, Description = "There are some errors in the model.")]
        public async Task<ActionResult<OrderResponseDto>> UpdateOrder([FromRoute] Guid orderId, [FromBody] UpdateOrderRequestDto order)
        {
            var existOrder = new Order
            (
                orderId,
                DateTime.UtcNow,
                order.CustomerId,
                Decimal.MinValue
            );

            var updatedOrder = await _ordersService.UpdateOrderAsync(existOrder);

            return Ok(updatedOrder);
        }

        [HttpPost("{orderId:guid}/addGood")]
        [SwaggerResponse(200, Description = "Add good to an existing order.")]
        [SwaggerResponse(400, Description = "There are some errors in the model.")]
        public async Task<ActionResult<OrderResponseDto>> AddProductToOrder([FromRoute] Guid orderId, [FromBody] AddProductToOrderRequestDto orderDetail)
        {
            var newGoodDetail = new OrderDetails
            (
                orderId,
                orderDetail.GoodScopeId,
                orderDetail.GoodQuantity
            );

            var newGoodScope = new GoodScope
            (
                Guid.Empty,
                orderDetail.GoodScopeId,
                orderDetail.GoodLitre
            );

            var newGoodDetailIdentifier = await _ordersService.AddGoodToOrderAsync(newGoodDetail, newGoodScope);

            return Ok(newGoodDetailIdentifier);
        }
    }
}