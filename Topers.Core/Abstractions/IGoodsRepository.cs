namespace Topers.Core.Abstractions;

using Topers.Core.Models;

public interface IGoodsRepository
{
    Task<Guid> CreateAsync(Good good);
    Task<List<Good>> GetAllAsync();
    Task<Good> GetByIdAsync(Guid goodId);
    Task<List<Good>> GetByFilterAsync(string title);
    Task<Guid> UpdateAsync(Good good);
    Task<Guid> DeleteAsync(Guid goodId);
    Task<GoodScope> GetScopeAsync(Guid goodId, int litre);
    Task<Guid> AddScopeAsync(GoodScope goodScope);
    Task<Guid> UpdateScopeAsync(GoodScope goodScope);
};