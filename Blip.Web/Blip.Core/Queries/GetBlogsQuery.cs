using Blip.Core.Dto;
using Blip.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blip.Core.Queries
{
    public class GetBlogsQuery : IRequest<List<BlogDto>>
    {
        public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, List<BlogDto>>
        {
            private IBlipDbContext _context;
            public GetBlogsQueryHandler(IBlipDbContext context)
            {
                _context = context;
            }
            public async Task<List<BlogDto>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
            {
                return await _context.Blogs
                    .Select(c => new BlogDto
                    {
                        Id = c.Id,
                        Author = c.Author,
                        Post = c.Post,
                        CreatedBy = c.CreatedBy,
                        CreatedDate = c.CreatedDate,
                        Comments = c.Comments.Select(comm => new CommentDto
                        {
                            Id = comm.Id,
                            BlogId = comm.BlogId,
                            CommentText = comm.CommentText,
                            CreatedBy = comm.CreatedBy,
                            CreatedDate = comm.CreatedDate
                        })
                    })
                    .OrderBy(t => t.Author)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
