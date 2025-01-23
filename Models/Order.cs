namespace ChallengePPI.Backend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal? Price { get; set; } // Nullable for assets with database-defined prices
        public char Operation { get; set; }
        public int Status { get; set; } = 0;
        public decimal TotalAmount { get; set; }
    }
}