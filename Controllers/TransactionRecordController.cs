// Name: Arin Patodia
// Date: 09-12-2021
// Assignment #5 & Communication Activity


using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using TransactionRecord.Models;

namespace TransactionRecord.Controllers
{
    public class TransactionRecordController : Controller
    {
        public TransactionRecordController(TransactionDbContext txnContext)
        {
            _txnContext = txnContext;
        }

        public IActionResult Index()
        {
            var txns = _txnContext.Transactions.Include(txn => txn.TransactionType).Include(txn => txn.Company).OrderBy(t => t.Company.TickerSymbol).ToList();
            return View(txns);
        }

        private TransactionDbContext _txnContext;
    }
}
