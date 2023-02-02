using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SoccerPlayerApi.Model;

public partial class SoccerPlayersContext : DbContext
{
    public SoccerPlayersContext()
    {
    }

    public SoccerPlayersContext(DbContextOptions<SoccerPlayersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SoccerPlayers;Encrypt=false; Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(entity =>
        {
            entity
               
                .ToTable("Player");

            entity.Property(e => e.JeresyNumber).HasColumnName("jeresyNumber");
            entity.Property(e => e.PlayerId)
                .ValueGeneratedOnAdd()
                .HasColumnName("playerId");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(50)
                .HasColumnName("playerName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
