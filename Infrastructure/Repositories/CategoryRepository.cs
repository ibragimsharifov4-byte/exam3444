
using Domain.Data;
using Dapper;
using Domain.interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CategoryRepository(AppDbContext database) : ICategoryRepository
{
    private AppDbContext _context = database;

    public async Task<List<Category>> GetAllCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategory(int id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if(category != null)
        {
            return category!;
        }
        return null;
    }

    public async Task<bool> AddCategory(Category c)
    {
        var res = _context.Categories.Add(c);
        var result = _context.SaveChanges();
        return result > 0;
    }

    public async Task<bool> UpdateCategory(Category c)
    {
        var res = await _context.Categories.FirstOrDefaultAsync(x => x.Id == c.Id);
        if(res != null)
        {
            res.Name = c.Name;
        }
        var ress = await _context.SaveChangesAsync();
        return ress > 0;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        var res = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if(res != null)
        {
            _context.Remove(res);
        }
        var ress = await _context.SaveChangesAsync();
        return ress > 0;
    }
}