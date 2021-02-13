namespace Shop.WithRepositories.Domain
{
    public class ProductWithReservations : Product
    {
        public int ReservationCount { get; set; }
    }
}