using Microsoft.EntityFrameworkCore;

namespace HotwireApplication.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> todos { get; set; }
        public DbSet<Name> Names { get; set; }

        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("todos");
            modelBuilder.Entity<Name>().ToTable("names");
        }
    }

    public class Todo
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public bool Completed { get; set; }
    }

    public class Name
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
}