namespace HWBudgetTrackerV1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HWBudgetTrackerV1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HWBudgetTrackerV1.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //seeding hanifwarren as the admin
            var userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "hanifwarren@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "hanifwarren",
                    Email = "hanifwarren@gmail.com",
                    FirstName = "Hanif",
                    LastName = "Warren",
                    DisplayName = "Hanif Warren"
                }, "12345678");


                //testusers 
                if (!context.Users.Any(u => u.Email == "testuser1@btracker.com"))
                {
                    userManager.Create(new ApplicationUser
                    {
                        UserName = "testuser1@btracker.com",
                        Email = "testuser1@btracker.com",
                        FirstName = "Test1",
                        LastName = "User1",
                        DisplayName = "Imatest1"
                    }, "Abc&123!");
                }

                //adding all roles to dummyPM except Admin
                var userIdt1 = userManager.FindByEmail("testuser1@btracker.com").Id;
                //userManager.AddToRole(userIdt1, "Submitter");



                if (!context.Users.Any(u => u.Email == "testuser2@btracker.com"))
                {

                    userManager.Create(new ApplicationUser
                    {
                        UserName = "testuser2@btracker.com",
                        Email = "testuser2@btracker.com",
                        FirstName = "Test2",
                        LastName = "User2",
                        DisplayName = "Imatest2"
                    }, "Abc&123!");
                }
                var userIdt2 = userManager.FindByEmail("testuser2@btracker.com").Id;
                //userManager.AddToRole(userIdt2, "Submitter");

                if (!context.Users.Any(u => u.Email == "testuser3@btracker.com"))
                {

                    userManager.Create(new ApplicationUser
                    {
                        UserName = "testuser3@btracker.com",
                        Email = "testuser3@btracker.com",
                        FirstName = "Test3",
                        LastName = "User3",
                        DisplayName = "Imatest3"
                    }, "Abc&123!");
                }
                var userIdt3 = userManager.FindByEmail("testuser3@btracker.com").Id;
                //userManager.AddToRole(userIdt3, "Submitter");

                if (!context.Users.Any(u => u.Email == "testuser4@btracker.com"))
                {

                    userManager.Create(new ApplicationUser
                    {
                        UserName = "testuser4@btracker.com",
                        Email = "testuser4@btracker.com",
                        FirstName = "Test4",
                        LastName = "User4",
                        DisplayName = "Imatest4"
                    }, "Abc&123!");
                }
                var userIdt4 = userManager.FindByEmail("testuser4@btracker.com").Id;
                //userManager.AddToRole(userIdt4, "Submitter");

                if (!context.Users.Any(u => u.Email == "testuser5@btracker.com"))
                {

                    userManager.Create(new ApplicationUser
                    {
                        UserName = "testuser5@btracker.com",
                        Email = "testuser5@btracker.com",
                        FirstName = "Test5",
                        LastName = "User5",
                        DisplayName = "Imatest5"
                    }, "Abc&123!");
                }
                var userIdt5 = userManager.FindByEmail("testuser5@btracker.com").Id;
               // userManager.AddToRole(userIdt5, "Submitter");

                if (!context.Users.Any(u => u.Email == "testuser6@btracker.com"))
                {

                    userManager.Create(new ApplicationUser
                    {
                        UserName = "testuser6@btracker.com",
                        Email = "testuser6@btracker.com",
                        FirstName = "Test6",
                        LastName = "User6",
                        DisplayName = "Imatest6"
                    }, "Abc&123!");
                }
                var userIdt6 = userManager.FindByEmail("testuser6@btracker.com").Id;
                //userManager.AddToRole(userIdt6, "Submitter");

            }





        }
    }
}
