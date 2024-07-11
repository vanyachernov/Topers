namespace Topers.Api.Controllers;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;
using Topers.Core.Validators;

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
    [SwaggerResponse(400, Description = "Categories not found.")]
    public async Task<ActionResult<List<CategoryResponseDto>>> GetCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();

        if (categories == null)
        {
            return BadRequest();
        }

        return Ok(categories);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("{categoryId:guid}")]
    [SwaggerResponse(200, Description = "Returns a category.", Type = typeof(CategoryResponseDto))]
    [SwaggerResponse(400, Description = "Category not found.")]
    public async Task<ActionResult<CategoryResponseDto>> GetCategory([FromRoute] Guid categoryId)
    {
        var category = await _categoryService.GetCategoryByIdAsync(categoryId);

        if (category == null)
        {
            return BadRequest();
        }

        return Ok(category);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("{categoryId:guid}/goods")]
    [SwaggerResponse(200, Description = "Returns a category goods.", Type = typeof(IEnumerable<GoodResponseDto>))]
    [SwaggerResponse(400, Description = "Goods not found.")]
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
    [SwaggerResponse(400, Description = "There are some errors in the model.")]
    public async Task<ActionResult<CategoryResponseDto>> CreateCategory([FromBody] CategoryRequestDto category)
    {
        var categoryValidator = new CategoryDtoValidator();

        var categoryValidatorResult = categoryValidator.Validate(category);

        if (!categoryValidatorResult.IsValid) 
        {
            return BadRequest(categoryValidatorResult.Errors);
        }
        
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
    [SwaggerResponse(400, Description = "There are some errors in the model.")]
    public async Task<ActionResult<CategoryResponseDto>> UpdateCategory([FromRoute] Guid categoryId, [FromBody] CategoryRequestDto category)
    {
        var categoryValidator = new CategoryDtoValidator();

        var categoryValidatorResult = categoryValidator.Validate(category);

        if (!categoryValidatorResult.IsValid) 
        {
            return BadRequest(categoryValidatorResult.Errors);
        }

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