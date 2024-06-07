using DreemDay_Core.Context;
using DreemDay_Core.DTOs.CategoryDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Infra.Repository
{
    public class CategoryRepos : ICategoryRepos
    {
        private readonly DreemDayDbContext _dbContext;
        public CategoryRepos(DreemDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = new Category
            {
                Title = createCategoryDto.Title,
                Description = createCategoryDto.Description,
                CreationDate = DateTime.Now,

            };
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return category.Id;
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null) return;
            category.IsDeleted = true;
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CategoryCardDto>> GetAllCategories()
        {
            return await _dbContext.Categories
                .Where(x => !x.IsDeleted)
                .Select( category => new CategoryCardDto
                {
                    Id = category.Id,
                    Title = category.Title,

                }).ToListAsync();
        }

        public async Task<CategoryByIdDto> GetById(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null) return null;
            return new CategoryByIdDto
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
                CreationDate = category.CreationDate.ToString(),
                ModifiedDate = category.ModifiedDate.ToString(),
                IsDeleted = category.IsDeleted,

            };

        }

        public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _dbContext.Categories.FindAsync(updateCategoryDto.Id);
            if (category == null) return;
            category.Title = updateCategoryDto.Title;
            category.Description = updateCategoryDto.Description;
            category.ModifiedDate= DateTime.Now;
            category.IsDeleted = updateCategoryDto.IsDeleted;
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
