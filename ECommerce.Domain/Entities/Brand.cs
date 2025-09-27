using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Brand:BaseEntity
    {
        public List<Product> Products { get; set; }
        public Brand() 
        {
            Products = new List<Product>();
        }
    }
}
