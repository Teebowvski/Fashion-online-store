using Fashion.Data.Migrations;
using Fashion.Models;
using System.Collections.Generic;
using Product = Fashion.Models.Product;

namespace Fashion.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
        public string CurrentCategory { get; set; }
        public IEnumerable<Product> ProductDetails { get; set; }
    }
}
