using System.Data.Entity;
using test_sql.EF_entities;

namespace test_sql.Data
{

    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Tool_User> Tool_Users { get; set; }

        public Context() : base ("DbConnectionLocalhost")
        {
            //Database.Connection.ConnectionString = 
        }

    }
}