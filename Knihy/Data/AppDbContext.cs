
using Knihy.Models;
using Microsoft.EntityFrameworkCore;

namespace Knihy.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Writer_Book>().HasKey(am => new {
                am.WriterId,
                am.BookId,
            
            });
            modelBuilder.Entity<Writer_Book>().HasOne(m => m.Book).WithMany(am => am.Writer_Books).HasForeignKey(m => m.BookId);
            modelBuilder.Entity<Writer_Book>().HasOne(m => m.Writer).WithMany(am => am.Writer_Books).HasForeignKey(m => m.WriterId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Writer> Writers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Writer_Book> Writer_Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
       // public DbSet<Editor> Editors { get; set; }

    }
}
