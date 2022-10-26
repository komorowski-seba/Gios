namespace DomainQL.Common.Exceptions;

public class CityExistException : Exception
{
    public CityExistException(string? message) : base(message)
    {
    }
}