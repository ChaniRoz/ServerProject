using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
            
        }
        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Users> Users { get; set; }
        public object ExceptionLog { get; set; }
    }
}
