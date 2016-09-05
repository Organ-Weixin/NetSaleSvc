using NetSaleSvc.Entity.Models;
using NetSaleSvc.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetSaleSvc.Admin.Models.User
{
    public static class ModelMapper
    {
        /// <summary>
        /// 转为Dynatable内容
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static dynamic ToDynatableItem(this SystemUserEntity user)
        {
            return new
            {
                id = user.Id,
                username = user.Username,
                realname = user.RealName,
                cinemaname = user.CinemaName,
                rolename = user.RoleName
            };
        }

        /// <summary>
        /// model To Entity
        /// </summary>
        /// <param name="user"></param>
        /// <param name="model"></param>
        public static void MapFrom(this SystemUserEntity user, CreateUserViewModel model,
            CinemaEntity cinema, RoleEntity role)
        {
            user.Username = model.Username;
            user.Password = MD5Helper.MD5Encrypt(model.Password);
            user.CinemaCode = cinema.Code;
            user.CinemaName = cinema.Name;
            user.RealName = model.RealName;
            user.RoleId = model.RoleId;
            user.RoleName = role.Name;
        }

        /// <summary>
        /// entity to model
        /// </summary>
        /// <param name="model"></param>
        /// <param name="user"></param>
        public static void MapFrom(this UpdateUserViewModel model, SystemUserEntity user)
        {
            model.Id = user.Id;
            model.CinemaCode = user.CinemaCode;
            model.Username = user.Username;
            model.RealName = user.RealName;
            model.RoleId = user.RoleId;
        }
    }
}