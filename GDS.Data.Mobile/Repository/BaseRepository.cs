using GDS.Core.Models;
using GDS.Data.Mobile.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Data.Mobile.Repository
{
    public class BaseRepository<T> where T : BaseReader
    {
        protected readonly GDSContext context;
        private DbSet<T> entities;

        public BaseRepository(GDSContext context)
        {
            this.context = context;
        }

        protected DbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }
    }
}