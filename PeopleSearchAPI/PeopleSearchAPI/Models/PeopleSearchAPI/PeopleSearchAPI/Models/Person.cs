using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearchAPI.Models
{
    public class Person
    {
        [Key]
        public int RecID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Age{ get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Interests { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        public string ImageUrl { get; set; }
    }
}
