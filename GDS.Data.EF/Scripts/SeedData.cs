using GDS.Core.Models;
using GDS.Data.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDS.Data.EF.Scripts
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var ctx = new GDSContext(serviceProvider.GetRequiredService<DbContextOptions<GDSContext>>()))
            {
                if (ctx.Objects.Any())
                {
                    return;
                }

                ctx.Objects.AddRange(
                    new ObjectModel
                    {
                        Name = "God",
                        Username = "Admin",
                        Class = Core.Models.Enums.ObjectClass.SpiritualBeing
                    }

                    );
                ctx.SaveChanges();
            }
        }
    }
}