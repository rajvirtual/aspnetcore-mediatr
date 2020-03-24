using Blip.Core.Dto;
using Blip.Core.Entities;
using Blip.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blip.Core.Commands
{
    public partial class CreateBlogCommand : IRequest<int>
    {
        public BlogDto BlogDto { get; set; }
        public class CreateBlogCommandCommandHandler : IRequestHandler<CreateBlogCommand, int>
        {

            private IBlipDbContext _context;
            public CreateBlogCommandCommandHandler(IBlipDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
            {
                var blog = new Blog();
                if (request.BlogDto == null)
                {
                    throw new ArgumentNullException("Please fill BlogDto Values");
                }
                if (request.BlogDto.CreatedBy == null)
                {
                    throw new ArgumentNullException("Please fill CreatedBy Value");
                }
                if (request.BlogDto.Post == null)
                {
                    throw new ArgumentNullException("Please fill Post Value");
                }
                blog.Post = request.BlogDto.Post;
                blog.Author = request.BlogDto.Author;
                blog.CreatedBy = request.BlogDto.CreatedBy;
                blog.CreatedDate = DateTime.Now;
                blog.UpdatedBy = request.BlogDto.CreatedBy;
                blog.UpdatedDate = DateTime.Now;
                _context.Blogs.Add(blog);
                await _context.SaveChangesAsync(CancellationToken.None);
                return blog.Id;
            }
        }
    }
}
