using Dapper;
using NetSaleSvc.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Dapper.Plus;

namespace NetSaleSvc.Entity.Repository.Impl
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        public IRepositoryQueryable<T> Query
        {
            get
            {
                return new RepositoryQueryable<T>();
            }
        }

        public int Insert(T entity)
        {
            using (var connection = DbConnectionFactory.OpenConnection())
            {
                return connection.Insert<int>(entityToInsert: entity);
            }
        }

        public void BulkInsert(IEnumerable<T> entities)
        {
            using (var connection = DbConnectionFactory.OpenConnection())
            {
                connection.BulkInsert(entities);
            }
        }

        public void BulkMerge(IEnumerable<T> entities)
        {
            using (var connection = DbConnectionFactory.OpenConnection())
            {
                connection.BulkMerge(entities);
            }
        }

        public void BulkDelete(IEnumerable<T> entities)
        {
            using (var connection = DbConnectionFactory.OpenConnection())
            {
                connection.BulkDelete(entities);
            }
        }

        public async Task<int> InsertAsync(T entity)
        {
            using (var connection = await DbConnectionFactory.OpenConnectionAsync())
            {
                return await connection.InsertAsync<int>(entityToInsert: entity);
            }
        }

        public int InsertWithTransaction(T entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Insert<int>(entityToInsert: entity, transaction: transaction);
        }

        public async Task<int> InsertWithTransactionAsync(T entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            return await connection.InsertAsync<int>(entityToInsert: entity, transaction: transaction);
        }

        public void Update(T entity)
        {
            using (var connection = DbConnectionFactory.OpenConnection())
            {
                connection.Update(entityToUpdate: entity);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            using (var connection = await DbConnectionFactory.OpenConnectionAsync())
            {
                await connection.UpdateAsync(entityToUpdate: entity);
            }
        }

        public void UpdateWithTransaction(T entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            connection.Update(entityToUpdate: entity, transaction: transaction);
        }

        public async Task UpdateWithTransactionAsync(T entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            await connection.UpdateAsync(entityToUpdate: entity, transaction: transaction);
        }

        public void Delete(T entity)
        {
            using (var connection = DbConnectionFactory.OpenConnection())
            {
                connection.Delete(entityToDelete: entity);
            }
        }

        public async Task DeleteAsync(T entity)
        {
            using (var connection = DbConnectionFactory.OpenConnection())
            {
                await connection.DeleteAsync(entityToDelete: entity);
            }
        }

        public async Task ExecuteAsync(string sql, object param = null)
        {
            using (var connection = await DbConnectionFactory.OpenConnectionAsync())
            {
                await connection.ExecuteAsync(sql, param: param);
            }
        }

        public async Task ExecuteWithTransactionAsync(IDbConnection connection, string sql, object param = null,
            IDbTransaction transaction = null)
        {
            await connection.ExecuteAsync(sql, param: param, transaction: transaction);
        }

        public async Task<IEnumerable<TQuery>> QueryAsync<TQuery>(string sql, object param = null, CommandType? commandType = null)
        {
            using (var connection = await DbConnectionFactory.OpenConnectionAsync())
            {
                return await connection.QueryAsync<TQuery>(sql, param: param, commandType: commandType);
            }
        }

        public async Task<IEnumerable<TQuery>> QueryWithTransactionAsync<TQuery>(IDbConnection connection, string sql,
            object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.QueryAsync<TQuery>(sql, param: param, transaction: transaction, commandType: commandType);
        }

        public IEnumerable<TReturn> QueryDouble<TFirst, TSecond, TReturn>(string sql,
            Func<TFirst, TSecond, TReturn> map, object param = null, CommandType? commandType = default(CommandType?))
        {
            using (var connection = DbConnectionFactory.OpenConnection())
            {
                return connection.Query(sql, map, param, commandType: commandType);
            }
        }
    }
}
