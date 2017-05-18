using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HWBudgetTrackerV1.Models
{
    public class HouseholdHHViewModel
    {
        public Household Household { get; set; }
        //Head of household is just a user who happens to be the primary member of the household
        public ApplicationUser HOH { get; set; }
    }
}