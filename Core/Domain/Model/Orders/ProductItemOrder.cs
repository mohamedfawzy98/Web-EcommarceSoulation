namespace Domain.Model.Orders
{
    public class ProductItemOrder
    {
        public ProductItemOrder(int productId, string prpductName, string? pictureUrl)
        {
            ProductId = productId;
            PrpductName = prpductName;
            PictureUrl = pictureUrl;
        }
        public ProductItemOrder()
        {
            
        }
        public int ProductId { get; set; }
        public string PrpductName { get; set; } = default!;
        public string? PictureUrl { get; set; }
    }
}