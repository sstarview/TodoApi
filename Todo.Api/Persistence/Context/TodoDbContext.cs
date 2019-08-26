using Microsoft.EntityFrameworkCore;
using Todo.Api.Domian.Models;

namespace Todo.Api.Persistence.Context
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TodoItem>().ToTable("TodoItems");
            builder.Entity<TodoItem>().HasKey(p => p.Id);
            builder.Entity<TodoItem>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TodoItem>().Property(p => p.Name).IsRequired();
            builder.Entity<TodoItem>().Property(p => p.IsComplete).IsRequired();

            builder.Entity<TodoItem>().HasData
                (
                    new TodoItem { Id = 100, Name = "C# Delegates", IsComplete = false },
                    new TodoItem { Id = 101, Name = "Javascript oops", IsComplete = false }
                );
        }
    }
}
