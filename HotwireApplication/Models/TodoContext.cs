using Microsoft.EntityFrameworkCore;

namespace HotwireApplication.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> todos { get; set; }

        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("todos");
        }
    }

    public class Todo
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public bool Completed { get; set; }
    }
}