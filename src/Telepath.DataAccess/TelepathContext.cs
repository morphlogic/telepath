using Microsoft.EntityFrameworkCore;
using Morphware.Telepath.Core;

namespace Morphware.Telepath.DataAccess;

public partial class TelepathContext : DbContext
{
    public DbSet<ThinkGroup> ThinkGroups { get; set; }
    public DbSet<Member> Members { get; set; }    
    public DbSet<Thought> Thoughts { get; set; }
    public DbSet<Report> Reports { get; set; }    
    public DbSet<Topic> Topics { get; set; }

    private string _connectionString;


    public TelepathContext()
    {
    }

    public TelepathContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public TelepathContext(DbContextOptions<TelepathContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {  
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
