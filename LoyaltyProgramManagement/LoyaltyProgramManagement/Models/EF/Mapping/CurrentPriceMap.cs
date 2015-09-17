using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LoyaltyProgramManagement.Models.Mapping
{
    public class CurrentPriceMap : EntityTypeConfiguration<CurrentPrice>
    {
        public CurrentPriceMap()
        {
            // Primary Key
            this.HasKey(t => t.ItemId);

            // Properties
            this.Property(t => t.Barcode)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.TillDescription)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("CurrentPrices");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.Barcode).HasColumnName("Barcode");
            this.Property(t => t.RegularPrice).HasColumnName("RegularPrice");
            this.Property(t => t.OfferPrice).HasColumnName("OfferPrice");
            this.Property(t => t.TillDescription).HasColumnName("TillDescription");
            this.Property(t => t.Image).HasColumnName("Image");
        }
    }
}
