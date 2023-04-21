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
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<GroupMember>()
        //    .HasKey(c => new { c.ThinkMemberId, c.ThinkGroupId });

        //modelBuilder.Entity<GroupMember>()
        //    .HasOne(gm => gm.ThinkGroup)
        //    .WithMany(g => g.GroupMembers)
        //    .HasForeignKey(g => g.ThinkGroupId);

        //modelBuilder.Entity<GroupMember>()
        //    .HasOne(gm => gm.ThinkMember)
        //    .WithMany(m => m.GroupMembers)
        //    .HasForeignKey(m => m.ThinkMemberId);

        //modelBuilder.Entity<ThinkGroup>()
        //    .HasMany(c => c.GroupMembers);            

        //modelBuilder.Entity<ThinkMember>()
        //    .HasMany(c => c.GroupMembers);            

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
