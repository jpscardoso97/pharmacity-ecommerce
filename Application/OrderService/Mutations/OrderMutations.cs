namespace OrderService.Mutations
{
    using System;
    using System.Threading.Tasks;
    using HotChocolate;
    using HotChocolate.Types;
    using OrderService.Models;
    using OrderService.Models.Interfaces;
    using OrderService.Resolvers;

    
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class OrderMutations
    {
        public async Task<ProductsOrder> CreateProductsOrder([Service] OrdersResolver resolver, ProductsOrder order)
        {
            if (!ValidateOrder(order))
            {
                throw new ArgumentException("Invalid order");
            }

            return await resolver.CreateProductsOrder(order);
        }
        
        public async Task<PrescriptionOrder> CreatePrescriptionOrder([Service] OrdersResolver resolver, PrescriptionOrder order)
        {
            if (!ValidateOrder(order))
            {
                throw new ArgumentException("Invalid order");
            }

            return await resolver.CreatePrescriptionOrder(order);
        }

        private bool ValidateOrder(IOrder order)
        {
            if (string.IsNullOrWhiteSpace(order.Date) ||
                string.IsNullOrWhiteSpace(order.Value) ||
                string.IsNullOrWhiteSpace(order.PaymentId))
            {
                return false;
            }

            switch (order)
            {
                case PrescriptionOrder prescriptionOrder
                    when string.IsNullOrWhiteSpace(prescriptionOrder.PrescriptionId):
                    return false;
                case ProductsOrder productsOrder when productsOrder.Items?.Length == 0:
                    return false;
            }

            return true;
        }
    }
}