using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService category) : ControllerBase
{
    private ICategoryService _service = category;

    [HttpGet]
    public async Task<ApiResponse<List<Category>>> GetAllCategories()
    {
        return await _service.GetAllCategories();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Category?>> GetCategory(int id)
    {
        return await _service.GetCategory(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategory(Category category1)
    {
        return await _service.AddCategory(category1);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        return await _service.DeleteCategory(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCategory(Category category1)
    {
        return await _service.UpdateCategory(category1);
    }
}
