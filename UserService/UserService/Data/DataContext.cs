using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel> UserModels { get; set; }

        public DbSet<BookModel> BookModels { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
