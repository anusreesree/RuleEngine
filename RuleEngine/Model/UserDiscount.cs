namespace RuleEngine.Model
{
    public class UserDiscount
    {
        public required string UserLevel { get; set; }

        public decimal PurchaseAmount { get; set; }

        public  string DiscountMessage { get; set; } = string.Empty;
    }
}
