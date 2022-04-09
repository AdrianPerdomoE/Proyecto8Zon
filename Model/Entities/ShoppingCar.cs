using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Entities
{
    public class ShoppingCar
    {
        public Structures.LinkedList<Product> Products { get;}

        public ShoppingCar()
        {
            Products = new Structures.LinkedList<Product>();
        }
        public double Total { get 
            { 
                double total = 0;
                for (int i = 0; i < Products.Size; i++)
                {
                    total += Products.Get(i).Price;
                }
                return total;
            } 
        }
    }
}
