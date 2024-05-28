using BlogForest.BusinessLayer.Abstract;
using BlogForest.DataAccessLayer.Abstract;
using BlogForest.EntityLayer.Concrete;

namespace BlogForest.BusinessLayer.Concrete;

public class AppUserManager : IAppUserService
{
    private readonly IAppUserDal appUser;

    public AppUserManager(IAppUserDal appUser)
    {
        this.appUser = appUser;
    }

    public void TInsert(AppUser entity)
    {
        appUser.Insert(entity);
    }

    public void TUpdate(AppUser entity)
    {
        appUser.Update(entity);
    }

    public void TDelete(int id)
    {
        appUser.Delete(id);
    }

    public AppUser TGetById(int id)
    {
        return appUser.GetById(id);
    }

    public List<AppUser> TGetListAll()
    {
        return appUser.GetListAll();
    }

    public AppUser TGetAppUserDetail(int id)
    {
        return appUser.GetAppUserDetail(id);
    }
}