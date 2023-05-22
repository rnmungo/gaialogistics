using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.GaiaLogistics.Models;

namespace DAL.GaiaLogistics.TypeBuilders
{
    public sealed class BranchTypeBuilder : IEntityTypeConfiguration<BranchModel>
    {
        public void Configure(EntityTypeBuilder<BranchModel> builder)
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

            builder.Property(entity => entity.Code)
                .IsRequired(true)
                .HasColumnType("varchar(20)");

            builder.Property(entity => entity.Name)
                .IsRequired(true)
                .HasColumnType("varchar(50)");

            builder.Property(entity => entity.BranchType)
                .IsRequired(true)
                .HasColumnType("varchar(20)");

            builder.Property(entity => entity.CityId)
                .IsRequired(true)
                .HasColumnType("uniqueidentifier");

            builder.HasOne(entity => entity.City)
                .WithMany(relation => relation.Branches)
                .HasForeignKey(entity => entity.CityId);

            builder.HasIndex(entity => entity.Code).IsUnique();

            builder.ToTable("Branches");
        }
    }
}
