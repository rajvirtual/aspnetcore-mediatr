using Blip.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Blip.InfraStructure.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Blog>().HasData(
               new Blog
               {
                   Id = 1,
                   Author = "William",
                   Post = "Test Blog",
                   CreatedDate = DateTime.Now,
                   UpdatedDate = DateTime.Now,
                   CreatedBy = "Josh",
                   UpdatedBy = "Josh"
               }
           );
            builder.Entity<Comment>().HasData(
                  new Comment
                  {
                      Id = 1,
                      CommentText = "Test Comment",
                      BlogId = 1,
                      CreatedDate = DateTime.Now,
                      UpdatedDate = DateTime.Now,
                      CreatedBy = "Josh",
                      UpdatedBy = "Josh"
                  }
              );
        }
    }
}
