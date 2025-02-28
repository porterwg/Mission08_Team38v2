using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Mission08_Team38v2.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}