using Blip.Core.Entities;
using Blip.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blip.Core.Commands
{
    public class DeleteBlogCommand : IRequest
    {
        public int Id { get; set; }
        public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand>
        {
            private IBlipDbContext _context;
            public DeleteBlogCommandHandler(IBlipDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
            {
                var blog = await _context.Blogs
                    .FirstOrDefaultAsync(l => l.Id == request.Id);

                if (blog == null)
                {
                    throw new ArgumentException(nameof(Blog), request.Id.ToString());
                }

                _context.Blogs.Remove(blog);

                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;

            }

        }
    }
}
