using DreemDay_Core.Context;
using DreemDay_Core.DTOs.CategoryDTOs;
using DreemDay_Core.IRepository;
using DreemDay_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
            Log.Debug("Debugging CreateCategory Has been Finised Successfully");

            return category.Id;
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null) return;
            Log.Information("Category Is Exists");

            category.IsDeleted = true;
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging DeleteCategory Has been Finised Successfully");

        }

        public async Task<List<CategoryCardDto>> GetAllCategories()
        {
          var categores =    await _dbContext.Categories
                .Where(x => !x.IsDeleted)
                .Select( category => new CategoryCardDto
                {
                    Id = category.Id,
                    Title = category.Title,

                }).ToListAsync();
            Log.Debug("Debugging GetAllCategories Has been Finised Successfully");
            return categores;
        }

        public async Task<CategoryByIdDto> GetById(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            return null;
            Log.Information("category Is Exists");

            var C = new CategoryByIdDto
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
                CreationDate = category.CreationDate.ToString(),
                ModifiedDate = category.ModifiedDate.ToString(),
                IsDeleted = category.IsDeleted,

            };
            Log.Debug("Debugging GetById Has been Finised Successfully");
            return C;

        }

        public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _dbContext.Categories.FindAsync(updateCategoryDto.Id);
            if (category == null) 
                return;
            Log.Information("Categories Is Exists");

            category.Title = updateCategoryDto.Title;
            category.Description = updateCategoryDto.Description;
            category.ModifiedDate= DateTime.Now;
            category.IsDeleted = updateCategoryDto.IsDeleted;
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
            Log.Debug("Debugging UpdateCategory Has been Finised Successfully");

        }
    }
}
