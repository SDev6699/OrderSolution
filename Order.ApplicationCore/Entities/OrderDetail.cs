using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Order.ApplicationCore.Entities
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        
        public int ProductId { get; set; }
        
        public string ProductName { get; set; }
        
        public int Qty { get; set; }
        
        public decimal Price { get; set; }
        
        public decimal Discount { get; set; }
        
        // Navigation property – each detail belongs to one order
        [JsonIgnore]
        public Order Order { get; set; }
    }
}