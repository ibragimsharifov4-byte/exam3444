using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger) : ControllerBase
{
    private readonly ICategoryService _service = categoryService;
    private readonly ILogger<CategoryController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<CategoryDto>>> GetAllCategories()
    {
        _logger.LogInformation("Geting the categories");
        return await _service.GetAllCategories();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CategoryDto>> GetCategory(int id)
    {
        _logger.LogInformation("Get category by id");
        return await _service.GetCategory(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategory(CategoryDto category)
    {
        _logger.LogInformation("Adding the category");
        return await _service.AddCategory(category);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        _logger.LogInformation("Delete the category");
        return await _service.DeleteCategory(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCategory(CategoryDto category)
    {
        _logger.LogInformation("Update the category");
        return await _service.UpdateCategory(category);
    }
}
