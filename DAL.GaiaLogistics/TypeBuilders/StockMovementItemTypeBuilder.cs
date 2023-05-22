using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.GaiaLogistics.Models;

namespace DAL.GaiaLogistics.TypeBuilders
{
    public sealed class StockMovementItemTypeBuilder : IEntityTypeConfiguration<StockMovementItemModel>
    {
        public void Configure(EntityTypeBuilder<StockMovementItemModel> builder)
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

            builder.Property(entity => entity.Quantity)
                .IsRequired(true)
                .HasColumnType("int");

            builder.Property(entity => entity.ProductId)
                .IsRequired(true)
                .HasColumnType("uniqueidentifier");

            builder.Property(entity => entity.StockMovementId)
                .IsRequired(true)
                .HasColumnType("uniqueidentifier");

            builder.HasOne(entity => entity.Product)
                .WithMany(relation => relation.StockMovementItems)
                .HasForeignKey(entity => entity.ProductId);

            builder.HasOne(entity => entity.StockMovement)
                .WithMany(relation => relation.StockMovementItems)
                .HasForeignKey(entity => entity.StockMovementId);

            builder.ToTable("StockMovementItems");
        }
    }
}
