namespace PrescriptionService.Data.Dto
{
    using MongoDB.Bson;

    public class PrescriptionDto
    {
        public ObjectId Id { get; set; }
        
        public string Number { get; set; }
        
        public string AccessCode { get; set; }
        
        public string OptionCode { get; set; }
        
        public string Attachment { get; set; }
        
        public string Comments { get; set; }

        public string OrderId { get; set; }
    }
}