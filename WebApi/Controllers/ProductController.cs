using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService, ILogger<ProductController> logger) : ControllerBase
{
    private readonly IProductService _service = productService;
    private readonly ILogger<ProductController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<ProductDto>>> GetAllProducts()
    {
        _logger.LogInformation("Geting the products");
        return await _service.GetAllProducts();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<ProductDto>> GetProduct(int id)
    {
        _logger.LogInformation("Get product by id");
        return await _service.GetProduct(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(ProductDto product)
    {
        _logger.LogInformation("Adding the product");
        return await _service.AddProduct(product);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        _logger.LogInformation("Delete the product");
        return await _service.DeleteProduct(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateProduct(ProductDto product)
    {
        _logger.LogInformation("Update the product");
        return await _service.UpdateProduct(product);
    }
}
