using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketLoApi.Models;

namespace TicketLoApi.DataAccess
{
    public class PostgresSqlContext :DbContext
    {
        public PostgresSqlContext(DbContextOptions<PostgresSqlContext> options) : base(options)
        {
        }
        public DbSet<systemuser> systemuser { get; set; }
        public DbSet<systemuserrole> systemuserrole { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
