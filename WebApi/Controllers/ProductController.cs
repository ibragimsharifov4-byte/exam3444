using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Application.Responses;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    private IProductService _service = productService;

    [HttpGet]
    public async Task<ApiResponse<List<Product>>> GetAllProducts()
    {
        return await _service.GetAllProducts();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Product?>> GetProduct(int id)
    {
        return await _service.GetProduct(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(Product p)
    {
        return await _service.AddProduct(p);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        return await _service.DeleteProduct(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateProduct(Product p)
    {
        return await _service.UpdateProduct(p);
    }
}
