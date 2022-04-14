using Proyecto8Zon.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Entities
{
    public class ShoppingCar
    {
        public MyLinkedList<ItemCarrito> Products { get;}

        public ShoppingCar()
        {
            Products = new MyLinkedList<ItemCarrito>();
        }
        public double Total { get 
            { 
                double total = 0;
                for (int i = 0; i < Products.GetSize(); i++)
                {
                    total += Products.Get(i).Producto.Price;
                }
                return total;
            } 
        }
        public  void AñadirItem(Product producto, int cantidad)
        {
            for (int  i = 0;  i < Products.GetSize();  i++)
            {
                if(Products.Get(i).Producto.Name == producto.Name)
                {
                    Products.Get(i).Cantidad += cantidad;
                    return;
                }
            }
            ItemCarrito nuevoItem = new ItemCarrito(producto, cantidad);
            Products.Add(nuevoItem);
        }
        public void sacarItem(Product producto, int cantidad)
        {
            for (int i = 0; i < Products.GetSize(); i++)
            {
                if (Products.Get(i).Producto.Name == producto.Name)
                {
                    Products.Get(i).Cantidad -= cantidad;
                    if(Products.Get(i).Cantidad == 0)
                    {
                        Products.Remove(i);
                    }
                    return;
                }
            }
        }
    }
}
