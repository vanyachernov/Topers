namespace Topers.Core.Abstractions;

using Topers.Core.Dtos;
using Topers.Core.Models;

public interface ICategoriesService
{
    Task<Guid> CreateCategoryAsync(Category category);
    Task<List<CategoryResponseDto>> GetAllCategoriesAsync();
    Task<CategoryResponseDto> GetCategoryByIdAsync(Guid categoryId);
    Task<List<GoodResponseDto>> GetGoodsByCategoryIdAsync(Guid categoryId);
    Task<Guid> UpdateCategoryAsync(Category category);
    Task<Guid> DeleteCategoryAsync(Guid categoryId);
};