using System;

namespace RepositoryPattern.WithRepository.Domain
{
    public class RepositoryPatternException : Exception
    {
        public RepositoryPatternException(string message)
            : base(message)
        {
        }
    }
}