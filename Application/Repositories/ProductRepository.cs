using System.Runtime.InteropServices;
using Application.Data;
using Domain.Models;
using Npgsql;

namespace Application.Repositories;

public class ProductRepository
{
    public List<Product> GetAllProducts()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select id , name , price , quantity , category_id from products";
        var cmd = new NpgsqlCommand(query , conn);
        List<Product> products = new List<Product>{};
        var reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            var product = new Product()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetDecimal(2),
                Quantity = reader.GetInt32(3),
                CategoryId = reader.GetInt32(4)
            };
            products.Add(product);
        }
        return products;
    }

    public Product GetProduct(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select id , name , price , quantity , category_id from products where id = @id";
        var cmd = new NpgsqlCommand(query , conn);
        cmd.Parameters.AddWithValue("id" , id);
        var product = new Product();
        var reader = cmd.ExecuteReader();
        if(reader.Read())
        {
            product.Id = reader.GetInt32(0);
            product.Name = reader.GetString(1);
            product.Price = reader.GetDecimal(2);
            product.Quantity = reader.GetInt32(3);
            product.CategoryId = reader.GetInt32(4);
            return product;
        }
        else
        { 
            return null;
        }
    }
    public int AddProduct(Product p)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = 
        "insert into products(name , price , quantity , category_id) values (@name , @price , @quantity , @category_id)";
        var cmd = new NpgsqlCommand(query , conn);
        cmd.Parameters.AddWithValue("id" , p.Id);
        cmd.Parameters.AddWithValue("name" , p.Name);
        cmd.Parameters.AddWithValue("price" , p.Price);
        cmd.Parameters.AddWithValue("quantity" , p.Quantity);
        cmd.Parameters.AddWithValue("category_id" , p.CategoryId);
        var id = cmd.ExecuteNonQuery();
        return id;
    }
    public bool UpdateProduct(Product p)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = 
        "update products set name = @name, price = @price, category_id = @category_id where id = @id";
        using var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", p.Id);
        cmd.Parameters.AddWithValue("@name", p.Name);
        cmd.Parameters.AddWithValue("@price", p.Price);
        cmd.Parameters.AddWithValue("@category_id", p.CategoryId);
        int boolv = cmd.ExecuteNonQuery();
        return boolv > 0;
    }

    public bool DeleteProduct(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "delete from products where id = @id";
        using var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", id);
        int boolm = cmd.ExecuteNonQuery();
        return boolm > 0;
    }

    public void SearchProductByName(string name)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select id , name , price , quantity , category_id from products where name = @name";
        var cmd = new NpgsqlCommand(query , conn);
        cmd.Parameters.AddWithValue("name" , name);
        var reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            var product = new Product()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetDecimal(2),
                Quantity = reader.GetInt32(3),
                CategoryId = reader.GetInt32(4)
            };
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}, CategoryId: {product.CategoryId}");
        }
    }

    public decimal Filter(decimal maxPrice)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query =
        "select max(price) from products";
        var cmd = new NpgsqlCommand(query , conn);
        var reader = cmd.ExecuteReader();
        if(reader.Read())
        {
            return reader.GetDecimal(0);
        }
        return 0;
    }
    
}
