namespace BookShop.Data
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookShopContext : DbContext
    {
        public BookShopContext() { }

        public BookShopContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<AuthorBook> AuthorsBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Author

            modelBuilder.Entity<Author>()
                .Property(x => x.FirstName)
                .HasMaxLength(30);

            modelBuilder.Entity<Author>()
                .Property(x => x.LastName)
                .HasMaxLength(30);

            //Book
            modelBuilder.Entity<Book>()
                .Property(x => x.Name)
                .HasMaxLength(30);

            //BookShop
            modelBuilder.Entity<AuthorBook>()
                .HasKey(x => new { x.AuthorId, x.BookId });
                

        }
    }
}