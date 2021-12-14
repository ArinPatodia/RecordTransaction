using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TransactionRecord.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "Please enter a company.")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        //[Required(ErrorMessage = "Please enter a ticker symbol.")]
        //public string TickerSymbol { get; set; }

        //[Required(ErrorMessage = "Please enter a company name.")]
        //public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please enter a quantity.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity of shares must a positive integer.")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Please enter a share price.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Share price must greater than zero.")]
        public double? SharePrice { get; set; }

       

        public double? GetGrossValue()
        {
            return this.SharePrice * this.Quantity;
        }

        public double? GetNetValue()
        {
            if (this.TransactionType.Name == "Buy")
                return this.GetGrossValue() + this.TransactionType.CommissionFee;
            else
                return this.GetGrossValue() - this.TransactionType.CommissionFee;
        }

        [Required(ErrorMessage = "Please enter a transaction type.")]
        public string TransactionTypeId { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}
