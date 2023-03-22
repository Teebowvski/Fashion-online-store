using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fashion.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        
       public int SubCategoryId { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
       

    }
}
