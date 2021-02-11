namespace Shop.NoRepositories.Domain
{
    public class ProductWithReservations : Product
    {
        public int ReservationCount { get; set; }
    }
}