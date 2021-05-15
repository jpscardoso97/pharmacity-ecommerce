namespace OrderService.Models
{
    public enum OrderStatus
    {
        PendingPayment = 0,
        Processing = 1,
        Shipped = 2,
        Delivered = 3,
        Canceled = 4,
        Returned = 5
    }
}