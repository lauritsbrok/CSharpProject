

public sealed class GitInsightContext : DbContext
{
    public DbSet<GitRepo> Repos => Set<GitRepo>();
    public DbSet<GitAuthor> Authors => Set<GitAuthor>();
    public DbSet<GitCommit> Commits => Set<GitCommit>();

    public GitInsightContext(DbContextOptions<GitInsightContext> options) : base(options){}

    public GitInsightContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GitAuthor>()
                    .HasIndex(a => a.Email)
                    .IsUnique();
    }
}