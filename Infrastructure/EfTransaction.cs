using Log.Abstractions;
using Log.Models;
using Microsoft.EntityFrameworkCore;

namespace Log.Infrastructure
{
    public class EfTransaction<TContext> : ITransaction
    where TContext : DbContext
    {
        TContext _context;

        public EfTransaction(TContext context) => _context = context;

        public int Save() => _context.SaveChanges();
    }
}