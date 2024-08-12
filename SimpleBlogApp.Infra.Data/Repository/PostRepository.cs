using SimpleBlogApp.Abstraction.Repository;
using SimpleBlogApp.Domain.Entities;
using SimpleBlogApp.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleBlogApp.Infra.Data.DBContext;

namespace SimpleBlogApp.Infra.Data.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(SimpleBlogDbContext context) : base(context)
        { 
                
        }

        public async Task<ICollection<Post>> GetAllPostByUserId(string userId)
        {
            return await DbSet.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
