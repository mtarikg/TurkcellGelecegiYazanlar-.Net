using nbaDemo.Entities;

namespace nbaDemo.Business.Abstracts
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
    }
}
