using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.DataAccess.EntityFramework.Configurations
{
    public class ProductWithReservationsEntityTypeConfiguration : IEntityTypeConfiguration<ProductWithReservations>
    {
        public void Configure(EntityTypeBuilder<ProductWithReservations> builder)
        {
            builder
                .ToTable("Products")
                .Ignore(x => x.ReservationCount);
        }
    }
}