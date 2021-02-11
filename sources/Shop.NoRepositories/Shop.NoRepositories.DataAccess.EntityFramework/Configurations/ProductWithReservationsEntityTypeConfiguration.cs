using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.DataAccess.EntityFramework.Configurations
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