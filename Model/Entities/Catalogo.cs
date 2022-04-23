using Proyecto8Zon.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Entities
{
    public class Catalogo
    {
        private MyLinkedList<LinkedStack<Product>> Productos = new();
        
        private int Size = 0;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Productos del catalogo:");
            sb.Append(Productos.ToString());
            return sb.ToString();
        }
        public void AumentarExistenciaProducto(int cantidad, int index)
        {
            
            Product productoMuestra = Productos.Get(index).Peek();
            for (int j = 0; j < cantidad; j++)
            {
                Product productoExtra = new Product(productoMuestra.Name,productoMuestra.Price);
                for(int k = 0; k < productoMuestra.Features.GetSize(); k++)
                {
                    productoExtra.AddFeature(productoMuestra.Features.Get(k));
                }
                Productos.Get(index).Add(productoExtra);
            }
        }
        public void IngresarProducto(Product product)
        {
            for(int i = 0; i < Size; i++)
            {
               if(Productos.Get(i).Peek().Name == product.Name)
                {
                    Productos.Get(i).Add(product);
                    return;
                }
            }
            LinkedStack<Product> nuevaPilaProductos = new LinkedStack<Product>();
            nuevaPilaProductos.Add(product);
            Productos.Add(nuevaPilaProductos);
            Size++; 
        }
        public Product SacarProducto( int index)
        {
            Product producto = Productos.Get(index).Remove();
            if(Productos.Get(index).GetSize() == 0)
            {
                Productos.Remove(index);
                Size--;
            }
            return producto;
        }

        public MyLinkedList<Product> ProductosDelCatalogo()
        {
            MyLinkedList<Product> ProductosCatalogo = new MyLinkedList<Product>();
            for (int i = 0; i < Size; i++)
            {
                ProductosCatalogo.Add(Productos.Get(i).Peek());
            }
            return ProductosCatalogo;
        }
        
        public int GetSize()
        {
            return Size;
        }

        public void VerProducto(int index)
        {
            var pilaProductos = Productos.Get(index);

            Console.WriteLine($"Cantidad disponible: {pilaProductos.GetSize()} \nProducto:\n{pilaProductos.Peek().ToString()}");

        }
        public Product GetProduct(int index )
        {
           return Productos.Get(index).Peek();
        }
    }
}
