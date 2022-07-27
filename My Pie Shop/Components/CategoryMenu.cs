﻿using Microsoft.AspNetCore.Mvc;
using My_Pie_Shop.Models;

namespace My_Pie_Shop.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // Action method for the categories
        public IViewComponentResult Invoke()
        {
            var categoryItem = this.categoryRepository.AllCategories;
            return View(categoryItem);
        }
    }
}