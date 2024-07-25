using DreemDay_Core.DTOs.CategoryDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Iservice;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepos _repos;
        public CategoryService (ICategoryRepos repos)
        {
            _repos = repos;
        }
        public async Task CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = new Category();

            category.Title = createCategoryDto.Title;
            category.Description = createCategoryDto.Description;
            category.CreationDate = DateTime.Now;
             await _repos.CreateCategory(category);
            var id = await _repos.CreateCategory(category);
            if (id == 0)
                throw new Exception("Failed To Create Category");
        }

        public async Task DeleteCategory(int id)
        {
            await _repos.DeleteCategory(id);
        }

        public async Task<List<CategoryCardDto>> GetAllCategories()
        {
            return await _repos.GetAllCategories();
        }

        public async Task<CategoryByIdDto> GetById(int id)
        {
            return await _repos.GetById(id);
        }

        public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _repos.UpdateCategory(updateCategoryDto);
        }
    }
}
