using AW.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AW.Data.Context
{
    public class WithdrawDbContext: DbContext
    {
        public WithdrawDbContext(DbContextOptions<WithdrawDbContext> options)
           : base(options)
        {
        }
        public DbSet<Request> Requests { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                {
                    builder.Entity(entityType.ClrType).Property<bool>(nameof(ISoftDeletable.IsDeleted)).HasDefaultValue(false);
                }
            }
            builder.Seed();
            ConfigureSoftDelete(builder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
          CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (typeof(ISoftDeletable).IsAssignableFrom(entry.Entity.GetType()))
                            entry.CurrentValues["IsDeleted"] = false;

                        entry.CurrentValues["CreatedAt"] = DateTime.UtcNow;
                        entry.CurrentValues["CreatedById"] = 1L;//todo, after sso/auth implementation, it will be user's id
                        break;

                    case EntityState.Deleted:
                        if (typeof(ISoftDeletable).IsAssignableFrom(entry.Entity.GetType()))
                        {
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["IsDeleted"] = true;
                            entry.CurrentValues["ModifiedAt"] = DateTime.UtcNow;
                            entry.CurrentValues["ModifiedById"] = 2L;//todo, after sso/auth implementation, it will be user's id
                        }
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues["ModifiedAt"] = DateTime.UtcNow;
                        entry.CurrentValues["ModifiedById"] = 2L;//todo, after sso/auth implementation, it will be user's id
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void ConfigureSoftDelete(ModelBuilder modelBuilder)
        {
            modelBuilder.SetSoftDeletableAllEntities();
        }
    }
}

