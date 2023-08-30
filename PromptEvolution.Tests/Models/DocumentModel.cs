using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptEvolution.Tests.Models
{
    public record DocumentMetaData
    {
        [Required]
        public string? Correspondent { get; set; }
        [Required]
        public string? Subject { get; set; }
        [Required]
        public string? Keywords { get; set; }
        [Required]
        public DateTimeOffset? CreationDate { get; set; }
        [Required]
        public string? IBAN { get; set; }
        [Required]
        public string? BIC { get; set; }
        [Required]
        public DocumentType DocumentType { get; set; }
        [Required]
        public string[]? OrderItems { get; set; }
        [Required]
        public int? Amount { get; set; }
        [Required]
        public string? Currency { get; set; }
        [Required]
        public string[]? Persons { get; set; }

    }

    public enum DocumentType
    {
        None = 0,
        Receipt = 1,
        Invoice = 2,
        Document = 3,
        Image = 4,
        Penalty = 5,
        Bid = 6,
        Tax = 7,
        SickCertificate = 8,
        Pension = 9,
        Salary = 10,
        Contract = 11,
        Unimportant = 12,



    }
}
