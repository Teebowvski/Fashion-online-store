using Fashion.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace Fashion.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            if (!context.Brands.Any())
            {
                context.AddRange(new List<Brand>
                {
                    new Brand {Name="Nike"},
                     new Brand {Name="Puma"},
                      new Brand {Name="Shein"},
                       new Brand {Name="BooHoo"}
                });
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                context.AddRange(new List<Category>
                {
                    new Category() {Name ="New Arrivals"},
                    new Category() {Name ="Men"},
                    new Category() {Name ="Women"},
                    new Category() {Name ="Unisex"},
                    new Category() {Name ="Kids"},
                    new Category() {Name ="Accessories"}
                });
                context.SaveChanges();
            }
            if (!context.SubCategories.Any())
            {
                context.AddRange(new List<SubCategory>
                {
                    new SubCategory() {SubCatName="New Arrivals", CategoryId=1},
                    new SubCategory() {SubCatName="Formal Wear", CategoryId=2},

                    new SubCategory() {SubCatName="Tops", CategoryId=2 },
                    new SubCategory() {SubCatName="Bottoms", CategoryId=2},
                    new SubCategory() {SubCatName="ShoeWear", CategoryId=2},
                    new SubCategory() {SubCatName="Men's Accessories", CategoryId=2},


                    new SubCategory() {SubCatName=" Formal Wear",  CategoryId=3 },
                    new SubCategory() {SubCatName="Tops", CategoryId=3 },
                    new SubCategory() {SubCatName="Bottoms",CategoryId=3},
                    new SubCategory() {SubCatName="ShoeWear",CategoryId=3},
                    new SubCategory() {SubCatName="Womens's Accessories",CategoryId=3},

                     new SubCategory() {SubCatName="Tops",CategoryId=5},
                    new SubCategory() {SubCatName="Bottoms",CategoryId=5},

                    new SubCategory() {SubCatName="Shoes",CategoryId=5},

                     new SubCategory() {SubCatName=" Accessories", CategoryId=4}


                });
                context.SaveChanges();
            }

            if (!context.SubSubCategories.Any())
            {
                context.AddRange(new List<SubSubCategory>
                {
                     new SubSubCategory () {SubSubCatName="Jackets", SubCategoryID=3 },
                     new SubSubCategory () {SubSubCatName="Cardigan", SubCategoryID=3},
                     new SubSubCategory () {SubSubCatName="Sweaters", SubCategoryID=3},
                     new SubSubCategory () {SubSubCatName="Hoodie", SubCategoryID=3},
                     new SubSubCategory () {SubSubCatName="Shirts", SubCategoryID=3},
                     new SubSubCategory () {SubSubCatName="SweatShirts", SubCategoryID=3},
                     new SubSubCategory () {SubSubCatName="Vests", SubCategoryID=3},


                     new SubSubCategory () {SubSubCatName="Denim Pants", SubCategoryID=4},
                     new SubSubCategory () {SubSubCatName="Pants", SubCategoryID=4},
                     new SubSubCategory () {SubSubCatName="Shorts", SubCategoryID=4},
                     new SubSubCategory () {SubSubCatName="SweatPants", SubCategoryID=4},
                     new SubSubCategory () {SubSubCatName="Cargo Pants", SubCategoryID=4},




                     new SubSubCategory (){SubSubCatName="Formal Shoes", SubCategoryID=5},
                     new SubSubCategory {SubSubCatName="Sneakers", SubCategoryID=5},
                     new SubSubCategory {SubSubCatName="Trainers", SubCategoryID=5},


                     new SubSubCategory {SubSubCatName="Suits", SubCategoryID=1},
                     new SubSubCategory {SubSubCatName="Tuxedos", SubCategoryID=1},


                     new SubSubCategory {SubSubCatName="Bags", SubCategoryID=6},
                     new SubSubCategory {SubSubCatName="Belts", SubCategoryID=6},
                     new SubSubCategory {SubSubCatName="Boxers", SubCategoryID=6},
                     new SubSubCategory {SubSubCatName="HeadWear", SubCategoryID=6},
                     new SubSubCategory {SubSubCatName="Wallet", SubCategoryID=6},
                     new SubSubCategory {SubSubCatName="Glasses", SubCategoryID=6},
                     new SubSubCategory {SubSubCatName="Watches", SubCategoryID=6},

                      new SubSubCategory{SubSubCatName="Bags", SubCategoryID=15},



                       new SubSubCategory () {SubSubCatName="Jackets" , SubCategoryID=8 },
                     new SubSubCategory () {SubSubCatName="Cardigan", SubCategoryID=8},
                     new SubSubCategory () {SubSubCatName="Sweaters", SubCategoryID=8},
                     new SubSubCategory () {SubSubCatName="Hoodie", SubCategoryID=8},
                     new SubSubCategory () {SubSubCatName="Shirts", SubCategoryID=8},
                     new SubSubCategory () {SubSubCatName="SweatShirts", SubCategoryID=8},
                     new SubSubCategory () {SubSubCatName="Vests", SubCategoryID=8},
                      new SubSubCategory () {SubSubCatName="Crop Top", SubCategoryID=8},
                      new SubSubCategory () {SubSubCatName="Tank Top", SubCategoryID=8},
                     new SubSubCategory () {SubSubCatName="Dress", SubCategoryID=8},
                      new SubSubCategory () {SubSubCatName="Overalls", SubCategoryID=8},
                       new SubSubCategory () {SubSubCatName="Denim Pants", SubCategoryID=9},
                         new SubSubCategory () {SubSubCatName="Leggings", SubCategoryID=9},
                     new SubSubCategory () {SubSubCatName="Skirts", SubCategoryID=9},
                      new SubSubCategory () {SubSubCatName="Shorts", SubCategoryID=9},
                       new SubSubCategory () {SubSubCatName="SweatPants", SubCategoryID=9},
                       new SubSubCategory {SubSubCatName="Suits", SubCategoryID=7},
                       new SubSubCategory {SubSubCatName="Belts", SubCategoryID=11},
                       new SubSubCategory {SubSubCatName="Underwear", SubCategoryID=11},

                       new SubSubCategory () {SubSubCatName="Heels", SubCategoryID=10},
                         new SubSubCategory (){SubSubCatName="Formal Shoes", SubCategoryID=10},
                     new SubSubCategory {SubSubCatName="Sneakers", SubCategoryID=10},
                     new SubSubCategory {SubSubCatName="Trainers", SubCategoryID=10},


                     new SubSubCategory {SubSubCatName="Shirts", SubCategoryID=12},
                     new SubSubCategory {SubSubCatName="Shorts", SubCategoryID=13},













                });
                context.SaveChanges();
            }



        

            if (!context.Products.Any())
            {
                context.AddRange(new List<Product>
                {
                    new Product() {Name = "Airmax", Description="",LongDescription="", Price= 700, ImageUrl="",ImageUrl1="",ImageUrl2="",ImageUrl3="",  SubSubCategoryId= 21, BrandId=1  },
                    new Product() {Name = "SweatShirt", Description="",LongDescription="", Price= 700, ImageUrl="",ImageUrl1="",ImageUrl2="",ImageUrl3="",  SubSubCategoryId=5, BrandId=2 },
                    new Product() {Name = "White Tee", Description="",LongDescription="", Price= 700, ImageUrl=""  ,ImageUrl1="",ImageUrl2="",ImageUrl3="",SubSubCategoryId=36, BrandId=4 },
                    new Product() {Name = "CropTop", Description="",LongDescription="", Price= 700, ImageUrl="",ImageUrl1="",ImageUrl2="",ImageUrl3="",SubSubCategoryId=12, BrandId=3 },

                });
                context.SaveChanges();
            }





        }
    }
}