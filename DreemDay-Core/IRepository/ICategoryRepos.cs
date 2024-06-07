using DreemDay_Core.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.IRepository
{
    public interface ICategoryRepos
    {
        Task<List<CategoryCardDto>> GetAllCategories();
        Task<CategoryByIdDto> GetById(int id);
        Task<int> CreateCategory(CreateCategoryDto createCategoryDto);
        Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategory(int id);
    }
}
