namespace Topers.Core.Abstractions;

using Topers.Core.Dtos;
using Topers.Core.Models;

public interface ICategoriesService
{
    Task<CategoryResponseDto> CreateCategoryAsync(Category category, CancellationToken cancellationToken = default);
    Task<List<CategoryResponseDto>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
    Task<CategoryResponseDto> GetCategoryByIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
    Task<List<GoodResponseDto>> GetGoodsByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
    Task<Guid> UpdateCategoryAsync(Category category, CancellationToken cancellationToken = default);
    Task<Guid> DeleteCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default);
};