namespace Topers.Core.Abstractions;

using Topers.Core.Models;

public interface IGoodsRepository
{
    Task<Guid> CreateAsync(Good good, CancellationToken cancellationToken = default);
    Task<List<Good>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Good> GetByIdAsync(Guid goodId, CancellationToken cancellationToken = default);
    Task<List<Good>> GetByFilterAsync(string title, CancellationToken cancellationToken = default);
    Task<Guid> UpdateAsync(Good good, CancellationToken cancellationToken = default);
    Task<Guid> DeleteAsync(Guid goodId, CancellationToken cancellationToken = default);
    Task<GoodScope> GetScopeAsync(Guid goodId, int litre, CancellationToken cancellationToken = default);
    Task<Guid> AddScopeAsync(GoodScope goodScope, CancellationToken cancellationToken = default);
    Task<Guid> UpdateScopeAsync(GoodScope goodScope, CancellationToken cancellationToken = default);
};