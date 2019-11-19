using GDS.Core.Models.Administration;
using GDS.Core.Models.Bibles;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Data.BaseData
{
    public static class DataSeed
    {
        public static List<User> SeedUser()
        {
            return new List<User>()
            {
                new User { Id = 1, Gid = Guid.NewGuid().ToString(), Username = "Admin", Password = "GgjIhLN2YhnVvyr///sCFRdKixLHWFwho8o+qNMahzN8FFJS", Email = "admin@wirelessminsisteringevents.co.za"}
            };
        }

        public static IEnumerable<Book> SeedBook()
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Verse> SeedVerse()
        {
            throw new NotImplementedException();
        }

        public static List<Translation> SeedTranslation()
        {
            return new List<Translation>()
            {
                new Translation{ Id =1, Title="King James Version", Code="KJV", HasStrongs = true}
            };
        }
    }
}