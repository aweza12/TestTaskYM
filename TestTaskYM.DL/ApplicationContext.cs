using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskYM.DL.Entities;

namespace TestTaskYM.DL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<Balance> Balances { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
