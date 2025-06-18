using MF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Infrastructure.Configurations
{
    public class ManufacturingContext : DbContext, IQueryableUnitOfWork
    {
        public ManufacturingContext()
        {

        }

        public ManufacturingContext(DbContextOptions<ManufacturingContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasKey(c => c.Id);
            modelBuilder.Entity<User>().Property(e => e.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<User>().Property(e => e.DateCreated).HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<ElaborationType>().HasKey(c => c.Id);
            modelBuilder.Entity<ElaborationType>().Property(e => e.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<ElaborationType>().Property(e => e.DateCreated).HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Product>().HasKey(c => c.Id);
            modelBuilder.Entity<Product>().Property(e => e.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Product>().Property(e => e.DateCreated).HasDefaultValueSql("GETUTCDATE()");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<ElaborationType> ElaborationTypes { get; set; }
        public DbSet<Product> Products { get; set; }

        public void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await ex.Entries.Single().ReloadAsync().ConfigureAwait(false);
            }
        }

        public void DetachLocal<TEntity>(TEntity entity, EntityState state) where TEntity : class
        {

            if (entity is null)
            {
                return;
            }

            var local = Set<TEntity>().Local.ToList();

            if (local?.Any() ?? false)
            {
                local.ForEach(item =>
                {
                    Entry(item).State = EntityState.Detached;
                });
            }

            Entry(entity).State = state;
        }

        public DbContext GetContext()
        {
            return this;
        }

        public DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }
    }
}
