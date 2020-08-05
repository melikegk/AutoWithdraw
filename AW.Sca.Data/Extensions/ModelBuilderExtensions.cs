using AW.Sca.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Aw.Sca.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SetSoftDeletableAllEntities(this ModelBuilder modelBuilder)
        {
            foreach (var type in modelBuilder.Model.GetEntityTypes()
            .Select(t => t.ClrType)
            .Where(t => typeof(ISoftDeletable).IsAssignableFrom(t)))
            {
                modelBuilder.SetSoftDeleteFilter(type);
            }
        }

        static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
        {
            SetSoftDeleteFilterMethod.MakeGenericMethod(entityType)
                .Invoke(null, new object[] { modelBuilder });
        }

        static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(ModelBuilderExtensions)
                   .GetMethods(BindingFlags.Public | BindingFlags.Static)
                   .Single(t => t.IsGenericMethod && t.Name == "SetSoftDeleteFilter");

        public static void SetSoftDeleteFilter<TEntity>(this ModelBuilder modelBuilder)
            where TEntity : class, ISoftDeletable
        {         
            modelBuilder.Entity<TEntity>().HasQueryFilter(x => !x.IsDeleted);
        }

    }
}
