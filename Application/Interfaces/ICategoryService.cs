using Application.Responses;
using Domain.interfaces;
using Domain.Models;

namespace Application.Interfaces;


public interface ICategoryService
{
    Task<ApiResponse<List<Category>>> GetAllCategories();
    Task<ApiResponse<Category?>> GetCategory(int id);
    Task<ApiResponse<bool>> AddCategory(Category c);
    Task<ApiResponse<bool>> UpdateCategory(Category c);
    Task<ApiResponse<bool>> DeleteCategory(int id);
}
