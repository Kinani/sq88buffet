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
        public int Quantity { get; set; }
        public float Price { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
