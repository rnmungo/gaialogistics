using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.GaiaLogistics.Models;

namespace DAL.GaiaLogistics.TypeBuilders
{
    public sealed class StockMovementTypeBuilder : IEntityTypeConfiguration<StockMovementModel>
    {
        public void Configure(EntityTypeBuilder<StockMovementModel> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id)
                .IsRequired(true)
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("newid()");

            builder.Property(entity => entity.CreatedAt)
                .IsRequired(true)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.Property(entity => entity.UpdatedAt)
                .IsRequired(false)
                .HasColumnType("datetime2");

            builder.Property(entity => entity.DeletedAt)
                .IsRequired(false)
                .HasColumnType("datetime2");

            builder.Property(entity => entity.CauseType)
                .IsRequired(true)
                .HasColumnType("varchar(20)");

            builder.Property(entity => entity.BranchOriginId)
                .IsRequired(true)
                .HasColumnType("uniqueidentifier");

            builder.Property(entity => entity.BranchDestinationId)
                .IsRequired(true)
                .HasColumnType("uniqueidentifier");

            builder.Property(entity => entity.UserId)
                .IsRequired(true)
                .HasColumnType("uniqueidentifier");

            builder.HasOne(entity => entity.BranchOrigin)
                .WithMany(relation => relation.OriginStockMovements)
                .HasForeignKey(entity => entity.BranchOriginId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(entity => entity.BranchDestination)
                .WithMany(relation => relation.DestinationStockMovements)
                .HasForeignKey(entity => entity.BranchDestinationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(entity => entity.User)
                .WithMany(relation => relation.StockMovements)
                .HasForeignKey(entity => entity.UserId);

            builder.HasMany(entity => entity.StockMovementItems)
                .WithOne(relation => relation.StockMovement)
                .HasForeignKey(relation => relation.StockMovementId);

            builder.ToTable("StockMovements");
        }
    }
}
