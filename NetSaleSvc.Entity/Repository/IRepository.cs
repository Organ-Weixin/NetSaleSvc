using NetSaleSvc.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace NetSaleSvc.Entity.Repository
{
    /// <summary>
    /// 数据仓库
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// 查询
        /// </summary>
        IRepositoryQueryable<T> Query { get; }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entities"></param>
        void BulkInsert(IEnumerable<T> entities);
        /// <summary>
        /// 批量合并（根据主键合并）
        /// </summary>
        /// <param name="entities"></param>
        void BulkMerge(IEnumerable<T> entities);
        void BulkDelete(IEnumerable<T> entities);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Insert(T entity);
        /// <summary>
        /// 添加（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> InsertAsync(T entity);
        /// <summary>
        /// 添加（可包含事务，同步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        int InsertWithTransaction(T entity, IDbConnection connection, IDbTransaction transaction = null);
        /// <summary>
        /// 添加（可包含事务，异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<int> InsertWithTransactionAsync(T entity, IDbConnection connection, IDbTransaction transaction = null);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        /// <summary>
        /// 更新（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);
        /// <summary>
        /// 更新（可包含事务，同步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        void UpdateWithTransaction(T entity, IDbConnection connection, IDbTransaction transaction = null);
        /// <summary>
        /// 更新（可包含事务，异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task UpdateWithTransactionAsync(T entity, IDbConnection connection, IDbTransaction transaction = null);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// 删除异步
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);

        /// <summary>
        /// 执行sql（异步）
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task ExecuteAsync(string sql, object param = null);
        /// <summary>
        /// 执行sql（可包含事务）
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task ExecuteWithTransactionAsync(IDbConnection connection, string sql, object param = null,
            IDbTransaction transaction = null);

        /// <summary>
        /// 查询sql（异步）
        /// </summary>
        /// <typeparam name="TQuery"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        Task<IEnumerable<TQuery>> QueryAsync<TQuery>(string sql, object param = null, CommandType? commandType = null);
        /// <summary>
        /// 查询sql（异步，可包含事务）
        /// </summary>
        /// <typeparam name="TQuery"></typeparam>
        /// <param name="connection"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        Task<IEnumerable<TQuery>> QueryWithTransactionAsync<TQuery>(IDbConnection connection, string sql,
            object param = null, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// 同时查询两张表，返回内容以“Id”字段分隔
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="connection"></param>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        IEnumerable<TReturn> QueryDouble<TFirst, TSecond, TReturn>(string sql,
            Func<TFirst, TSecond, TReturn> map, object param = null, CommandType? commandType = default(CommandType?));
    }
}
