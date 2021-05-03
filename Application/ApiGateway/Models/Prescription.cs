namespace ApiGateway.Models
{
    public class Prescription
    {
        public string Number { get; set; }
        
        public string AccessCode { get; set; }
        
        public string OptionCode { get; set; }
        
        public string Attachment { get; set; }
        
        public string Comments { get; set; }
    }
}