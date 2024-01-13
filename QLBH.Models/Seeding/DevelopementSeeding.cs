using Microsoft.Extensions.Configuration;
using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Seeding
{
    public partial class DataSeeding
    {
        public static void DevelopementSeeding(AppDbContext dbContext,IConfiguration configuration)
        {
            DataSeedingRole(dbContext);
            DataSeedingStatusBill(dbContext);
            DataSeedingEmail(dbContext);
        }
    }
}
