using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QLBH.Commons;
using QLBH.Models.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static QLBH.Commons.Enums;

namespace QLBH.Models.Seeding
{
    public partial class DataSeeding
    {
        public static void DataSeedingRole(AppDbContext dbContext)
        {
            if (!dbContext.Role.Any())
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    dbContext.Role.AddRange(GenerateRole());
                    dbContext.Database.ExecuteSqlRaw(string.Format(Common_Constants.SQLRaw.SET_IDENTITY_INSERT_ON, nameof(Role)));
                    dbContext.SaveChanges();
                    dbContext.Database.ExecuteSqlRaw(string.Format(Common_Constants.SQLRaw.SET_IDENTITY_INSERT_OFF, nameof(Role)));
                    transaction.Commit();
                }
            }
        }
        public static List<Role> GenerateRole()
        {
            return new List<Role>
            {
                new Role
                {
                    ID = 1,
                    Role_ID = 100,
                    Role_Name = "Admin"
                },
                new Role
                {
                    ID = 2,
                    Role_ID = 200,
                    Role_Name = "User"
                },
                new Role
                {
                    ID = 3,
                    Role_ID = 201,
                    Role_Name = "Guest"
                },
                new Role
                {
                    ID = 4,
                    Role_ID = 300,
                    Role_Name = "Moderator"
                },
                new Role
                {
                    ID = 5,
                    Role_ID = 301,
                    Role_Name = "Editor"
                },
                new Role
                {
                    ID = 6,
                    Role_ID = 302,
                    Role_Name = "Manager"
                },
                new Role
                {
                    ID = 7,
                    Role_ID = 400,
                    Role_Name = "Superuser"
                }
            };

        }
    }
}
