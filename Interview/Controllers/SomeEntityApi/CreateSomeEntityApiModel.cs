using System;
using System.ComponentModel.DataAnnotations;

namespace Interview.Controllers.SomeEntityApi
{
    public class CreateSomeEntityApiModel
    {
        public long ApplicationId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Summary { get; set; }

        public decimal Amount { get; set; }

        public DateTime? PostingDate { get; set; }

        public bool IsCleared { get; set; }

        public DateTime? ClearedDate { get; set; }
    }
}
