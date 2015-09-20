using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LoyaltyProgramManagement.Models.Mapping
{
    public class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            // Primary Key
            this.HasKey(t => t.MemberId);

            // Properties
            this.Property(t => t.MembershipCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.Address1)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address2)
                .HasMaxLength(50);

            this.Property(t => t.PostCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Members");
            this.Property(t => t.MemberId).HasColumnName("MemberId");
            this.Property(t => t.MembershipCode).HasColumnName("MembershipCode");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.PostCode).HasColumnName("PostCode");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.FavouriteProductId).HasColumnName("FavouriteProductId");

            // Relationships
            this.HasRequired(t => t.FavouriteProduct)
                .WithMany(t => t.Members)
                .HasForeignKey(d => d.FavouriteProductId);

        }
    }
}
