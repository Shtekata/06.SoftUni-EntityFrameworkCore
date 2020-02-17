using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetStore.Data;
using PetStore.Services;
using PetStore.Services.Models.Category;
using PetStore.Web.ViewModels.Category;

namespace PetStore.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var categoryServiceModel = new CreateCategoryServiceModel()
            {
                Name = model.Name,
                Description = model.Description
            };

            categoryService.Create(categoryServiceModel);

            return RedirectToAction("All", "Categories"); 
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = categoryService.GetById(id);

            if (category.Name == null)
            {
                return BadRequest();
            }

            if (category.Description == null) { category.Description = "No description."; }

            var viewModel = new CategotyDetailsViewModel() { Id = category.Id.Value, Name = category.Name, Description = category.Description };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = categoryService.GetById(id);

            if (category.Name == null)
            {
                return BadRequest();
            }

            var viewModel = new CategotyDetailsViewModel() { Name = category.Name, Description = category.Description };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditInputModel model)
        {
            if (!categoryService.Exists(model.Id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var ecsm = new EditCategoryServiceModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            categoryService.Edit(ecsm);

            return RedirectToAction("Details", "Categories", new { id = ecsm.Id });
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = categoryService
                .GetById(id);

            if (category.Name == null)
            {
                return BadRequest();
            }

            if (category.Description == null)
            {
                category.Description = "No description.";
            }

            var cdvm = new CategotyDetailsViewModel()
            {
                Id = category.Id.Value,
                Name = category.Name,
                Description = category.Description
            };

            return View(cdvm);
        }

        [HttpPost]
        public IActionResult Delete(CategotyDetailsViewModel model)
        {
            var success = categoryService.Delete(model.Id);

            if (!success)
            {
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("All", "Categories");
        }

        public IActionResult All()
        {
            var categories = categoryService.All()
                .Select(x => new CategoryListingViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToArray();

            return View(categories);
        }

    }
}