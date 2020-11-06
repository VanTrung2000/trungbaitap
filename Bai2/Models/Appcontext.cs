using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai2.Models
{
    public class Appcontext : DbContext
    {
        public Appcontext(DbContextOptions<Appcontext> dbContextOptions) : base(dbContextOptions){
        }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Tag> Tags { set; get; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, CategoryName = "Gạo" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, CategoryName = "Thịt" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, CategoryName = "Hoa Quả" });
          
            modelBuilder.Entity<Product>().HasData(new Product
            
            {
                Id = 1,
                Name = "Gạo Lứt Huế",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Price = 15.5M,
                Stock = 500,
                ImageUrl = "https://cf.shopee.vn/file/92704e5d399d6852fd0eb96f37399459",
                CategoryId = 1
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Thịt ba chỉ Huế",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Price = 15.5M,
                Stock = 500,
                ImageUrl = "https://daotaobeptruong.vn/wp-content/uploads/2019/11/mon-ngon-tu-thit-ba-chi.jpg",
                CategoryId = 2
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Táo Trung Quốc",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Price = 15.5M,
                Stock = 500,
                ImageUrl = "https://icdn.dantri.com.vn/zoom/1200_630/2017/20170920172246-tao-tay-1506037544989.jpg",
                CategoryId = 3
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Mít Sáy Huế",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Price = 15.5M,
                Stock = 500,
                ImageUrl = "https://cdn.muabannhanh.com/asset/frontend/img/gallery/2019/06/26/5d133b04e12ab_1561541380.jpg",
                CategoryId = 3
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Chả Huế",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Price = 15.5M,
                Stock = 500,
                ImageUrl = "https://thucthan.com/media/2019/08/cha-que/cha-que.jpg",
                CategoryId = 2
            });
            modelBuilder.Entity<ProductTag>().HasKey(protag =>new { protag.ProductId, protag.TagId });
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                Id = 1,
                Name = "Re"
            });
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                Id = 2,
                Name = "Ngon"
            });
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                Id = 3,
                Name = "Bo Khoe"
            });

        }
    }
}
