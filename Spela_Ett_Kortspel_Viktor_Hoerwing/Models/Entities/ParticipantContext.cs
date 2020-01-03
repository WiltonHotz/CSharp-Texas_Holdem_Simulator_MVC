using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Spela_Ett_Kortspel_Viktor_Hoerwing.Models.Entities
{
    public partial class ParticipantContext : DbContext
    {
        public ParticipantContext()
        {
        }

        public ParticipantContext(DbContextOptions<ParticipantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PokerWinners> PokerWinners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokerWinners>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.HandDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShortHandSyntax)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
