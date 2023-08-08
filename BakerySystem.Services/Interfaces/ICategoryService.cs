﻿using BakerySystem.Data.Models;
using BakerySystem.Web.ViewModels.Category;

namespace BakerySystem.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategoryAsync();
    }
}
