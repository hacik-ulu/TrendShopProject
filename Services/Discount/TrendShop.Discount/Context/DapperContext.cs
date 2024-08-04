using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TrendShop.Discount.Entities;

namespace TrendShop.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HACIKULU\\SQLEXPRESS;Initial Catalog =TrendShopDiscountDb;integrated Security=true");
        }

        public DbSet<Coupon> Coupons { get; set; }

        // Dapper üzerinden bağlantı kurmak için.
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
