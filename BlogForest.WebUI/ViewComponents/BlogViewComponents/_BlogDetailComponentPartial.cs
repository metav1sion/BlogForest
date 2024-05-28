using BlogForest.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailComponentPartial : ViewComponent
    {
        private readonly IBlogService blogService;

        public _BlogDetailComponentPartial(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var value = blogService.TGetById(id);
            return View(value);
        }
    }
}
