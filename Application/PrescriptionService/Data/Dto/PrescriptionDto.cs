namespace PrescriptionService.Data.Dto
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        
        public string Number { get; set; }
        
        public string AccessCode { get; set; }
        
        public string OptionCode { get; set; }
        
        public string Attachment { get; set; }
        
        public string Comments { get; set; }

        public string OrderId { get; set; }
    }
}