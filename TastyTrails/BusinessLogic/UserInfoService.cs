using DataAccess.UnitOfWork;
using Domain.Entities;

namespace BusinessLogic
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UserInfo> GetUserInfoByEmailAddress(string email)
        {
            try
            {
               var userInfo = await _unitOfWork.UserInfoRepository.Find(x => x.Email == email);
                if (userInfo == null)
                {

                }
                return userInfo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserInfo> GetUserInfoById(int userId)
        {
            return await _unitOfWork.UserInfoRepository.GetById(userId);
        }
    }
}
