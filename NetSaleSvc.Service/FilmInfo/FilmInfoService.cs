using NetSaleSvc.Entity.Models;
using NetSaleSvc.Entity.Repository;
using NetSaleSvc.Entity.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSaleSvc.Service
{
    public class FilmInfoService
    {
        #region ctor
        private readonly IRepository<FilmInfoEntity> _filmInfoRepository;

        public FilmInfoService()
        {
            //TODO: 移除内部依赖
            _filmInfoRepository = new Repository<FilmInfoEntity>();
        }
        #endregion

        /// <summary>
        /// 通过影片编码列表获取影片信息实体
        /// </summary>
        /// <param name="Codes"></param>
        /// <returns></returns>
        public IList<FilmInfoEntity> GetFilmInfosByCodes(IEnumerable<string> Codes)
        {
            return _filmInfoRepository.Query.WhereIsIn(x => x.FilmCode, Codes).ToList();
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entities"></param>
        public void BulkInsert(IEnumerable<FilmInfoEntity> entities)
        {
            _filmInfoRepository.BulkInsert(entities);
        }

        /// <summary>
        /// 批量合并
        /// </summary>
        /// <param name="entities"></param>
        public void BulkMerge(IEnumerable<FilmInfoEntity> entities)
        {
            _filmInfoRepository.BulkMerge(entities);
        }
    }
}
