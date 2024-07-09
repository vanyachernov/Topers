namespace Topers.Core.Abstractions;

using Topers.Core.Models;

public interface ICategoriesRepository
{
    Task<Guid> CreateAsync(Category category);
    Task<List<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(Guid categoryId);
    Task<List<Good>> GetGoodsByIdAsync(Guid categoryId);
    Task<Guid> UpdateAsync(Category category);
    Task<Guid> DeleteAsync(Guid categoryId);
};