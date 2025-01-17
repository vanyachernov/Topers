namespace Topers.Api.Contollers;

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;
using Topers.Core.Validators;

[ApiController]
[Route("api/goods")]
public class GoodsController(
    IGoodsService goodService,
    IFileService fileService) : ControllerBase
{
    private readonly IGoodsService _goodService = goodService;
    private readonly IFileService _fileService = fileService;

    [HttpGet]
    [SwaggerResponse(200, Description = "Returns a good list.", Type = typeof(IEnumerable<GoodResponseDto>))]
    [SwaggerResponse(400, Description = "Goods not found.")]
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
    [SwaggerResponse(400, Description = "Good not found.")]
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
    [SwaggerResponse(400, Description = "There are some errors in the model.")]
    public async Task<ActionResult<GoodResponseDto>> CreateGood(
        [FromBody] GoodRequestDto good,
        CancellationToken cancellationToken)
    {
        var newGoodValidator = new GoodDtoValidator();

        var newGoodValidatorResult = newGoodValidator.Validate(good);

        if (!newGoodValidatorResult.IsValid)
        {
            return BadRequest(newGoodValidatorResult.Errors);
        }

        var newGood = new Good
        (
            Guid.Empty,
            good.CategoryId,
            good.Name,
            good.Description
        );

        var newGoodEntity = await _goodService.CreateGoodAsync(newGood, cancellationToken);

        return Ok(newGoodEntity);
    }

    [HttpPut("{goodId:guid}")]
    [SwaggerResponse(200, Description = "Update an existing good.")]
    [SwaggerResponse(400, Description = "There are some errors in the model.")]
    public async Task<ActionResult<GoodResponseDto>> UpdateGood(
        [FromRoute] Guid goodId, 
        [FromBody] GoodRequestDto good,
        CancellationToken cancellationToken)
    {
        var goodValidator = new GoodDtoValidator();

        var goodValidatorResult = goodValidator.Validate(good);

        if (!goodValidatorResult.IsValid)
        {
            return BadRequest(goodValidatorResult.Errors);
        }

        var existGood = new Good
        (
            goodId,
            good.CategoryId,
            good.Name,
            good.Description
        );

        var updatedGood = await _goodService.UpdateGoodAsync(existGood, cancellationToken);

        return Ok(updatedGood);
    }

    [HttpDelete("{goodId:guid}")]
    [SwaggerResponse(200, Description = "Delete good.")]
    public async Task<ActionResult<Guid>> DeleteGood(
        [FromRoute] Guid goodId,
        CancellationToken cancellationToken)
    {
        await _goodService.DeleteGoodAsync(goodId, cancellationToken);

        return Ok(goodId);
    }

    [HttpPost("{goodId:guid}/addScope")]
    public async Task<ActionResult<Guid>> AddGoodScope(
        [FromRoute] Guid goodId, 
        [FromForm] GoodScopeRequestDto scope,
        CancellationToken cancellationToken)
    {
        if (scope.ImageFile == null)
        {
            return BadRequest("Good image not found!");
        }

        var fileResult = _fileService.SaveImage(scope.ImageFile);

        if (fileResult.Item1 == 1)
        {
            scope = scope with { ImageName = fileResult.Item2 };
        }

        var scopeModel = new GoodScope(
            Guid.Empty,
            goodId,
            scope.Litre,
            scope.Price,
            scope.ImageName
        );

        var isUpdated = await _goodService.IsGoodScopeExistsAsync(goodId, scopeModel.Litre, cancellationToken);

        var newScopeIdentifier = (!isUpdated) ? await _goodService.AddGoodScopeAsync(scopeModel, cancellationToken) : await _goodService.UpdateGoodScopeAsync(scopeModel, cancellationToken);

        return Ok(newScopeIdentifier);
    }
}