namespace Shop.NoRepository.Domain
{
    public class ProductWithReservations : Product
    {
        public int ReservationCount { get; set; }
    }
}