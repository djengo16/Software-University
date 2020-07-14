using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }
        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                     .UseSqlServer(Configuration.Connection);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TeamConfiguration(modelBuilder);

            ColorConfiguration(modelBuilder);

            TownConfiguration(modelBuilder);

            CountryConfiguration(modelBuilder);

            PlayerConfiguration(modelBuilder);

            PositionConfiguration(modelBuilder);

            PlayerStatisticConfiguration(modelBuilder);

            GameConfiguration(modelBuilder);

            BetConfiguration(modelBuilder);

            UserConfiguration(modelBuilder);

        }

        private static void UserConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);

                entity
                .Property(u => u.Username)
                .IsRequired(true)
                .HasMaxLength(50);

                entity
                .Property(u => u.Password)
                .IsRequired(true)
                .HasMaxLength(256);

                entity
                .Property(u => u.Email)
                .IsUnicode(false)
                .IsRequired(true)
                .HasMaxLength(60);

                entity
                .Property(u => u.Name)
                .IsRequired(false)
                .IsUnicode(true)
                .HasMaxLength(80);

            });
        }

        private static void BetConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(b => b.BetId);

                entity
                .HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);

                entity
                .HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);
            });
        }

        private static void GameConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.GameId);

                entity
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void PlayerStatisticConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new
                {
                    ps.PlayerId,
                    ps.GameId
                });

                entity
                .HasOne(ps => ps.Player)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId);

                entity
                .HasOne(ps => ps.Game)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId);
            });
        }

        private static void PositionConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(p => p.PositionId);

                entity
                .Property(p => p.Name)
                .IsRequired(true)
                .HasMaxLength(50);
            });
        }

        private static void PlayerConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(p => p.PlayerId);

                entity
                .Property(p => p.Name)
                .IsRequired(true)
                .HasMaxLength(40);

                entity
                .Property(p => p.SquadNumber)
                .IsRequired(true)
                .HasMaxLength(3);

                entity
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

                entity
                .HasOne(p => p.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.PositionId);
            });
        }

        private static void CountryConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(c => c.CountryId);

                entity
                .Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(50);
            });
        }

        private static void TownConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(t => t.TownId);

                entity
                .Property(t => t.Name)
                .IsRequired(true)
                .HasMaxLength(50);

                entity
                .HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId);
            });
        }

        private static void ColorConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.ColorId);

                entity
                .Property(c => c.Name)
                .IsRequired(true);
            });
        }

        private static void TeamConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.TeamId);

                entity
                .Property(t => t.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

                entity
                .Property(t => t.LogoUrl)
                .IsUnicode(false)
                .IsRequired(true);

                entity
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(t => t.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TownId);
            });
        }
    }
}
