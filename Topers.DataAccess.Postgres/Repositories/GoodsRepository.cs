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
}