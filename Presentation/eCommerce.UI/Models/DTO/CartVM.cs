namespace eCommerce.UI.Models.DTO
{
    public class CartVM
    {
        public Guid ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid userID { get; set; }
        public decimal TotalPrice()
        {
            return CartItemList.Sum(x => x.Price * x.Quantity);

        }

        public List<CartItemModel> CartItemList { get; set; }
    }
    public class CartItemModel
    {
        public Guid ID { get; set; }
        public Guid productID { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
