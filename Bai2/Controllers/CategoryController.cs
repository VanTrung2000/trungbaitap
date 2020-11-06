using System.Collections.Generic;
using Bai2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bai2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Appcontext _appDbContext;

        public CategoryController(Appcontext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _appDbContext.Categories.Include(p => p.Products);

            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid) { 
            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
            }
            return View(category);
        }
        
        public IActionResult Edit(int? id)
        {
            if(id==null|| id == 0)
            {
                return NotFound();
            }
            var category = _appDbContext.Categories.Find(id);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _appDbContext.Categories.Update(category);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _appDbContext.Categories.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }
        [HttpPost]
            public IActionResult DeleteCategory(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }

                var category = _appDbContext.Categories.Find(id);
                if (category == null) return NotFound();

                _appDbContext.Categories.Remove(category);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index");

            }
        }
}


