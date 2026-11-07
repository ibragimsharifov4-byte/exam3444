using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.interfaces;
using Domain.Models;

namespace Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private IProductRepository _repository = productRepository;
    public async Task<ApiResponse<bool>> AddProduct(Product p)
    {
        var res = await _repository.AddProduct(p);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Added!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Added!" , false);
    }

    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        var res = await _repository.DeleteProduct(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Deleted!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Deleted!" , false);
    }

    public async Task<ApiResponse<List<Product>>> GetAllProducts()
    {
        var res = await _repository.GetAllProducts();
        return new ApiResponse<List<Product>>(HttpStatusCode.OK, "Products retrieved successfully", res);
    }

    public async Task<ApiResponse<Product?>> GetProduct(int id)
    {
        var res = await _repository.GetProduct(id);
        return res != null
        ? new ApiResponse<Product?>(HttpStatusCode.OK, "Product retrieved successfully", res)
        : new ApiResponse<Product?>(HttpStatusCode.NotFound, "Product not found", null);
    }

    public async Task<ApiResponse<bool>> UpdateProduct(Product p)
    {
        var res = await _repository.UpdateProduct(p);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Product updated successfully", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Failed to update product", false);
    }
}   
