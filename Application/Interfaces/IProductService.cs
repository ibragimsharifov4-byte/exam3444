using Domain.Models;
using Application.Responses;
namespace Application.Interfaces;

public interface IProductService
{
    Task<ApiResponse<List<Product>>> GetAllProducts();
    Task<ApiResponse<Product?>> GetProduct(int id);
    Task<ApiResponse<bool>> AddProduct(Product p);
    Task<ApiResponse<bool>> UpdateProduct(Product p);
    Task<ApiResponse<bool>> DeleteProduct(int id);
}
