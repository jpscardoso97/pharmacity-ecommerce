namespace ApiGateway.Models
{
    public class Customer
    {
        public Cart Cart { get; set; }
        
        public Wishlist Wishlist { get; set; }

        public AddressInfo AddressInfo { get; set; }
    }
}