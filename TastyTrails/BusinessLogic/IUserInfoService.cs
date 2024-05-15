using Domain.Entities;

namespace BusinessLogic
{
    public interface IUserInfoService
    {
        Task<UserInfo> GetUserInfoByEmailAddress(string email);
        Task<UserInfo> GetUserInfoById(int userId);
    }
}
