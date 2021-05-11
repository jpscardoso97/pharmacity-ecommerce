namespace ShoppingCartService.Data.Dto
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Carts")]
    public class CartDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        public string CartId { get; set; }
        
        public string[] ProductIds { get; set; }
        
        public string OrderId { get; set; }
    }
}