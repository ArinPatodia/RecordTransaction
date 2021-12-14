// Name: Arin Patodia
// Date: 09-12-2021
// Assignment #5 & Communication Activity


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransactionRecord.Models;

namespace TransactionRecord.Controllers
{
    
    public class TransactionController : Controller
    {
        public TransactionController(TransactionDbContext txnContext)
        {
            _txnContext = txnContext;
        }

        public IActionResult OnlyTransactions(int id)
        {
            Company test = _txnContext.Companies.Where(d => d.CompanyId == id).FirstOrDefault();
            ViewBag.Name = test.CompanyName;
            ViewBag.Symbol = test.TickerSymbol;
            var alltransactions = _txnContext.Transactions.Include(h => h.Company).Include(h => h.TransactionType).Where(d => d.Company.CompanyId == id).ToList();
            return View(alltransactions);
        }

        // GET & POST for the Add sub-resource..
        [HttpGet()]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.TransactionTypes = _txnContext.TransactionTypes.OrderBy(txnType => txnType.Name).ToList();
            return View("Edit", new Transaction());
        }

        [HttpPost()]
        public IActionResult Add(Transaction txn)
        {
            
            if (ModelState.IsValid)
            {
                _txnContext.Transactions.Add(txn);
                _txnContext.SaveChanges();

                return RedirectToAction("Index", "TransactionRecord");
            }
            else
            {
                ViewBag.Action = "Add";
                ViewBag.TransactionTypes = _txnContext.TransactionTypes.OrderBy(txnType => txnType.Name).ToList();

                
                return View("Edit", txn);
            }
        }








        // GET & POST for the Edit sub-resource..
        [HttpGet()]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.TransactionTypes = _txnContext.TransactionTypes.OrderBy(txnType => txnType.Name).ToList();
            var txn = _txnContext.Transactions.Find(id);
            return View(txn);
        }

        [HttpPost()]
        public IActionResult Edit(Transaction txn)
        {
            if (ModelState.IsValid)
            {
                _txnContext.Transactions.Update(txn);
                _txnContext.SaveChanges();
                this.TempData["LastActionMessage"] = $"{txn.Company.CompanyName} has been edited.";
                return RedirectToAction("Index", "TransactionRecord");
            }
            else
            {
                ViewBag.Action = "Edit";
                ViewBag.TransactionTypes = _txnContext.TransactionTypes.OrderBy(txnType => txnType.Name).ToList();
                return View(txn);
            }
        }










        // GET & POST for the Delete sub-resource..
        [HttpGet()]
        public IActionResult Delete(int id)
        {
            var txn = _txnContext.Transactions.Find(id);
            return View(txn);
        }

        [HttpPost()]
        public IActionResult Delete(Transaction txn)
        {
            _txnContext.Transactions.Remove(txn);
            _txnContext.SaveChanges();
            this.TempData["LastActionMessage"] = $"Successfully deleted.";
            return RedirectToAction("Index", "TransactionRecord");
        }

        





        private TransactionDbContext _txnContext;

    }
}
