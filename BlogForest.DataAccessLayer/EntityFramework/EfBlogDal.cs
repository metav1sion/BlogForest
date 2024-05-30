using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogForest.DataAccessLayer.Abstract;
using BlogForest.DataAccessLayer.Context;
using BlogForest.DataAccessLayer.Repositories;
using BlogForest.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BlogForest.DataAccessLayer.EntityFramework
{
    public class EfBlogDal : GenericRepository<Blog>,IBlogDal
    {
        public EfBlogDal(BlogContext context) : base(context)
        {
        }

        public List<Blog> GetBlogsWithCategoryAndUser() // Include ile ilişkili tabloları çekmek için
        {
            var context = new BlogContext();
            var values = context.Blogs.Include(x => x.Category).Include(y => y.AppUser).ToList();
            return values;
        }

        public List<Blog> GetLastTwoBlogByAppUser(int id) // Kullanıcının son iki blogunu getirir
        {
            var context = new BlogContext();
            int appUserId = context.Blogs.Where(x => x.BlogId == id).Select(y => y.AppUserId).FirstOrDefault();
            var values = context.Blogs.Where(x => x.AppUserId == appUserId).OrderByDescending(y => y.BlogId).ToList().Take(2)
                .ToList();
            return values;

        }

        public List<Blog> GetBlogsByAppUserId(int id) // Kullanıcının bloglarını getirir
        {
            var context = new BlogContext();
            var values = context.Blogs.Where(x => x.AppUserId == id).Include(y=>y.Category).ToList();
            return values;
        }

        public void IncreaseBlogViewCount(int id) // Blogun görüntülenme sayısını arttırır
        {
            var context = new BlogContext();
            var value = context.Blogs.Where(x=>x.BlogId == id).FirstOrDefault();
            value.ViewCount += 1;
            context.Blogs.Update(value);
            context.SaveChanges();
        }
    }
}
