using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.DataAccess.EntityFramework.Configurations
{
    public class ProductWithReservationsEntityTypeConfiguration : IEntityTypeConfiguration<ProductWithReservations2>
    {
        public void Configure(EntityTypeBuilder<ProductWithReservations2> builder)
        {
            builder
                .ToTable("Products")
                .Ignore(x => x.ReservationCount);
        }
    }
}