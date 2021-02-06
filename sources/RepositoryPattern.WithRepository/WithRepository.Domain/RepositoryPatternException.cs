using System;

namespace Shop.WithRepository.Domain
{
    public class RepositoryPatternException : Exception
    {
        public RepositoryPatternException(string message)
            : base(message)
        {
        }
    }
}