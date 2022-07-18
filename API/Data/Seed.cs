using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            // if there are user seed data already, then can exit
            if (await context.Users.AnyAsync()) return;

            // read from the json seed data
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");

            // need to deserialize the json string data into a list of objects
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            foreach (var user in users)
            {
                // need to create new users given the number of user objects extracted
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                // use a static password for development purposes, easy to test/login with in development
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;

                // track the users in EF
                context.Users.Add(user);
            }

            // save the changes to the DB
            await context.SaveChangesAsync();
        }
    }
}