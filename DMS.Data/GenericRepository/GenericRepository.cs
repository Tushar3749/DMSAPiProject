﻿using DMS.Data.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DMS.Data.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> table;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.table = context.Set<T>();
        }

        public async void Delete(Expression<Func<T, bool>> predicate)
        {
            T existing = await table.FindAsync(predicate);
            table.Remove(existing);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ExecuteCommand(string query, params object[] parameters)
        {
            _ = await context.Database.ExecuteSqlRawAsync(query, parameters);
            return true;
        }

        public async Task<List<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await table.Where(predicate).ToListAsync();
        }

        public async Task<T> FindOne(Expression<Func<T, bool>> predicate)
        {
            return await table.FirstOrDefaultAsync(predicate);
        }

        
        public async Task<List<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> Insert(T Entity)
        {
            table.Add(Entity);
            await context.SaveChangesAsync();
            return Entity;
        }


        public async Task<List<T>> InsertBulk(List<T> Entity)
        {
            await table.AddRangeAsync(Entity);
            await context.SaveChangesAsync();
            return Entity;
        }

        public async Task<T> Update(T Entity, Expression<Func<T, bool>> predicate)
        {
            T value = await table.FirstOrDefaultAsync(predicate);
            context.Entry(value).CurrentValues.SetValues(Entity);
            await context.SaveChangesAsync();
            return Entity;
        }

        public async Task<List<T>> FindUsingSPAsync(string storedProcedureName, SqlParameter[] parameters = null)
        {
            if (parameters == null || parameters.Length == 0) return await table.FromSqlRaw<T>(storedProcedureName).ToListAsync();

            else return await table.FromSqlRaw<T>(storedProcedureName, parameters).ToListAsync();
        }

        public async Task<Boolean> CommitAll()
        {           
            await context.SaveChangesAsync();
            return true;
        }
    }
}