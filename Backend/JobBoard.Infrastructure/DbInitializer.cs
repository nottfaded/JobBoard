using JobBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Infrastructure;

public static class DbInitializer
{
    public static void Seed(JobBoardDbContext context)
    {
        //context.Database.Migrate();

        if (!context.Admins.Any())
        {
            context.Admins.Add(new Admin
            {
                Email = "a@a",
                Password = "123"
            });
        }

        if (!context.Companies.Any())
        {
            context.Companies.Add(new Company
            {
                Email = "c@c",
                Password = "123",
                Name = "Default Company"
            });
        }
        if (!context.Users.Any())
        {
            context.Users.Add(new User
            {
                Email = "u@u",
                Password = "123",
                FirstName = "Default",
                LastName = "User"
            });
        }

        context.SaveChanges();
    }
}