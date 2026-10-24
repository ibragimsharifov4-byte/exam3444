using Npgsql;
using Application.Data;

namespace Application.Services;

public class SqlService
{
    public void GetProductsWithCategory()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select p.name, p.price, p.quantity, c.name from products p join categories c on c.id = p.category_id";
        using var cmd = new NpgsqlCommand(query, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader.GetString(0)} | " +
                $"{reader.GetDecimal(1)} | " +
                $"{reader.GetInt32(2)} | " +
                $"{reader.GetString(3)}");
        }
    }

    public void GetCategorySummary()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = 
        "select c.name, COUNT(p.id) AS product_count, COALESCE(SUM(p.quantity * p.price), 0) AS stock_value FROM categories c LEFT JOIN products p ON c.id = p.category_id GROUP BY c.id, c.name ORDER BY c.name;";
        using var cmd = new NpgsqlCommand(query, conn);
        using var reader = cmd.ExecuteReader();
        Console.WriteLine("Category summary:");
        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["name"]} — " +
                $"{reader["product_count"]} product(s) — " +
                $"stock value: " +
                $"{Convert.ToDecimal(reader["stock_value"]):F2}"
            );
        }
    }
}
