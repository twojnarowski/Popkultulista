// <copyright file="Context.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Popkultulista.Domain.Models;

/// <summary>
/// A <see cref="DbContext"/> for Popkultulista's Database.
/// </summary>
public class Context : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Context"/> class.
    /// </summary>
    /// <param name="options"><see cref="DbContextOptions"/> with connection string nad other options.</param>
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets a database set of <see cref="Vote"/>s.
    /// </summary>
    public DbSet<Vote> Votes { get; set; } = null!;

    /// <summary>
    /// Gets or sets a database set of <see cref="FomoVote"/>s.
    /// </summary>
    public DbSet<FomoVote> FomoVotes { get; set; } = null!;

    /// <summary>
    /// Gets or sets a database set of <see cref="Item"/>s.
    /// </summary>
    public DbSet<Item> Items { get; set; } = null!;

    /// <summary>
    /// Gets or sets a database set of <see cref="FomoItem"/>s.
    /// </summary>
    public DbSet<FomoItem> FomoItems { get; set; } = null!;

    /// <summary>
    /// Gets or sets a database set of <see cref="List"/>s.
    /// </summary>
    public DbSet<List> Lists { get; set; } = null!;

    /// <summary>
    /// Gets or sets a database set of <see cref="FomoList"/>s.
    /// </summary>
    public DbSet<FomoList> FomoLists { get; set; } = null!;

    /// <summary>
    /// Overriding the OnModelCreating method and adding Temporal Tables.
    /// </summary>
    /// <param name="modelBuilder"><see cref="ModelBuilder"/>.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder?.Entity<Vote>().ToTable("Votes", x => x.IsTemporal());
        modelBuilder?.Entity<FomoVote>().ToTable("FomoVotes", x => x.IsTemporal());
        modelBuilder?.Entity<Item>().ToTable("Items", x => x.IsTemporal());
        modelBuilder?.Entity<FomoItem>().ToTable("FomoItems", x => x.IsTemporal());
        modelBuilder?.Entity<List>().ToTable("Lists", x => x.IsTemporal());
        modelBuilder?.Entity<FomoList>().ToTable("FomoLists", x => x.IsTemporal());
    }
}