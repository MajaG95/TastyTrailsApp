using Domain.Entities;
using Domain.Repositories;

namespace DataAccess.RepositoryImpementation
{
    public class UserInfoRepository : Repository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(TastyTrailsContext context) : base(context)
        {
        }
    }
}
