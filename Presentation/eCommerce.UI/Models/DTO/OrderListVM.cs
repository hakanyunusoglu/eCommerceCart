namespace eCommerce.UI.Models.DTO
{
    public class OrderListVM
    {
        public string? OrderNumber { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }
        public List<OrderItemVM> OrderItems { get; set; }

        public decimal TotalPrice()
        {
            return OrderItems.Sum(x => x.Price * x.Quantity);
        }
    }
    public class OrderItemVM
    {
        public Guid ID { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }

    }
}
