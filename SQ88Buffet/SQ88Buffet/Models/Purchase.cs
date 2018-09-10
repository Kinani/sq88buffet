using SQLite;
using SQLiteNetExtensions.Attributes;
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
        [ForeignKey(typeof(Person))]
        public int PersonId { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Product> Products { get; set; }
    }
}
