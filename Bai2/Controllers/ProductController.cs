using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bai2.Common;
using Bai2.Models;
using Bai2.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bai2.Controllers
{
    public class ProductController : Controller
    {
        private readonly Appcontext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(Appcontext appDbContext,IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            var products = _appDbContext.Products.Include(p => p.Category).ToList();

            return View(products);
        }
        public IActionResult Create()
        {
            ProductViewmodel productViewmodel = new ProductViewmodel()
            {
                Product = new Product(),
                CategoryeSelectList=_appDbContext.Categories.Select(item =>new SelectListItem
                {
                    Text=item.CategoryName,
                    Value= item.Id.ToString()
                })
            };
            return View(productViewmodel);
        }
        [HttpPost]
        public IActionResult Create(ProductViewmodel productViewmodel)
        {
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;
            string upload = webRootPath + CommonDefault.ImagePath;
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(files[0].FileName);

            using (var fileStrem = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStrem);
            }
            productViewmodel.Product.ImageUrl = fileName + extension;
            _appDbContext.Products.Add(productViewmodel.Product);
            _appDbContext.SaveChanges();
       
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
            {
            ProductViewmodel productViewmodel = new ProductViewmodel()
            {
                Product = _appDbContext.Products.Find(id),
                CategoryeSelectList = _appDbContext.Categories.Select(item => new SelectListItem
                {
                    Text = item.CategoryName,
                    Value = item.Id.ToString()
                })
            };

            return View(productViewmodel);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewmodel productViewmodel)
        {
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;

            var objProduct = _appDbContext.Products.AsNoTracking().FirstOrDefault(pro => pro.Id == productViewmodel.Product.Id);

            if (files.Count > 0)
            {
                string upload = webRootPath + CommonDefault.ImagePath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                productViewmodel.Product.ImageUrl = fileName + extension;
            }
            else
            {
                productViewmodel.Product.ImageUrl = objProduct.ImageUrl;
            }

            _appDbContext.Products.Update(productViewmodel.Product);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
