﻿using BlogForest.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogListComponentPartial : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _BlogListComponentPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.TGetBlogsWithCategoryAndUser();
            return View(values);
        }
    }
}

//field classın içine yazılır, değişken metotun içine yazılır, property get ve set metotuna sahip field. kapsülleme çalış.