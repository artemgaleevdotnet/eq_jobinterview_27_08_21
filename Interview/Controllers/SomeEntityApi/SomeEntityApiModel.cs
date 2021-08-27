﻿using Interview.DomainModel;
using System;

namespace Interview.Controllers.SomeEntityApi
{
    public class SomeEntityApiModel : ISomeEntity
    {
        public SomeEntityApiModel(ISomeEntity someEntity)
        {
            Id = someEntity.Id;
            ApplicationId = someEntity.ApplicationId;
            Type = someEntity.Type;
            Summary = someEntity.Summary;
            Amount = someEntity.Amount;
            PostingDate = someEntity.PostingDate;
            IsCleared = someEntity.IsCleared;
            ClearedDate = someEntity.ClearedDate;            
        }

        public SomeEntityApiModel(CreateSomeEntityApiModel someEntity)
        {
            ApplicationId = someEntity.ApplicationId;
            Type = someEntity.Type;
            Summary = someEntity.Summary;
            Amount = someEntity.Amount;
            PostingDate = someEntity.PostingDate;
            IsCleared = someEntity.IsCleared;
            ClearedDate = someEntity.ClearedDate;
        }

        public SomeEntityApiModel(UpdateSomeEntityApiModel someEntity)
        {
            ApplicationId = someEntity.ApplicationId;
            Type = someEntity.Type;
            Summary = someEntity.Summary;
            Amount = someEntity.Amount;
            PostingDate = someEntity.PostingDate;
            IsCleared = someEntity.IsCleared;
            ClearedDate = someEntity.ClearedDate;
        }

        public Guid Id { get; set; }

        public long ApplicationId { get; set; }

        public string Type { get; set; }

        public string Summary { get; set; }

        public decimal Amount { get; set; }

        public DateTime? PostingDate { get; set; }

        public bool IsCleared { get; set; }

        public DateTime? ClearedDate { get; set; }
    }
}
