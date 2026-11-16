
using Domain.Data;
using Dapper;
using Domain.Models;
using Domain.interfaces;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public class ProductRepository(AppDbContext database) : IProductRepository
{
    private AppDbContext _context = database;

    public async Task<List<Product>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetProduct(int id)
    {
        var res = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if(res != null)
        {
            return res;
        }
        return null;
    }

    public async Task<bool> AddProduct(Product p)
    {
        var res = _context.Products.Add(p);
        var ress = await _context.SaveChangesAsync();
        return ress > 0;
    }

    public async Task<bool> UpdateProduct(Product p)
    {
        var res = await _context.Products.FirstOrDefaultAsync(x => x.Id == p.Id);
        if(res != null)
        {
            res.Name = p.Name;
            res.Quantity = p.Quantity;
            res.Price = p.Price;
            res.CategoryId = p.CategoryId;
        }
        var ress = await _context.SaveChangesAsync();
        return ress > 0;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var res = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if(res != null)
        {
            _context.Remove(res);
        }
        var ress =  await _context.SaveChangesAsync();
        return ress > 0;
    }
}
