using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using HWBudgetTrackerV1.Models;
using System.Data.Entity.Validation;


/* With the HouseholdsHelper class, methods exist to help you
 * Assign/Unassign users to Households
 * Determine whether a user is assigned to a particular household
 * Get a list of users on a certain household
 * List Households to which a user is assigned
 */
namespace BugTrackerV3.helpers
{
    public class HouseholdsHelper
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<ApplicationUser> HouseholdUsersByRole(int householdId, string role)
        {
            UserRolesHelper uHelper = new UserRolesHelper();
            var users = uHelper.UsersInRole(role);
            return users.Where(m => m.Households.Select(p => p.Id).Contains(householdId)).ToList();
        }

        public bool IsUserOnHousehold(string userId, int householdId)
        {
            var household = db.Households.Find(householdId);
            var flag = household.Users.Any(u => u.Id == userId);
            return (flag);
        }

        public ICollection<Household> ListUserHouseholds(string userId)
        {
            ApplicationUser user = db.Users.Find(userId);

            var Households = user.Households.ToList();
            return (Households);
            
        }
        public void AddUserToHousehold(string userId, int householdId)
        {
            if (!IsUserOnHousehold(userId, householdId))
            {
                Household proj = db.Households.Find(householdId);
                var newUser = db.Users.Find(userId);
               
                proj.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        public void RemoveUserFromHousehold(string userId, int householdId)
        {
            if(IsUserOnHousehold(userId, householdId))
                {
                Household proj = db.Households.Find(householdId);
                var delUser = db.Users.Find(userId);

                proj.Users.Remove(delUser);
                db.Entry(proj).State = EntityState.Modified; //just saves this obj instance
                db.SaveChanges();
                }
        }

        public ICollection<ApplicationUser> ListUsersOnHousehold(int householdId)
        {
            return db.Households.Find(householdId).Users;   
        }

        public ICollection<ApplicationUser> ListUsersNotOnHousehold(int householdId)
        {
            return db.Users.Where(u => u.Households.All(p => p.Id != householdId)).ToList();
        }

    }
}