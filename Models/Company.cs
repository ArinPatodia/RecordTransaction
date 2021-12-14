using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TransactionRecord.Models
{
    public class Company
    {
        public int? CompanyId { get; set; }

        
        [Required(ErrorMessage = "Please enter a company name.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please enter address.")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "Please enter a ticker symbol.")]
        public string TickerSymbol { get; set; }

    }
}
