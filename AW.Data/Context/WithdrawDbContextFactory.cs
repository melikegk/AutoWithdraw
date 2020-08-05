using AW.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AW.Data.Context
{
    public sealed class WithdrawDbContextFactory : IDesignTimeDbContextFactory<WithdrawDbContext>
    {
        public WithdrawDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WithdrawDbContext>();

            builder.UseSqlServer("Data Source=localhost;Initial Catalog=Withdraw.Prime;Trusted_Connection=True;",
                x => x.MigrationsHistoryTable("MigrationHistory"));

            return new WithdrawDbContext(builder.Options);
        }
    }
}

