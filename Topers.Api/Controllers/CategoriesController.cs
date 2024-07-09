namespace Topers.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesService _categoryService;

    public CategoriesController(ICategoriesService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [SwaggerResponse(200, Description = "Returns a category list.", Type = typeof(IEnumerable<CategoryResponseDto>))]
    [SwaggerResponse(400)]
    public async Task<ActionResult<List<CategoryResponseDto>>> GetCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();

        if (categories == null)
        {
            return BadRequest();
        }

        return Ok(categories);
    }

    [HttpGet("{categoryId:guid}")]
    [SwaggerResponse(200, Description = "Returns a category.", Type = typeof(CategoryResponseDto))]
    [SwaggerResponse(400)]
    public async Task<ActionResult<CategoryResponseDto>> GetCategory([FromRoute] Guid categoryId)
    {
        var category = await _categoryService.GetCategoryByIdAsync(categoryId);

        if (category == null)
        {
            return BadRequest();
        }

        return Ok(category);
    }

    [HttpGet("{categoryId:guid}/goods")]
    [SwaggerResponse(200, Description = "Returns a category goods.", Type = typeof(IEnumerable<GoodResponseDto>))]
    [SwaggerResponse(400)]
    public async Task<ActionResult<List<GoodResponseDto>>> GetCategoryGoods([FromRoute] Guid categoryId)
    {
        var goods = await _categoryService.GetGoodsByCategoryIdAsync(categoryId);

        if (goods == null)
        {
            return BadRequest();
        }

        return Ok(goods);
    }

    [HttpPost("create")]
    [SwaggerResponse(200, Description = "Create a new category.")]
    public async Task<ActionResult<CategoryResponseDto>> CreateCategory([FromBody] CategoryRequestDto category)
    {
        var newCategory = new Category
        (
            Guid.Empty,
            category.Name,
            category.Description
        );

        var newCategoryEntity = await _categoryService.CreateCategoryAsync(newCategory);

        return Ok(newCategoryEntity);
    }

    [HttpPut("{categoryId:guid}")]
    [SwaggerResponse(200, Description = "Update an existing category.")]
    public async Task<ActionResult<CategoryResponseDto>> UpdateCategory([FromRoute] Guid categoryId, [FromBody] CategoryRequestDto category)
    {
        var existCategory = new Category
        (
            categoryId,
            category.Name,
            category.Description
        );

        var updatedCategory = await _categoryService.UpdateCategoryAsync(existCategory);

        return Ok(updatedCategory);
    }

    [HttpDelete("{categoryId:guid}")]
    [SwaggerResponse(200, Description = "Delete category.")]
    public async Task<ActionResult<Guid>> DeleteCategory([FromRoute] Guid categoryId)
    {
        await _categoryService.DeleteCategoryAsync(categoryId);

        return Ok(categoryId);
    }
}