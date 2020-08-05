using AW.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace AW.Data.Context
{
    public static class WithdrawDbContextSeed
    {
        static readonly DateTime createDate = new DateTime(2020, 4, 3, 15, 57, 45, 288, DateTimeKind.Utc);

        public static void Seed(this ModelBuilder builder)
        {
            builder.SeedRequest();
        }
        public static void SeedRequest(this ModelBuilder builder)
        {
            builder.Entity<Request>(request =>
            {
            });
        }
    }
}
