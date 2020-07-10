using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Entity
{
    public class Product:BaseEntity
    {
        public decimal Price { set; get; }

        public virtual Category  Category { get; set; }

    }
}
