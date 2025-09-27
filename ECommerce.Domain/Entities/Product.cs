using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Product: BaseEntity
    {
        public string? Description { get; set; }
        [Range(1,10000)]
        public decimal Price { get; set; }
        public string pictureurl { get; set; }=null!;
        public Brand Brand { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Type Type { get; set; }
        [ForeignKey("Type")]
        public int TypeId { get; set; }

    }

}
