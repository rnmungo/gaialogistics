using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.GaiaLogistics.Models;

namespace DAL.GaiaLogistics.TypeBuilders
{
    public sealed class ProductTypeBuilder : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
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

            builder.Property(entity => entity.Name)
                .IsRequired(true)
                .HasColumnType("varchar(50)");

            builder.Property(entity => entity.Description)
                .IsRequired(false)
                .HasColumnType("text");

            builder.Property(entity => entity.Price)
                .IsRequired(true)
                .HasColumnType("decimal(18,2)");

            builder.HasMany(entity => entity.StockMovementItems)
                .WithOne(relation => relation.Product)
                .HasForeignKey(relation => relation.ProductId);

            builder.ToTable("Products");
        }
    }
}
