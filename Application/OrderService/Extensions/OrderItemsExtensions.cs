namespace OrderService.Extensions
{
    using OrderService.Data.Dto;
    using OrderService.Models;
    using OrderService.Models.Interfaces;

    public static class OrderItemsExtensions
    {
        public static OrderItemDto ToDto(this OrderItem order) => new OrderItemDto
        {
            Quantity = order.Quantity,
            ProductId = order.ProductId
        };
    }
}