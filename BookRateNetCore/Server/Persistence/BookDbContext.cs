using BookRateNetCore.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRateNetCore.Server.Persistence
{
    public class BookDbContext : DbContext
    {
        //public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        //{
        //}

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookRateNetCoreDB;Trusted_Connection=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Book>().HasKey(b => b.Id);
        //    modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired();
        //    modelBuilder.Entity<Book>().Property(b => b.Description).IsRequired();
        //    modelBuilder.Entity<Book>().Property(b => b.Author).IsRequired();
        //    modelBuilder.Entity<Book>().Property(b => b.Rate).IsRequired();
        //}
    }
}
