using Microsoft.EntityFrameworkCore;


namespace Karizma.Sample.Persistance.Repositories;

public sealed class RepositoryDbContext :DbContext 
{
    public RepositoryDbContext(DbContextOptions options) : base(options)
    { }
 


    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
}

