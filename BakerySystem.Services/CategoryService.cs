﻿namespace BakerySystem.Services
{
    using BakerySystem.Data.Models;
    using BakerySystem.Services.Interfaces;
    using BakerySystem.Web.Data;
    using BakerySystem.Web.ViewModels.Category;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    public class CategoryService : ICategoryService
    {
        private readonly BakeryDbContext dbContext;

        public CategoryService(BakeryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public async Task<IEnumerable<CategoryViewModel>> AllCategoryAsync()
        {
            IEnumerable<CategoryViewModel> allCategories = await dbContext
                .Categories
                .OrderBy(c => c.Name)
                .Select(c => new CategoryViewModel
                {
                
                    Id= c.Id,
                    Name = c.Name
                
                })
                .ToArrayAsync();

            return allCategories;

        }
    }

}


