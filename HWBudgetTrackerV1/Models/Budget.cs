using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HWBudgetTrackerV1.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int HouseholdId { get; set; }

        public virtual Household Household { get; set; }
    }
}