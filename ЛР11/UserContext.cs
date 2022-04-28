using System.Data.Entity;

namespace ЛР11
{
    public class UserContext: DbContext
    {
        public UserContext() : base("DbConnection") { }
        public DbSet<User> Users { get; set; }
    }
}
