using System;

namespace Interview.DomainModel
{
    public interface ISomeEntity
    {
        Guid Id { get; }
        long ApplicationId { get; }
        string Type { get; }
        string Summary { get; }
        decimal Amount { get; }
        DateTime? PostingDate { get; }
        bool IsCleared { get; }
        DateTime? ClearedDate { get; }
    }
}
