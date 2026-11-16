using Npgsql;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Domain.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories {get; set;}
    public DbSet<Product> Products {get; set;}
}
