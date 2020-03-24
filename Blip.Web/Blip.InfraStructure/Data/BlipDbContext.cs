using Blip.Core.Entities;
using Blip.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Blip.InfraStructure.Data
{
    public class BlipDbContext : DbContext, IBlipDbContext
    {
        public BlipDbContext(DbContextOptions<BlipDbContext> options) : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            //{
            //    switch (entry.State)
            //    {
            //        case EntityState.Added:
            //            entry.Entity.CreatedBy = _currentUserService.UserId;
            //            entry.Entity.Created = _dateTime.Now;
            //            break;
            //        case EntityState.Modified:
            //            entry.Entity.LastModifiedBy = _currentUserService.UserId;
            //            entry.Entity.LastModified = _dateTime.Now;
            //            break;
            //    }
            //}
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
          //  builder.Seed();
        }
    }
}
