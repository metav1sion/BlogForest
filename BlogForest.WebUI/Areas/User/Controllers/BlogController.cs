using AutoMapper;
using BlogForest.BusinessLayer.Abstract;
using BlogForest.DtoLayer.BlogDtos;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IBlogService _iBlogService;
        private readonly IMapper _mapper;

        public BlogController(UserManager<AppUser> userManager, IBlogService iBlogService, IMapper mapper)
        {
            _userManager = userManager;
            _iBlogService = iBlogService;
            _mapper = mapper;
        }

        public async Task<IActionResult> MyBlogList()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var blogList = _iBlogService.TGetBlogsByAppUserId(values.Id);
            return View(blogList);
        }

        [HttpGet]
        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p.AppUserId = values.Id;
            p.CreatedDate = DateTime.Now;
            p.ViewCount = 0;
            var blogValues = _mapper.Map<Blog>(p);
            _iBlogService.TInsert(blogValues);
            
            return RedirectToAction("Index","Default");
        }
    }
}
