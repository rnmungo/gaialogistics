using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.GaiaLogistics.Models;

namespace DAL.GaiaLogistics.TypeBuilders
{
    public sealed class UserTypeBuilder : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
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

            builder.Property(entity => entity.LastName)
                .IsRequired(true)
                .HasColumnType("varchar(50)");

            builder.Property(entity => entity.Email)
                .IsRequired(true)
                .HasColumnType("varchar(100)");

            builder.Property(entity => entity.Password)
                .IsRequired(true)
                .HasColumnType("varchar(255)");

            builder.HasIndex(entity => entity.Email).IsUnique();

            builder.ToTable("Users");
        }
    }
}
