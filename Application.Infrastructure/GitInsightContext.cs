using Microsoft.EntityFrameworkCore;

public class GitInsightContext : DbContext
{
    public DbSet<Repo> Repos => Set<Repo>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Commit> Commits => Set<Commit>();

    public GitInsightContext(DbContextOptions<GitInsightContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
                    .HasIndex(i => i.Email)
                    .IsUnique();
    }
}