using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Entities
{
    public class ItemCarrito
    {
        public Product Producto { get;}
        public int Cantidad { get; set;}
        
        public ItemCarrito(Product product, int cantidad)
        {
            Producto = product;
            
            Cantidad = cantidad;
        }
    }
}
