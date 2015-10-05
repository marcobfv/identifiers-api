using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentifiersApi2.Models
{
    public class IdentifiersContext : DbContext
    {
        public IdentifiersContext() : base("IdentifiersDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<IdentifiersContext, Migrations.Configuration>("IdentifiersDB"));
        }

        public DbSet<TagModel> Tags { get; set; }
    }
}