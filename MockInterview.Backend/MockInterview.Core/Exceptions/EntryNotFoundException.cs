using System.Runtime.Serialization;

namespace MockInterview.Core.Exceptions;

/// <summary>
/// Represents Entry on Database not found exception
/// </summary>
public class EntryNotFoundException : Exception
{
    public EntryNotFoundException()
    {
    }

    public EntryNotFoundException(string? message) : base(message)
    {
    }

    public EntryNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
