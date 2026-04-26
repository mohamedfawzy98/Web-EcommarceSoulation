namespace Domain.Model.Orders
{
    public class ProductItemOrder
    {
        public int ProductId { get; set; }
        public string PrpductName { get; set; } = default!;
        public string? PictureUrl { get; set; }
    }
}