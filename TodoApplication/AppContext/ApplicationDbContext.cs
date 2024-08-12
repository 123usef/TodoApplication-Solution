using Microsoft.EntityFrameworkCore;
using TodoApplication.Models;

namespace TodoApplication.AppContext
{
    public class ApplicationDbContext :DbContext
    {
        // مدير العلاقات العامة مع ال داتابيز
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region  Todo Fluent Api 

            // Todo Fluent Api 
            modelBuilder.Entity<Todo>().
                Property(t => t.Description)
                .IsRequired(false)
                .HasMaxLength(255);

            modelBuilder.Entity<Todo>().
               Property(t => t.CreatedAt)
               .HasDefaultValue(new DateTime());

            modelBuilder.Entity<Todo>().
              Property(t => t.isFinished)
              .HasDefaultValue(false);

            modelBuilder.Entity<Todo>().
             Property(t => t.Name)
             .HasMaxLength(70);

            #endregion
        }


        public DbSet<Todo> todos { get; set; }


    }
}
