﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StudentEnrollment.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly StudentEnrollmentDbContext _db;

        public GenericRepository(StudentEnrollmentDbContext db) 
        {
            this._db = db;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int? id)
        {
            var entity = await GetAsync(id);
            _db.Set<TEntity>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Exists(int? id)
        {
            //var entity = await GetAsync(id);
            //return entity !=  null;
            // Trevoir saying this is more efficient than above:
            return await _db.Set<TEntity>().AnyAsync(q => q.Id == id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(int? id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _db.Update(entity);
        }
    }
}
