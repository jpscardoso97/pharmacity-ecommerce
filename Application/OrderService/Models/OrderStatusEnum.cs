namespace OrderService.Models
{
    using System;

    public enum OrderStatusEnum
    {
        PendingPayment = 0,
        Processing = 1,
        Shipped = 2,
        Delivered = 3,
        Canceled = 4,
        Returned = 5
    }

    public static class OrderStatusHelper
    {
        public static string GetEnumValue(this OrderStatusEnum statusEnum)
        {
            switch (statusEnum)
            {
                case OrderStatusEnum.PendingPayment:
                    return "Pending Payment";
                case OrderStatusEnum.Processing:
                    return "Processing";
                case OrderStatusEnum.Shipped:
                    return "Shipped";
                case OrderStatusEnum.Delivered:
                    return "Delivered";
                case OrderStatusEnum.Canceled:
                    return "Canceled";
                case OrderStatusEnum.Returned:
                    return "Returned";
                default:
                    throw new ArgumentException("Invalid status found");
            }
        }

        public static OrderStatusEnum ToEnum(string status)
        {
            switch (status.ToLowerInvariant())
            {
                case "pending payment":
                    return OrderStatusEnum.PendingPayment;
                case "processing":
                    return OrderStatusEnum.Processing;
                case "shipped":
                    return OrderStatusEnum.Shipped;
                case "delivered":
                    return OrderStatusEnum.Delivered;
                case "canceled":
                    return OrderStatusEnum.Canceled;
                case "returned":
                    return OrderStatusEnum.Returned;
                default:
                    throw new ArgumentException("Invalid status found");
            }
        }
    }
}