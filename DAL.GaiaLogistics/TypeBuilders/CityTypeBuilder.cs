using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.GaiaLogistics.Models;

namespace DAL.GaiaLogistics.TypeBuilders
{
    public sealed class CityTypeBuilder : IEntityTypeConfiguration<CityModel>
    {
        public void Configure(EntityTypeBuilder<CityModel> builder)
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

            builder.Property(entity => entity.Name)
                .IsRequired(true)
                .HasColumnType("varchar(50)");

            builder.Property(entity => entity.ProvinceId)
                .IsRequired(true)
                .HasColumnType("uniqueidentifier");

            builder.HasOne(entity => entity.Province)
                .WithMany(relation => relation.Cities)
                .HasForeignKey(entity => entity.ProvinceId);

            builder.HasMany(entity => entity.Branches)
                .WithOne(relation => relation.City)
                .HasForeignKey(relation => relation.CityId);

            builder.ToTable("Cities");
        }
    }
}
