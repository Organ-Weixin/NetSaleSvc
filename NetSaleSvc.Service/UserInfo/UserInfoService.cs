using NetSaleSvc.Entity.Repository;
using NetSaleSvc.Entity.Models;
using System.Threading.Tasks;
using NetSaleSvc.Entity.Repository.Impl;

namespace NetSaleSvc.Service
{
    public class UserInfoService
    {
        #region ctor
        private readonly IRepository<UserInfoEntity> _userInfoRepository;

        public UserInfoService()
        {
            //TODO: 移除内部依赖
            _userInfoRepository = new Repository<UserInfoEntity>();
        }
        #endregion

        /// <summary>
        /// 根据用户名和密码获取用户信息（同步）
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public UserInfoEntity GetUserInfoByUserCredential(string Username, string Password)
        {
            return _userInfoRepository.Query.Where(
                x => x.UserName == Username && x.Password == Password && x.IsDel == 0).SingleOrDefault();
        }

        /// <summary>
        /// 根据用户名和密码获取用户信息（异步）
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public async Task<UserInfoEntity> GetUserInfoByUserCredentialAsync(string Username, string Password)
        {
            return await _userInfoRepository.Query.Where(
                x => x.UserName == Username && x.Password == Password && x.IsDel == 0).SingleOrDefaultAsync();
        }
    }
}
