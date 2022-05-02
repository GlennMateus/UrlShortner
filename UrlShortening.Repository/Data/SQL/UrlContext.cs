using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.SQL;

public class UrlContext : DbContext
{
    public UrlContext()
    {
    }

    public UrlContext(DbContextOptions<UrlContext> options) : base(options)
    {
    }

    public DbSet<UrlModel> Url { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UrlModel>()
            .Property(ulr => ulr.Id)
            .HasDefaultValueSql("NEWID()");
        modelBuilder.Entity<UrlModel>()
            .Property(url => url.CreationDate)
            .HasDefaultValueSql("GETDATE()");
    }
}