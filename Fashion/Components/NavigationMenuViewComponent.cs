using Fashion.Data;
using Fashion.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fashion.Components
{
    public class NavigationMenuViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public NavigationMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            
            return View( _context.Categories.ToList());
        }
    }
}
