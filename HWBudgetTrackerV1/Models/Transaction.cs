using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HWBudgetTrackerV1.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Date { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }

        public int Reconciled { get; set; }
        public int ReconciledAmount { get; set; }

        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public string EnteredById { get; set; }
        
        public virtual Account Account { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser EnteredBy { get; set; }

    }
}