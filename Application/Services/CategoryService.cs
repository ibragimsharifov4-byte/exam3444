using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.interfaces;
using Domain.Models;

namespace Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private ICategoryRepository _repository = categoryRepository;
    public async Task<ApiResponse<bool>> AddCategory(Category c)
    {
        var res = await _repository.AddCategory(c);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Category added successfully!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Failed to add category", false);
    }

    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        var res = await _repository.DeleteCategory(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Category deleted successfully!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Failed to delete category", false);
    }

    public async Task<ApiResponse<List<Category>>> GetAllCategories()
    {
        var res = await _repository.GetAllCategories();
        return new ApiResponse<List<Category>>(HttpStatusCode.OK , "List of categories" , res);
    }

    public async Task<ApiResponse<Category?>> GetCategory(int id)
    {
        var res = await _repository.GetCategory(id);
        return res != null
        ? new ApiResponse<Category?>(HttpStatusCode.OK , "Category found", res)
        : new ApiResponse<Category?>(HttpStatusCode.NotFound , "Category not found", null);
    }

    public async Task<ApiResponse<bool>> UpdateCategory(Category c)
    {
        var res = await _repository.UpdateCategory(c);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Category updated successfully!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Failed to update category", false);
    }

}
