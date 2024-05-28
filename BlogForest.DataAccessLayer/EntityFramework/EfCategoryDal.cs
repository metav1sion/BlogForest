using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogForest.DataAccessLayer.Abstract;
using BlogForest.DataAccessLayer.Context;
using BlogForest.DataAccessLayer.Repositories;
using BlogForest.DtoLayer.CategoryDtos;
using BlogForest.EntityLayer.Concrete;

namespace BlogForest.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(BlogContext context) : base(context)
        {
        }

        public List<ResultCategoryWithCountDto> GetCategoriesWithCount()
        {
            BlogContext _blogContext = new BlogContext();

            var categoryBlogCounts = _blogContext.Categories.Select(c => new ResultCategoryWithCountDto
            {
                CategoryName = c.CategoryName,
                CategoryCount = c.Blogs.Count

            }).ToList();

            return categoryBlogCounts;
        }
    }
}

