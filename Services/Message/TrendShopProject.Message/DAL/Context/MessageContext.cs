using Microsoft.EntityFrameworkCore;
using TrendShopProject.Message.DAL.Entities;

namespace TrendShopProject.Message.DAL.Context
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {

        }

        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
