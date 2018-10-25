using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQ88Buffet.Models
{
    [Table("Purchase")]
    public class Purchase
    {
        [PrimaryKey][AutoIncrement]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ProductId { get; set; }
        public decimal ProductQuantity { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int UnitsOfProduct { get; set; }
        public decimal PurchaseValue { get; set; }
        public bool IsCompleted { get; set; }
        public bool Billed { get; set; } 
        public DateTime PurchaseDate { get; set; } 
    }
}
