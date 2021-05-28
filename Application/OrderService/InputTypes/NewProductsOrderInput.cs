namespace OrderService.InputTypes
{
    using OrderService.Models;
    using OrderService.Models.Interfaces;

    public class NewProductsOrderInput
    {
        public ProductsOrder Order { get; set; }
        
        public string CartId { get; set; }
    }
}