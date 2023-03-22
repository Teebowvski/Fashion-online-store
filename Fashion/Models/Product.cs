using System.Collections.Generic;

namespace Fashion.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ImageUrl { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public double Price { get; set; }
        public bool IsPreferred { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        
       
        public int SubSubCategoryId { get; set; }
        public virtual SubSubCategory SubSubCategory { get; set; }
       

    }
}
