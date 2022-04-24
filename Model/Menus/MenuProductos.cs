using Proyecto8Zon.Model.Entities;
using Proyecto8Zon.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Menus
{
    internal class MenuProductos : Menu
    {
        MyLinkedList<Comprador> ListaCompradores;
        MyLinkedList<Vendedor> ListaVendedores;
        MyLinkedList<Product> ListaProductosDisplay;
        public MenuProductos(MyLinkedList<Comprador> listaCompradores, MyLinkedList<Vendedor> listaVendedores)
        {
            ListaVendedores = listaVendedores;  
            ListaCompradores = listaCompradores;
            FiltrarProductos();
            bool seguirMenuProductos =true;
            while (seguirMenuProductos)
            {
                Console.Clear();
                if (ListaProductosDisplay.IsEmpty())
                {
                    Console.WriteLine("No hay productos registrados");
                }
                else
                {
                    Console.WriteLine(ListaProductosDisplay);
                }
                int OpcionMenuProductos = ObtenerOpcionMenu("Ingrese 1 si desea filtrar los productos por una caracteristica\nIngrese 2 si desea selecionar un producto\nIngrese 0 para salir del menu de productos", 2);
                switch (OpcionMenuProductos)
                {
                    case 1:
                        Console.Clear();
                        string caracteristica = ObtenerEntrada("Ingrese la caracteristica por la cual desea filtrar los productos");
                        FiltrarProductos(caracteristica);
                        break;
                    case 2:
                        Console.Clear();
                        if (ListaProductosDisplay.IsEmpty())
                        {
                            Console.WriteLine("No hay productos disponibles por selecionar");
                            Console.ReadLine();
                            break;
                        }
                        int numeroProducto = ObtenerOpcionMenu("ingrese # del producto que desea selecionar",ListaProductosDisplay.GetSize()-1);
                        AñadirProductoACarrito(ListaProductosDisplay.Get(numeroProducto));
                        break;
                    case 0:
                        seguirMenuProductos = false;    
                        break;
                }
            }
        }
        private void AñadirProductoACarrito(Product product)
        {
            Console.Clear();
            if (ListaCompradores.IsEmpty())
            {
                Console.WriteLine("No hay compradores registrados para ingresar a su carrito de compra");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            Console.WriteLine(ListaCompradores.ToString());
            int CompradorElegido = ObtenerOpcionMenu("Ingrese # del comprador al que va a añadir el producto al carrito de compra", ListaCompradores.GetSize() - 1);
            Console.Clear();
            Console.WriteLine("Ingrese la cantidad del producto que va a ingresar al carrito");
            int cantidad = ObtenerEntradaInt();
            while (cantidad < 0)
            {
                Console.Clear();
                Console.WriteLine("Valor ingresado no valido");
                Console.WriteLine("Ingrese la cantidad del producto que va a ingresar al carrito");
                cantidad = ObtenerEntradaInt();
            }
            Comprador comprador = ListaCompradores.Get(CompradorElegido);
            comprador.CarritoCompra.AñadirItem(product, cantidad);
            Console.WriteLine("Producto añadido correctamente al carrito de compra");
            Console.ReadLine();
        }
        public void FiltrarProductos()
        {
            MyLinkedList<Product> NuevaLista = new MyLinkedList<Product>();
            for(int vendedor = 0; vendedor < ListaVendedores.GetSize(); vendedor++)
            {
                Vendedor vendedorActual = ListaVendedores.Get(vendedor);
                for(int item = 0; item < vendedorActual.Catalogo.GetSize(); item++)
                {
                    Product producto = vendedorActual.Catalogo.GetProduct(item);
                    NuevaLista.Add(producto);   
                }
            }
            ListaProductosDisplay = NuevaLista;
        }
        public void FiltrarProductos(string Caracteristica)
        {
            MyLinkedList<Product> NuevaLista = new MyLinkedList<Product>();
            for (int vendedor = 0; vendedor < ListaVendedores.GetSize(); vendedor++)
            {
                Vendedor vendedorActual = ListaVendedores.Get(vendedor);
                for (int item = 0; item < vendedorActual.Catalogo.GetSize(); item++)
                {
                    Product producto = vendedorActual.Catalogo.GetProduct(item);
                    for(int Caract = 0; Caract < producto.Features.GetSize(); Caract++)
                    {
                        if(producto.Features.Get(Caract) == Caracteristica)
                        {
                            NuevaLista.Add(producto);
                            break;
                        }
                    }
                }
            }
            ListaProductosDisplay = NuevaLista;
        }
    }
}
