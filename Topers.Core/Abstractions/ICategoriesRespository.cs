namespace Topers.Core.Abstractions;

using Topers.Core.Models;

public interface ICategoriesRepository
{
    Task<Guid> CreateAsync(Category category, CancellationToken cancellationToken = default);
    Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Category> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
    Task<List<Good>> GetGoodsByIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
    Task<Guid> UpdateAsync(Category category, CancellationToken cancellationToken = default);
    Task<Guid> DeleteAsync(Guid categoryId, CancellationToken cancellationToken = default);
};