using CloudCustomers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCustomers.UnitTests.Fixtures
{
    public class UsersFixture
    {
        public static List<User> GetTestUsers() => new() {
                new User
                {
                    Name = "Test User 1",
                    Email = "testuser1@example.com",
                    Address = new Address()
                    {
                        Street ="123 Main St",
                        City = "Madison",
                        ZipCode = "53704"
                    }
                },
                new User
                {
                    Name = "Test User 1",
                    Email = "testuser3@example.com",
                    Address = new Address()
                    {
                        Street ="123 Main St",
                        City = "Madison",
                        ZipCode = "53704"
                    }
                },
                new User
                {
                    Name = "Test User 2",
                    Email = "testuser2@example.com",
                    Address = new Address()
                    {
                        Street ="123 Main St",
                        City = "Madison",
                        ZipCode = "53704"
                    }
                }
        };
    }
}
