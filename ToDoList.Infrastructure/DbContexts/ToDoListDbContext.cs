using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.DbContexts
{
    public class ToDoListDbContext : IdentityDbContext<ApplicationUser>
    {
        public ToDoListDbContext()
            : base("ToDoListConnection", throwIfV1Schema: false)
        {
        }       

        public DbSet<TaskItem> TaskItems { get; set; }

        public static ToDoListDbContext Create()
        {
            return new ToDoListDbContext();
        }
    }
}