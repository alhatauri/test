using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Log.Models
{
    public partial class LogsContext
    {
        public LogsContext()
        {
            Database.EnsureCreated();
        }

        public LogsContext(DbContextOptions<LogsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logs>().HasData(
            new Logs[] 
            {
                new Logs { LogsId = 1, Info = "{ 'data' }" },
            });
        }
    }
}