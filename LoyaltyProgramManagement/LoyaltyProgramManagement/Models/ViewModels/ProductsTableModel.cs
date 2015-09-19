using System.Collections.Generic;

namespace LoyaltyProgramManagement.Models.ViewModels
{
    public class ProductsTableModel
    {
        public string Description { get; set; }
        public string Barcode { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}