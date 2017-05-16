using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HWBudgetTrackerV1.Models
{
    public class Category
    {
        public Category()
        {
            this.Households = new HashSet<Household>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public int HouseholdId { get; set; }

        public virtual ICollection<Household> Households { get; set; }
    }
}