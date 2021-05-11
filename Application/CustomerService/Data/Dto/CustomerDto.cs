namespace CustomerService.Data.Dto
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Customers")]
    public class CustomerDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string CustomerId { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string DiscountCard { get; set; }
        
        public string CartId { get; set; }
    }
}