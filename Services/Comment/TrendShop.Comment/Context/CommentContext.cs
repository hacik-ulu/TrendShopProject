using Microsoft.EntityFrameworkCore;
using TrendShop.Comment.Entities;

namespace TrendShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public CommentContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
