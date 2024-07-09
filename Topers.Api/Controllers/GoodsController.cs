namespace Topers.Api.Contollers;

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

[ApiController]
[Route("api/goods")]
public class GoodsController(IGoodsService goodService) : ControllerBase
{
    private readonly IGoodsService _goodService = goodService;

    [HttpGet]
    [SwaggerResponse(200, Description = "Returns a good list.", Type = typeof(IEnumerable<GoodResponseDto>))]
    [SwaggerResponse(400)]
    public async Task<ActionResult<List<GoodResponseDto>>> GetGoods()
    {
        var goods = await _goodService.GetAllGoodsAsync();

        if (goods == null)
        {
            return BadRequest();
        }

        return Ok(goods);
    }

    [HttpGet("{goodId:guid}")]
    [SwaggerResponse(200, Description = "Returns a good.", Type = typeof(GoodResponseDto))]
    [SwaggerResponse(400)]
    public async Task<ActionResult<GoodResponseDto>> GetGood([FromRoute] Guid goodId)
    {
        var good = await _goodService.GetGoodByIdAsync(goodId);

        if (good == null)
        {
            return BadRequest();
        }

        return Ok(good);
    }

    [HttpPost("create")]
    [SwaggerResponse(200, Description = "Create a new good.")]
    public async Task<ActionResult<GoodResponseDto>> CreateGood([FromBody] GoodRequestDto good)
    {
        var newGood = new Good
        (
            Guid.Empty,
            good.CategoryId,
            good.Name,
            good.Description,
            good.ImageName,
            good.Image
        );

        await _goodService.CreateGoodAsync(newGood);

        return Ok(newGood);
    }

    [HttpPut("{goodId:guid}")]
    [SwaggerResponse(200, Description = "Update an existing good.")]
    public async Task<ActionResult<GoodResponseDto>> UpdateGood([FromRoute] Guid goodId, [FromBody] GoodRequestDto good)
    {
        var existGood = new Good
        (
            goodId,
            good.CategoryId,
            good.Name,
            good.Description,
            good.ImageName,
            good.Image
        );

        var updatedGood = await _goodService.UpdateGoodAsync(existGood);

        return Ok(updatedGood);
    }

    [HttpDelete("{goodId:guid}")]
    [SwaggerResponse(200, Description = "Delete good.")]
    public async Task<ActionResult<Guid>> DeleteGood([FromRoute] Guid goodId)
    {
        await _goodService.DeleteGoodAsync(goodId);

        return Ok(goodId);
    }
}