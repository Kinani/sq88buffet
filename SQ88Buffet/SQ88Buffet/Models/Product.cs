using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQ88Buffet.Models
{
    [Table("Product")]
    public class Product
    {
        [PrimaryKey][AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string Category { get; set; }
        public int UnitsOfProduct { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
