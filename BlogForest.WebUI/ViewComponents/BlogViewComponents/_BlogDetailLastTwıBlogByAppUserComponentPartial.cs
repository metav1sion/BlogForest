using BlogForest.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailLastTwıBlogByAppUserComponentPartial : ViewComponent
    {
        private readonly IBlogService blogService;

        public _BlogDetailLastTwıBlogByAppUserComponentPartial(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = blogService.TGetLastTwoBlogByAppUser(id);
            return View(values);
        }
    }
}
