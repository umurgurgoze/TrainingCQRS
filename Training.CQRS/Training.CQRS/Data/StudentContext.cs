using Microsoft.EntityFrameworkCore;

namespace Training.CQRS.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student() { Name = "Yavuz", Age=29, Surname="Kahraman", Id=1},
                new Student() { Name = "Mehmet", Age=25, Surname="Kahraman", Id=2}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
