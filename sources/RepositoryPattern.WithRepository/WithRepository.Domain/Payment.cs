namespace RepositoryPattern.WithRepository.Domain
{
    public class Payment
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public bool IsDelivered { get; set; }
    }
}