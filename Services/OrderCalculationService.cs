using ChallengePPI.Backend.Models;

namespace ChallengePPI.Backend.Services
{
    public class OrderCalculationService
    {
        public decimal CalculateTotal(Order order, Asset asset)
        {
            switch (asset.AssetType)
            {
                case 1: // Accion
                    return CalculateActionTotal(order.Quantity, asset.UnitPrice);
                case 2: // Bono
                    return CalculateBondTotal(order.Quantity, order.Price ?? 0);
                case 3: // FCI
                    return order.Quantity * order.Price ?? 0;
                default:
                    throw new ArgumentException("Invalid asset type.");
            }
        }

        private decimal CalculateActionTotal(int quantity, decimal price)
        {
            decimal total = quantity * price;
            decimal commission = total * 0.006m;
            decimal tax = commission * 0.21m;
            return total + commission + tax;
        }

        private decimal CalculateBondTotal(int quantity, decimal price)
        {
            decimal total = quantity * price;
            decimal commission = total * 0.002m;
            decimal tax = commission * 0.21m;
            return total + commission + tax;
        }
    }
}