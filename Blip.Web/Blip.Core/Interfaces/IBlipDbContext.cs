using Blip.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Blip.Core.Interfaces
{
    public interface IBlipDbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
