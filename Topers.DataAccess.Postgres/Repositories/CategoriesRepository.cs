using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Topers.Core.Abstractions;
using Topers.Core.Models;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.DataAccess.Postgres.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly TopersDbContext _context;
    private readonly IMapper _mapper;

    public CategoriesRepository(TopersDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(Category category, CancellationToken cancellationToken = default)
    {
        var categoryEntity = new CategoryEntity
        {
            Id = Guid.NewGuid(),
            Name = category.Name,
            Description = category.Description
        };

        await _context.Categories.AddAsync(categoryEntity);
        await _context.SaveChangesAsync();

        return categoryEntity.Id;
    }

    public async Task<Guid> DeleteAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        await _context.Categories
            .Where(c => c.Id == categoryId)
            .ExecuteDeleteAsync();

        return categoryId;
    }

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var categoryEntities = await _context.Categories
            .AsNoTracking()
            .ToListAsync();
        
        var categoryEntitiesDto = _mapper.Map<List<Category>>(categoryEntities);
        
        return categoryEntitiesDto;
    }

    public async Task<Category> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        var categoryEntity = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == categoryId);
        
        var categoryEntityDto = _mapper.Map<Category>(categoryEntity);
        
        return categoryEntityDto;
    }

    public async Task<List<Good>> GetGoodsByIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        var goodEntities = await _context.Goods
            .Where(g => g.CategoryId == categoryId)
            .ToListAsync();
        
        var goodEntitiesDto = _mapper.Map<List<Good>>(goodEntities);

        return goodEntitiesDto;
    }

    public async Task<Guid> UpdateAsync(Category category, CancellationToken cancellationToken = default)
    {
        await _context.Categories
            .Where(c => c.Id == category.Id)
            .ExecuteUpdateAsync(cUpdate => cUpdate
                .SetProperty(c => c.Name, category.Name)
                .SetProperty(c => c.Description, category.Description));
        
        return category.Id;
    }
}