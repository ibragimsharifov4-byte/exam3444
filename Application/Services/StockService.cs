using Application.Data;
using Domain.Models;
using Npgsql;

namespace Application.Services;

public class StockService
{
    public void RegisterSale(int productId, int qty)
    {
        if(qty <= 0)
        {
            System.Console.WriteLine("Quantity must be greater than 0.");
        }
        using var conn = Database.Connection();
        conn.Open();
        var query = "SELECT quantity FROM products WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", productId);
        var product = new Product();
        var reader = cmd.ExecuteReader();
        if(!reader.Read())
        {
            System.Console.WriteLine("Product not found.");
        }
    }

    public void ReStock(int productId , int qty)
    {
        if(qty <= 0)
        {
            System.Console.WriteLine("Quantity must be greater than 0.");
        }
        using var conn = Database.Connection();
        conn.Open();
        var query = "SELECT quantity FROM products WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", productId);
        var product = new Product();
        var reader = cmd.ExecuteReader();
        if(!reader.Read())
        {
            System.Console.WriteLine("Product not found.");
        }
    }
}
