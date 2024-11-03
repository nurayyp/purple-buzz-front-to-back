namespace WebApplication1.Entities
{
    public class PricingOption : BaseEntity
    {
        public string IconURL { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Info { get; set; }
        public string Buy { get; set; }
    }
}
