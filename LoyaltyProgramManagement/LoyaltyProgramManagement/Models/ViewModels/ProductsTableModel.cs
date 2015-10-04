using System.Collections.Generic;
using System.ComponentModel;

namespace LoyaltyProgramManagement.Models.ViewModels
{
    public class ProductsTableModel
    {
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Category")]
        public string Category { get; set; }
        [DisplayName("Barcode")]
        public string Barcode { get; set; }
        [DisplayName("Products")]
        public List<ProductModel> Products { get; set; }
    }
}