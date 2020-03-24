using Blip.Core.Dto;
using Blip.Core.Entities;
using Blip.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blip.Core.Commands
{
    public class UpdateBlogCommand : IRequest<int>
    {
        public BlogDto BlogDto { get; set; }
        public class UpdateBlogCommandCommandHandler : IRequestHandler<UpdateBlogCommand, int>
        {
            private IBlipDbContext _context;
            public UpdateBlogCommandCommandHandler(IBlipDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
            {
                var blog = await _context.Blogs.FindAsync(request.BlogDto.Id);

                if (blog == null)
                {
                    throw new ArgumentException(nameof(Blog), request.BlogDto.Id.ToString());
                }

                blog.Post = request.BlogDto.Post;
                blog.Author = request.BlogDto.Author;
                blog.UpdatedDate = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return blog.Id;
            }
        }
    }
}
