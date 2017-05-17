using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HWBudgetTrackerV1.Models
{
    public class Household
    {
        public Household()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Budgets = new HashSet<Budget>();
            this.Categories = new HashSet<Category>();
            this.FinancialAccounts = new HashSet<FinancialAccounts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        
        public int CategoryId { get; set; }
        public int BudgetId { get; set; }
        public string UserId { get; set; }
        public int AccountId { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<FinancialAccounts> FinancialAccounts { get; set; }
    }
}