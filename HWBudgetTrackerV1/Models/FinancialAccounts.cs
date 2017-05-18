using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HWBudgetTrackerV1.Models
{
    public class FinancialAccounts
    {
        public FinancialAccounts()
        {
            this.Transactions = new HashSet<Transaction>();
        }
        public int Id { get; set; }
        [Display(Name = "Bank Account Name")]
        public string Name { get; set; }
        [Display(Name = "Bank Account Balance")]
        public int Balance { get; set; }
        public int ReconciledBalance { get; set; }

        public int HouseholdId { get; set; }
        public int TransactionId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual Household Household { get; set; }


    }
}