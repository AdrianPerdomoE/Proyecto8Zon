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
        private MyLinkedList<ItemCarrito> Products;

        public ShoppingCar()
        {
            Products = new MyLinkedList<ItemCarrito>();
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
        public void sacarItem(int index, int cantidad)
        {
            ItemCarrito item = Products.Get(index);
            if(item.Cantidad == cantidad)
            {
                EliminarItem(index);
                return;
            }
            item.Cantidad -= cantidad;
        }
        public void EliminarItem(int index)
        {
            Products.Remove(index);
        }
        public double Total()
        {
            double total = 0;
            for(int i = 0; i < Products.GetSize(); i++)
            {
                total += Products.Get(i).SubTotal();
            }
            return total;
        }
        public override string ToString()
        {
            return $"Total a pagar: {Total()}$\nProductos en el carrito:\n{Products.ToString()}";
        }
        public bool IsEmpty()
        {
            return Products.IsEmpty();
        }
        public void Vaciar()
        {
            Products = new();
        }

        public int GetSize()
        {
            return Products.GetSize();
        }
        public int CantidadItem(int index)
        {
            return Products.Get(index).Cantidad;
        }
    }
}
