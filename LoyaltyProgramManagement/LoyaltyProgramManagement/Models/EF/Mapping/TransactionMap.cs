using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LoyaltyProgramManagement.Models.Mapping
{
    public class TransactionMap : EntityTypeConfiguration<Transaction>
    {
        public TransactionMap()
        {
            // Primary Key
            this.HasKey(t => t.TransactionId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Transactions");
            this.Property(t => t.TransactionId).HasColumnName("TransactionId");
            this.Property(t => t.MemberId).HasColumnName("MemberId");
            this.Property(t => t.TotalPrice).HasColumnName("TotalPrice");
            this.Property(t => t.PurchaseDate).HasColumnName("PurchaseDate");

            // Relationships
            this.HasOptional(t => t.Member)
                .WithMany(t => t.Transactions)
                .HasForeignKey(d => d.MemberId);

        }
    }
}
