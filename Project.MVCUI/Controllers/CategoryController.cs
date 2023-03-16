using Project.BLL.RepositoryPattern.ConcRep;
using Project.ENTITIES.Models;
using Project.MVCUI.Models;
using Project.ViewModels.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class CategoryController : Controller
    {

        CategoryRepository _cRep;

        public CategoryController()
        {
            _cRep = new CategoryRepository();
        }




        // GET: Category
        public ActionResult ListCategories()
        {
            List<CategoryVM> categories = _cRep.Select(x => new CategoryVM
            {
                CategoryName = x.CategoryName,
                ID = x.ID,
                Description = x.Description,
                Status = x.Status.ToString()
            }).Where(x => x.Status !="Deleted").ToList();

            CategoryListPageVM cpvm = new CategoryListPageVM
            {
                Categories = categories
            };

            return View(cpvm);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory([Bind(Prefix ="Category")]CategoryVM item)
        {
            Category c = new Category
            {
                CategoryName = item.CategoryName,
                Description = item.Description
            };


            _cRep.Add(c);

            return RedirectToAction("ListCategories");
        }

        public ActionResult UpdateCategory(int id)
        {
            Category selected = _cRep.Find(id);

            AddUpdateCategoryPageVM auvm = new AddUpdateCategoryPageVM
            {
                Category = new CategoryVM 
                { 
                    ID = selected.ID,
                    CategoryName = selected.CategoryName,
                    Description = selected.Description
                
                }
            };


            return View(auvm);

        }


        [HttpPost]
        public ActionResult UpdateCategory(CategoryVM category)
        {
            Category toBeUpdated = _cRep.Find(category.ID); 
            toBeUpdated.CategoryName = category.CategoryName;   
            toBeUpdated.Description = category.Description;
            _cRep.Update(toBeUpdated);
            return RedirectToAction("ListCategories");
        }


        public ActionResult DeleteCategory(int id)
        {
            _cRep.Delete(_cRep.Find(id));
            return RedirectToAction("ListCategories");

        }

    }
}