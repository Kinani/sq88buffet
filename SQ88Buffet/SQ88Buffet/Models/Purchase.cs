using SQLite.Net.Attributes;
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
        public int UnitsOfProduct { get; set; }
        public float PurchaseValue { get; set; }
        public bool Billed { get; set; } = false;
        public DateTime PurchaseDate { get; } = DateTime.Now;
    }
}
