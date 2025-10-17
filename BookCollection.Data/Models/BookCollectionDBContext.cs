using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data.Models;

public partial class BookCollectionDBContext : DbContext
{
    public BookCollectionDBContext()
    {
    }

    public BookCollectionDBContext(DbContextOptions<BookCollectionDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookStatus> BookStatuses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CompletedBook> CompletedBooks { get; set; }

    public virtual DbSet<Lending> Lendings { get; set; }

    public virtual DbSet<ReadingStatus> ReadingStatuses { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<Translator> Translators { get; set; }

    public virtual DbSet<WishList> WishLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SOURAV\\MSSQLSERVER_2012;Database=MyBookCollectionDb;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasOne(d => d.Author).WithMany(p => p.Books).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.BookStatus).WithMany(p => p.Books).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Category).WithMany(p => p.Books).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ReadingStatus).WithMany(p => p.Books).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SubCategory).WithMany(p => p.Books).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Translator).WithMany(p => p.Books).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CompletedBook>(entity =>
        {
            entity.HasOne(d => d.Book).WithMany(p => p.CompletedBooks).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Lending>(entity =>
        {
            entity.HasOne(d => d.Book).WithMany(p => p.Lendings).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.BookStatus).WithMany(p => p.Lendings).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.SubCategories).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
