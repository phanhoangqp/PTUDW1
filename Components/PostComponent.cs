using Microsoft.AspNetCore.Mvc;
using PTUDW1.Models;
namespace PTUDW1.Components
{
    [ViewComponent(Name = "Post")]
    public class PostComponent : ViewComponent
    {
        private readonly DataContext _context;
        public PostComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from m in _context.Posts
                              where (m.IsActive == true) && (m.Status == 1)
                              orderby m.PostID descending
                              select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}