using Application.Data;
using Domain.Models;
using Npgsql;

namespace Application.Repositories;

public class CategoryRepository
{
    public List<Category> GetAllCategories()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select id, name from categories";
        var cmd = new NpgsqlCommand(query, conn);
        List<Category> categories = new List<Category>();
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var category = new Category()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            };
            categories.Add(category);
        }
        return categories;
    }

    public Category GetCategory(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select id, name from categories where id = @id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", id);
        var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            var category = new Category()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            };
            return category;
        }
        else
        {
            return null;
        }
    }

    public int AddCategory(Category c)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "insert into categories(name) values (@name) returning id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@name", c.Name);
        int id = (int)cmd.ExecuteScalar()!;
        return id;
    }

    public bool UpdateCategory(Category c)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "update categories set name = @name where id = @id";
        using var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", c.Id);
        cmd.Parameters.AddWithValue("@name", c.Name);
        int rows = cmd.ExecuteNonQuery();
        return rows > 0;
    }

    public bool DeleteCategory(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "delete from categories where id = @id";
        using var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", id);
        int rows = cmd.ExecuteNonQuery();
        return rows > 0;
    }
}