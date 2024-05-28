using DreemDay_Core.DTOs.CategoryDTOs;
using DreemDay_Core.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class CategoryService : ICategoryService
    {
        public Task CreateCategory(CreateCategoryDto createCategoryDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryCardDto>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryByIdDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
