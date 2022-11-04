

public sealed class GitInsightContext : DbContext
{
    public DbSet<Repo> Repos => Set<Repo>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<GitCommit> Commits => Set<GitCommit>();

    public GitInsightContext(DbContextOptions<GitInsightContext> options) : base(options){}

    public GitInsightContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
                    .HasIndex(i => i.Email)
                    .IsUnique();
    }
}