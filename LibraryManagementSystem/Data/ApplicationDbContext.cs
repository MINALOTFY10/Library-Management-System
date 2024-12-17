using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    // The ApplicationDbContext class serves as the main entry point for interacting with the database.
    // It inherits from IdentityDbContext<Member> to integrate ASP.NET Core Identity for user management.
    public class ApplicationDbContext : IdentityDbContext<Member>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Configures the entity relationships and seed data during model creation.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensures the base configuration from IdentityDbContext is applied.
            base.OnModelCreating(modelBuilder);

            // Defines a composite primary key for the BorrowsCopy entity to represent the relationship
            // between a Member and a BookCopy (many-to-many relationship).
            modelBuilder.Entity<BorrowsCopy>().HasKey(b => new { b.MemberId, b.BookCopyId });

            // Seeding roles into the database to ensure Admin and Client roles are available by default.
            // This simplifies initial setup for role-based access control.
            var admin = new IdentityRole("Admin")
            {
                NormalizedName = "admin"
            };

            var client = new IdentityRole("Client")
            {
                NormalizedName = "client"
            };

            // Adds the roles to the database during migration.
            modelBuilder.Entity<IdentityRole>().HasData(admin, client);
        }

        // DbSet properties represent tables in the database.
        public DbSet<Book> Books { set; get; } // Table for storing book information.
        public DbSet<Genre> Genres { set; get; } // Table for categorizing books by genre.
        public DbSet<BookCopy> BookCopies { set; get; } // Table for tracking individual copies of books.
        public DbSet<Member> Members { set; get; } // Table for user accounts, integrated with Identity.
        public DbSet<BorrowsCopy> BorrowsCopies { set; get; } // Table for tracking which member borrowed which book copy.
        public DbSet<Reservation> Reservations { set; get; } // Table for storing book reservation data.
        public DbSet<Penalty> Penalties { set; get; } // Table for managing penalties for overdue books.
    }
}
