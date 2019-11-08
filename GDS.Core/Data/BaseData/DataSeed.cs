using GDS.Core.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Data.BaseData
{
    public class DataSeed
    {
        public void SeedUser()
        {
            var users = new List<User>()
            {
                new User { Id = 1, Gid = Guid.NewGuid().ToString(), Username = "Admin", Password = "GgjIhLN2YhnVvyr///sCFRdKixLHWFwho8o+qNMahzN8FFJS", Email = "admin@wirelessminsisteringevents.co.za"}
            };
        }
    }
}