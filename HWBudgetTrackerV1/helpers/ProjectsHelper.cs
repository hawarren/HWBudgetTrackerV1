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
 * Determine whether a user is assigned to a particular project
 * Get a list of users on a certain project
 * List Households to which a user is assigned
 */
namespace BugTrackerV3.helpers
{
    public class HouseholdsHelper
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<ApplicationUser> HouseholdUsersByRole(int projectId, string role)
        {
            UserRolesHelper uHelper = new UserRolesHelper();
            var users = uHelper.UsersInRole(role);
            return users.Where(m => m.Households.Select(p => p.Id).Contains(projectId)).ToList();
        }

        public bool IsUserOnHousehold(string userId, int projectId)
        {
            var project = db.Households.Find(projectId);
            var flag = project.Users.Any(u => u.Id == userId);
            return (flag);
        }

        public ICollection<Household> ListUserHouseholds(string userId)
        {
            ApplicationUser user = db.Users.Find(userId);

            var Households = user.Households.ToList();
            return (Households);
            
        }
        public void AddUserToHousehold(string userId, int projectId)
        {
            if (!IsUserOnHousehold(userId, projectId))
            {
                Household proj = db.Households.Find(projectId);
                var newUser = db.Users.Find(userId);
               
                proj.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        public void RemoveUserFromHousehold(string userId, int projectId)
        {
            if(IsUserOnHousehold(userId, projectId))
                {
                Household proj = db.Households.Find(projectId);
                var delUser = db.Users.Find(userId);

                proj.Users.Remove(delUser);
                db.Entry(proj).State = EntityState.Modified; //just saves this obj instance
                db.SaveChanges();
                }
        }

        public ICollection<ApplicationUser> ListUsersOnHousehold(int projectId)
        {
            return db.Households.Find(projectId).Users;   
        }

        public ICollection<ApplicationUser> ListUsersNotOnHousehold(int projectId)
        {
            return db.Users.Where(u => u.Households.All(p => p.Id != projectId)).ToList();
        }

    }
}