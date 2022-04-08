namespace eCommerce.UI.Models.DTO
{
    public class OrderVM
    {
        public string? OrderNumber { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }

        public CartVM? CartModel { get; set; }

    }
}
