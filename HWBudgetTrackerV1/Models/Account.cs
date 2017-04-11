using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HWBudgetTrackerV1.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public int ReconciledBalance { get; set; }

        public int TransactionId { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}