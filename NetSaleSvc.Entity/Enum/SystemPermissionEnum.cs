using System.ComponentModel;

namespace NetSaleSvc.Entity.Enum
{
    /// <summary>
    /// 系统权限枚举
    /// </summary>
    public enum SystemPermissionEnum : byte
    {
        [Description("用户管理")]
        User = 1,

        [Description("角色管理")]
        Role = 2,

        [Description("订单管理")]
        Order = 3
    }
}
