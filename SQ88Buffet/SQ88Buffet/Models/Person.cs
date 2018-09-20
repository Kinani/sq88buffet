using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQ88Buffet.Models
{
    [Table("Person")]
    public class Person
    {
        [PrimaryKey][AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public float Balance { get; set; }
        public DateTime LastBilled { get; set; }
    }
}
