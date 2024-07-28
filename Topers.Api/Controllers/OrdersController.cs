using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

namespace Topers.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController(IOrdersService orderService) : ControllerBase
    {
        private readonly IOrdersService _ordersService = orderService;

        [HttpGet]
        [SwaggerResponse(
            200,
            Description = "Returns an orders list.",
            Type = typeof(IEnumerable<OrderResponseDto>)
        )]
        [SwaggerResponse(400, Description = "Orders not found.")]
        public async Task<ActionResult<List<OrderResponseDto>>> GetOrders(
            CancellationToken cancellationToken
        )
        {
            var orders = await _ordersService.GetAllOrdersAsync(cancellationToken);

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        [HttpGet("{orderId:guid}")]
        [SwaggerResponse(
            200,
            Description = "Returns an orders list.",
            Type = typeof(OrderResponseDto)
        )]
        [SwaggerResponse(400, Description = "Orders not found.")]
        public async Task<ActionResult<OrderResponseDto>> GetOrderById(
            [FromRoute] Guid orderId,
            CancellationToken cancellationToken
        )
        {
            var order = await _ordersService.GetOrderByIdAsync(orderId, cancellationToken);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost("create")]
        [SwaggerResponse(200, Description = "Create a new order.")]
        [SwaggerResponse(400, Description = "There are some errors in the model.")]
        public async Task<ActionResult<OrderResponseDto>> CreateGood(
            [FromBody] OrderRequestDto order,
            CancellationToken cancellationToken
        )
        {
            var newOrder = new Order(Guid.Empty, order.Date, order.CustomerId, 0);

            var newOrderEntity = await _ordersService.CreateOrderAsync(newOrder, cancellationToken);

            return Ok(newOrderEntity);
        }

        [HttpPut("{orderId:guid}")]
        [SwaggerResponse(200, Description = "Update an existing order.")]
        [SwaggerResponse(400, Description = "There are some errors in the model.")]
        public async Task<ActionResult<OrderResponseDto>> UpdateOrder(
            [FromRoute] Guid orderId,
            [FromBody] UpdateOrderRequestDto order,
            CancellationToken cancellationToken
        )
        {
            var existOrder = new Order(
                orderId,
                DateTime.UtcNow,
                order.CustomerId,
                Decimal.MinValue
            );

            var updatedOrder = await _ordersService.UpdateOrderAsync(existOrder, cancellationToken);

            return Ok(updatedOrder);
        }

        [HttpPost("{orderId:guid}/addGood")]
        [SwaggerResponse(200, Description = "Add good to an existing order.")]
        [SwaggerResponse(400, Description = "There are some errors in the model.")]
        public async Task<ActionResult<OrderResponseDto>> AddProductToOrder(
            [FromRoute] Guid orderId,
            [FromBody] AddProductRequestDto orderDetail,
            CancellationToken cancellationToken
        )
        {
            var newGoodDetail = new OrderDetails(
                Guid.Empty,
                orderId,
                orderDetail.GoodScopeId,
                orderDetail.GoodQuantity,
                default
            );

            var newGoodScope = new GoodScope(
                Guid.Empty,
                orderDetail.GoodScopeId,
                orderDetail.GoodLitre
            );

            var newGoodDetailIdentifier = await _ordersService.AddGoodToOrderAsync(
                newGoodDetail,
                newGoodScope,
                cancellationToken
            );

            return Ok(newGoodDetailIdentifier);
        }
    }
}
