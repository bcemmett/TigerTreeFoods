using System;

namespace PosTerminal
{
    class ShoppingItem
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; }
        public Decimal RegularPrice { get; set; }
        public Decimal? OfferPrice { get; set; }
        public string TillDescription { get; set; }
    }
}