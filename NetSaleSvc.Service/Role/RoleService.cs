using NetSaleSvc.Entity.Models;
using NetSaleSvc.Entity.Models.PageList;
using NetSaleSvc.Entity.Repository;
using NetSaleSvc.Entity.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSaleSvc.Service
{
    public class RoleService
    {
        private readonly IRepository<RoleEntity> _roleRepository;

        #region ctor
        public RoleService()
        {
            //TODO: 移除内部依赖
            _roleRepository = new Repository<RoleEntity>();
        }
        #endregion

        /// <summary>
        /// 获取当前用户所创建的角色
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IPageList<RoleEntity>> GetRolesByUserIdAsync(
            int userId, int offset, int perPage, string keyword)
        {
            var query = _roleRepository.Query.Where(x => x.CreateUserId == userId && !x.Deleted)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(perPage);

            if (!string.IsNullOrEmpty(keyword))
            {
                query.Where(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }

            return await query.ToPageListAsync();
        }

        /// <summary>
        /// 获取用户创建的所有角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IList<RoleEntity>> GetAllRolesAsync(int userId)
        {
            return await _roleRepository.Query.Where(x => x.CreateUserId == userId && !x.Deleted).ToListAsync();
        }

        /// <summary>
        /// 根据Id和UserId获取角色
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public RoleEntity Get(int Id)
        {
            return _roleRepository.Query.Where(x => x.Id == Id
                && !x.Deleted).SingleOrDefault();
        }

        /// <summary>
        /// 根据Id和UserId获取角色
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<RoleEntity> GetAsync(int Id)
        {
            return await _roleRepository.Query.Where(x => x.Id == Id 
                && !x.Deleted).SingleOrDefaultAsync();
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(RoleEntity entity)
        {
            await _roleRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task InsertAsync(RoleEntity entity)
        {
            await _roleRepository.InsertAsync(entity);
        }
    }
}
