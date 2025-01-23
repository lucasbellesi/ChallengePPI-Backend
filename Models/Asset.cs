namespace ChallengePPI.Backend.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string Ticker { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int AssetType { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
