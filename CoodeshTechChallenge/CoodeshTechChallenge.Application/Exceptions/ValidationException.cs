using System;

namespace CoodeshTechChallenge.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string errorMessage) : base(errorMessage) { }
    }
}
