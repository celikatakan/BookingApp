using BookingApp.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookingAppDbContext _db;
        private IDbContextTransaction _transaction;
        public UnitOfWork(BookingAppDbContext db)
        {
            _db = db;
        }
        public async Task BeginTransaction()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task RollBackTransaction()
        {
            await _transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
          return await _db.SaveChangesAsync();
        }
    }
}
