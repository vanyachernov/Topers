using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

namespace Topers.Api.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartsController(ICartsService cartService) : ControllerBase
    {
        private readonly ICartsService _cartService = cartService;

        [HttpGet("{cartId:guid}")]
        [SwaggerResponse(
            200,
            Description = "Returns a cart by identifier.",
            Type = typeof(CartResponseDto)
        )]
        [SwaggerResponse(400, Description = "Cart not found.")]
        public async Task<ActionResult<OrderResponseDto>> GetCartById(
            [FromRoute] Guid cartId,
            CancellationToken cancellationToken
        )
        {
            var cart = await _cartService.GetCartById(cartId, cancellationToken);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        [HttpGet("{customerId:guid}")]
        [SwaggerResponse(
            200,
            Description = "Returns a cart by customer identifier.",
            Type = typeof(CartResponseDto)
        )]
        [SwaggerResponse(400, Description = "Cart not found.")]
        public async Task<ActionResult<OrderResponseDto>> GetCartByCustomerId(
            [FromRoute] Guid customerId,
            CancellationToken cancellationToken
        )
        {
            var cart = await _cartService.GetCartByCustomerId(customerId, cancellationToken);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        [HttpPost("create")]
        [SwaggerResponse(200, Description = "Create a new cart.")]
        [SwaggerResponse(400, Description = "There are some errors in the model.")]
        public async Task<ActionResult<CartResponseDto>> CreateCart(
            [FromBody] CartRequestDto cart,
            CancellationToken cancellationToken
        )
        {
            var newCart = new Cart
            (
                Guid.Empty,
                cart.CustomerId,
                DateTime.UtcNow,
                DateTime.UtcNow
            );

            var newCartEntity = await _cartService.CreateCartAsync(newCart, cancellationToken);

            return Ok(newCartEntity);
        }

        [HttpPost("{cartId:guid}/addGood")]
        [SwaggerResponse(200, Description = "Add good to a customer cart.")]
        [SwaggerResponse(400, Description = "There are some errors in the model.")]
        public async Task<ActionResult<CartResponseDto>> AddProductToCart(
            [FromRoute] Guid cartId,
            [FromBody] AddProductRequestDto cartDetail,
            CancellationToken cancellationToken
        )
        {
            var newGoodDetail = new CartItems(
                Guid.Empty,
                cartId,
                cartDetail.GoodScopeId,
                cartDetail.GoodQuantity,
                default
            );

            var newGoodScope = new GoodScope(
                Guid.Empty,
                cartDetail.GoodScopeId,
                cartDetail.GoodLitre
            );

            var newGoodDetailIdentifier = await _cartService.AddGoodToCartAsync(
                newGoodDetail,
                newGoodScope,
                cancellationToken
            );

            return Ok(newGoodDetailIdentifier);
        }
    }
}
