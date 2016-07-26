namespace NetSaleSvc.Entity.Models
{
    public partial class UserCinemaViewEntity
    {
        /// <summary>
        /// 接入商所使用的账号
        /// </summary>
        public string RealUserName
        {
            get
            {
                return string.IsNullOrEmpty(UserName) ? DefaultUserName : UserName;
            }
        }

        /// <summary>
        /// 接入商所使用的密码
        /// </summary>
        public string RealPassword
        {
            get
            {
                return string.IsNullOrEmpty(Password) ? DefaultPassword : Password;
            }
        }
    }
}
