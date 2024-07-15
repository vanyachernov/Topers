using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Topers.Core.Abstractions;
using Topers.Core.Models;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.DataAccess.Postgres.Repositories;

public class GoodsRepository : IGoodsRepository
{
    private readonly TopersDbContext _context;
    private readonly IMapper _mapper;

    public GoodsRepository(TopersDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(Good good)
    {
        var goodEntity = new GoodEntity
        {
            Id = Guid.NewGuid(),
            CategoryId = good.CategoryId,
            Name = good.Name,
            Description = good.Description
        };

        await _context.Goods.AddAsync(goodEntity);
        await _context.SaveChangesAsync();

        return goodEntity.Id;
    }

    public async Task<Guid> DeleteAsync(Guid goodId)
    {
        await _context.Goods
            .Where(g => g.Id == goodId)
            .ExecuteDeleteAsync();

        return goodId;
    }

    public async Task<List<Good>> GetAllAsync()
    {
        var goodEntities = await _context.Goods
            .Include(g => g.Scopes)
            .AsNoTracking()
            .ToListAsync();

        var goodEntitiesDto = _mapper.Map<List<Good>>(goodEntities);

        return goodEntitiesDto;
    }

    public async Task<List<Good>> GetByFilterAsync(string title)
    {
        var query = _context.Goods.Include(g => g.Scopes).AsNoTracking();

        if(!string.IsNullOrEmpty(title))
        {
            query = query.Where(g => g.Name.Contains(title));
        }

        var goodEntitiesDto = _mapper.Map<List<Good>>(await query.ToListAsync());

        return goodEntitiesDto;
    }

    public async Task<Good> GetByIdAsync(Guid goodId)
    {
        var goodEntity = await _context.Goods
            .AsNoTracking()
            .FirstOrDefaultAsync(g => g.Id == goodId);

        var goodEntityDto = _mapper.Map<Good>(goodEntity);

        return goodEntityDto;
    }

    public async Task<Guid> UpdateAsync(Good good)
    {
        await _context.Goods
            .Where(g => g.Id == good.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(g => g.Name, good.Name)
                .SetProperty(g => g.CategoryId, good.CategoryId)
                .SetProperty(g => g.Description, good.Description));

        return good.Id;
    }

    public async Task<GoodScope> GetScopeAsync(Guid goodId, int litre)
    {
        var pExistsGoodScope = await _context.GoodScopes
                .FirstOrDefaultAsync(gs => gs.GoodId == goodId && gs.Litre == litre);
                
        return _mapper.Map<GoodScope>(pExistsGoodScope);
    }

    public async Task<Guid> AddScopeAsync(GoodScope goodScope)
    {
        var scopeEntity = new GoodScopeEntity
        {
            Id = Guid.NewGuid(),
            GoodId = goodScope.GoodId,
            Litre = goodScope.Litre,
            Price = goodScope.Price,
            Image = goodScope.ImageName
        };

        await _context.GoodScopes.AddAsync(scopeEntity);
        await _context.SaveChangesAsync();

        return scopeEntity.Id;
    }

    public async Task<Guid> UpdateScopeAsync(GoodScope goodScope)
    {
        var existingGoodScope = await _context.GoodScopes
            .AsNoTracking()
            .FirstOrDefaultAsync(gs => gs.GoodId == goodScope.GoodId && gs.Litre == goodScope.Litre);

        await _context.GoodScopes
            .Where(gs => gs.GoodId == goodScope.GoodId && gs.Litre == goodScope.Litre)
            .ExecuteUpdateAsync(s => s
                .SetProperty(gs => gs.Image, goodScope.ImageName)
                .SetProperty(gs => gs.Litre, goodScope.Litre)
                .SetProperty(gs => gs.Price, goodScope.Price));
        
        return existingGoodScope!.Id;
    }
}