using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fashion.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public string SubCatName { get; set; }
       
        [Display(Name = "Subcategory Description")]
        public string Description { get; set; }
        
        public int CategoryId { get; set; }
        public virtual Category Category{ get; set; }
        


    }
}
