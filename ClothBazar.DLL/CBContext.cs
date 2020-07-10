using ClothBazar.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.DLL
{
    public class CBContext:DbContext
    {
        public CBContext():base("ClothBazarConnection")
        {

        }
        public DbSet<Product> Products { set; get; }
        public DbSet<Category> Categories { get; set; }
    }
}
