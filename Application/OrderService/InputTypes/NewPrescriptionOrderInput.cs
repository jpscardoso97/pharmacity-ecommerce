namespace OrderService.InputTypes
{
    using OrderService.Models;

    public class NewPrescriptionOrderInput
    {
        public PrescriptionOrder Order { get; set; }

        public string CartId { get; set; }
    }
}