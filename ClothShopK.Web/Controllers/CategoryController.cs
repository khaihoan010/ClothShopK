using ClothShopK.Entities;
using ClothShopK.Service;
using ClothShopK.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothShopK.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesService categoryService = new CategoriesService();

        [HttpGet]
        public ActionResult Index()
        {
            //var categories = categoryService.GetCategories();

            return View();
        }

        public ActionResult CategoryTable(string search)
        {
            CategorySearchViewModel model = new CategorySearchViewModel();
            model.Categories = categoryService.GetCategories();
            if (!string.IsNullOrEmpty(search))
            {
                model.SearchTerm = search;
                model.Categories = model.Categories.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(model);
            //model.SearchTerm = search;

            //pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            //var totalRecords = CategoriesService.Instance.GetCategoriesCount(search);
            //model.Categories = categoryService.GetCategories();

            //if (!string.IsNullOrEmpty(search))
            //{
            //    //model.Pager = new Pager(totalRecords, pageNo, 3);
            //    model.SearchTerm = search;
            //   model.Categories = model.Categories.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            //    //model.Pager = new Pager(totalRecords, pageNo, 3);

            //    //return PartialView("_CategoryTable", model);

            //}
            //return PartialView("CategoryTable", model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            NewCategoryViewModel model = new NewCategoryViewModel();
           // model.AvailableCategories = categoryService.GetCategories();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            var newCategory = new Category();
            newCategory.Name = model.Name;
            newCategory.Description = model.Description;
            newCategory.ImageURL = model.ImageURL;
            newCategory.isFeatured = model.isFeatured;

            categoryService.SaveCategory(newCategory);
            //if (ModelState.IsValid)
            //{
                
            //    //CategoriesService.Instance.SaveCategory(newCategory);

               
            //}
            return RedirectToAction("CategoryTable");
            //else
            //{
            //    return new HttpStatusCodeResult(500);
            //}
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditCategoryViewModel model = new EditCategoryViewModel();
            var category = categoryService.GetCategory(ID);
            model.ID = category.ID;
            model.Name = category.Name;
            model.Description = category.Description;
            model.ImageURL = category.ImageURL;
            model.isFeatured = category.isFeatured;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            var existingCategory = categoryService.GetCategory(model.ID);
            existingCategory.Name = model.Name;
            existingCategory.Description = model.Description;
            existingCategory.ImageURL = model.ImageURL;
            existingCategory.isFeatured = model.isFeatured;
            categoryService.UpdateCategory(existingCategory);
            return RedirectToAction("CategoryTable");
        }

       
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            categoryService.DeleteCategory(ID);
            return RedirectToAction("CategoryTable");
            
        }

    }
}