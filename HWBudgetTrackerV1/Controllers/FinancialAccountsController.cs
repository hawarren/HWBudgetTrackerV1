using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HWBudgetTrackerV1.Models;
using Microsoft.AspNet.Identity;

namespace HWBudgetTrackerV1.Controllers
{
    public class FinancialAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FinancialAccounts
        [Authorize]
        public ActionResult Index(int? householdId)
        {
            //var thisuser = db.Users.Find(User.Identity.GetUserId());
            var financialAccounts = db.FinancialAccounts.Where(h => h.HouseholdId == householdId).Include(f => f.Household);
            return View(financialAccounts.ToList());
        }

        // GET: FinancialAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinancialAccounts financialAccounts = db.FinancialAccounts.Find(id);
            if (financialAccounts == null)
            {
                return HttpNotFound();
            }
            List<Transaction> AddUp = db.FinancialAccounts.SelectMany(t => t.Transactions).ToList();
            var AddAccounts = db.Transactions.Where(m => m.FinancialAccounts.Id == id).ToList();
            var runningTotal = 0;

            foreach (var usr in AddAccounts)
            {
                runningTotal += usr.Amount;
                //UsersViewModel vm = new UsersViewModel();
                //vm.User = usr;
                //vm.Roles = helper.ListUserRoles(usr.Id).ToList();
                //users.Add(vm);
                
            }
            financialAccounts.Balance = runningTotal;
            db.Entry(financialAccounts).State = EntityState.Modified;
            db.SaveChanges();

            return View(financialAccounts);
        }

        // GET: FinancialAccounts/Create
        public ActionResult Create(int HouseholdId)
        {
            FinancialAccounts financialAccount = new FinancialAccounts();
            financialAccount.HouseholdId = HouseholdId;

            //ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name");
            return View(financialAccount);
        }

        // POST: FinancialAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Balance,ReconciledBalance,HouseholdId,TransactionId")] FinancialAccounts financialAccounts)
        {
            if (ModelState.IsValid)
            {
                db.FinancialAccounts.Add(financialAccounts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name", financialAccounts.HouseholdId);
            return View(financialAccounts);
        }

        // GET: FinancialAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinancialAccounts financialAccounts = db.FinancialAccounts.Find(id);
            if (financialAccounts == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name", financialAccounts.HouseholdId);
            return View(financialAccounts);
        }

        // POST: FinancialAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Balance,ReconciledBalance,HouseholdId,TransactionId")] FinancialAccounts financialAccounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(financialAccounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name", financialAccounts.HouseholdId);
            return View(financialAccounts);
        }

        // GET: FinancialAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinancialAccounts financialAccounts = db.FinancialAccounts.Find(id);
            if (financialAccounts == null)
            {
                return HttpNotFound();
            }
            return View(financialAccounts);
        }

        // POST: FinancialAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FinancialAccounts financialAccounts = db.FinancialAccounts.Find(id);
            db.FinancialAccounts.Remove(financialAccounts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
