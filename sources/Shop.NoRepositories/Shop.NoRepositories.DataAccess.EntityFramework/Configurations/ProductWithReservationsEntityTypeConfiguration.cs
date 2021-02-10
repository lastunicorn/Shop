using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.NoRepository.Domain;

namespace Shop.NoRepository.DataAccess.EntityFramework.Configurations
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