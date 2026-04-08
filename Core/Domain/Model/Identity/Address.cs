namespace Domain.Model.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string FName { get; set; } = default!;
        public string LName { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string? street { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }
        public string? ApplicationUserId { get; set; }
    }
}