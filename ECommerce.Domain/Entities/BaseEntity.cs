using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class BaseEntity
    {
        [Required]
        [Key]
        //remove auto increment
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]// إنت اللي تدخل الـ Id من الـ JSON أوswagger
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string Name { get; set; }
    }
}
