using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Morphware.Telepath.Core;

namespace Morphware.Telepath.DataAccess;

public partial class TelepathContext : DbContext
{
    public DbSet<ThinkGroup> ThinkGroups { get; set; }
    public DbSet<ThinkMember> ThinkMembers { get; set; }
    public DbSet<GroupMember> GroupMembers { get; set; }
    public DbSet<Thought> Thoughts { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<ReportThought> ReportThoughts { get; set; }
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
