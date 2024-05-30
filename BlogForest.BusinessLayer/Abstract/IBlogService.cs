using BlogForest.EntityLayer.Concrete;

namespace BlogForest.BusinessLayer.Abstract;

public interface IBlogService : IGenericService<Blog>
{
    public List<Blog> TGetBlogsWithCategoryAndUser();
    public List<Blog> TGetLastTwoBlogByAppUser(int id);
    public List<Blog> TGetBlogsByAppUserId(int id);
    public void TIncreaseBlogViewCount(int id);
}