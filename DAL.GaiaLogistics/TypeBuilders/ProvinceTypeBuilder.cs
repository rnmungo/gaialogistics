using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.GaiaLogistics.Models;

namespace DAL.GaiaLogistics.TypeBuilders
{
    public sealed class ProvinceTypeBuilder : IEntityTypeConfiguration<ProvinceModel>
    {
        public void Configure(EntityTypeBuilder<ProvinceModel> builder)
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

            builder.Property(entity => entity.AreaCode)
                .IsRequired(false)
                .HasColumnType("int");

            builder.Property(entity => entity.Code)
                .IsRequired(true)
                .HasColumnType("varchar(20)");

            builder.Property(entity => entity.Name)
                .IsRequired(true)
                .HasColumnType("varchar(50)");

            builder.Property(entity => entity.CountryId)
                .IsRequired(true)
                .HasColumnType("uniqueidentifier");

            builder.HasOne(entity => entity.Country)
                .WithMany(relation => relation.Provinces)
                .HasForeignKey(entity => entity.CountryId);

            builder.HasMany(entity => entity.Cities)
                .WithOne(relation => relation.Province)
                .HasForeignKey(relation => relation.ProvinceId);

            builder.HasIndex(entity => entity.Code).IsUnique();

            builder.ToTable("Provinces");
        }
    }
}
