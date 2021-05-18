using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelsServices.MainDb;

namespace DataService.ModelsConfigurations
{
    public class UserFullDataConfiguration : IEntityTypeConfiguration<UserFullData>
    {
        public void Configure(EntityTypeBuilder<UserFullData> builder)
        {
            builder.HasKey(u=>u.Id);
            builder.Property(u => u.Notes).HasMaxLength(500);
            builder.Property(u => u.DisplayName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.MiddleName).HasMaxLength(50);
            builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Gender).HasMaxLength(50);
            builder.Property(u => u.ProfilePic).HasMaxLength(250);
            builder.Property(u => u.BirthDate).HasMaxLength(50);
            builder.Property(u => u.UserRole).HasMaxLength(50);
            builder.Property(u => u.UserId).HasMaxLength(150).IsRequired();

        }
    }
}