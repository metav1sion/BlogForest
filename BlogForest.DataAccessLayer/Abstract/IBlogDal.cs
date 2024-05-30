using BlogForest.EntityLayer.Concrete;

namespace BlogForest.DataAccessLayer.Abstract;

public interface IBlogDal : IGenericDal<Blog>
{
    List<Blog> GetBlogsWithCategoryAndUser();
    List<Blog> GetLastTwoBlogByAppUser(int id);
    List<Blog> GetBlogsByAppUserId(int id);
    void IncreaseBlogViewCount(int id);

}