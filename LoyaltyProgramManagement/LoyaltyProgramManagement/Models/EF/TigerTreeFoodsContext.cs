using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LoyaltyProgramManagement.Models.Mapping;

namespace LoyaltyProgramManagement.Models
{
    public partial class TigerTreeFoodsContext : DbContext
    {
        static TigerTreeFoodsContext()
        {
            Database.SetInitializer<TigerTreeFoodsContext>(null);
        }

        public TigerTreeFoodsContext()
            : base("Name=TigerTreeFoodsContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new MemberMap());
            modelBuilder.Configurations.Add(new TransactionMap());
        }
    }
}
