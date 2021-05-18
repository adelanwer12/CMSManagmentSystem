using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelsServices.MainDb;

namespace DataService.ModelsConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<address>
    {
        public void Configure(EntityTypeBuilder<address> builder)
        {
            builder.HasKey(d=>d.Id);
            builder.Property(p=>p.Line1).HasMaxLength(150).IsRequired();
            builder.Property(p=>p.Line2).HasMaxLength(150);
            builder.Property(p=>p.Unit).HasMaxLength(150);
            builder.Property(p=>p.Country).HasMaxLength(150).IsRequired();
            builder.Property(p=>p.State).HasMaxLength(150).IsRequired();
            builder.Property(p=>p.City).HasMaxLength(150).IsRequired();
            builder.Property(p=>p.PostalCode).HasMaxLength(150).IsRequired();
            builder.Property(p=>p.Type).HasMaxLength(150).IsRequired();
            builder.Property(p=>p.UserId).HasMaxLength(150).IsRequired();

        }
    }
}