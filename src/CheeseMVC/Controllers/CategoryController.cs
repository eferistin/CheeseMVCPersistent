using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        //// GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly CheeseDbContext context; // interact with objects stored in the database
        //The MVC framework will do the work of creating an instance of CheeseDbContext and passing it into our controller's constructor.

        public CategoryController( CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<CheeseCategory> cheeseCategories = context.Categories.ToList();
            return View(cheeseCategories);//returns a list of all CheeseCategory objects managed by CheeseDbContext
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if(ModelState.IsValid)
            {
                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = addCategoryViewModel.Name
                };
                context.Categories.Add(newCategory);
                context.SaveChanges();
                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }
    }
}
