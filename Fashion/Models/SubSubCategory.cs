using System.Collections.Generic;

namespace Fashion.Models
{
    public class SubSubCategory
    { public int Id { get; set; }
        public string SubSubCatName { get; set; }
        
        public int SubCategoryID { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        
        public virtual List<Product> Products { get; set; }
    }
}
