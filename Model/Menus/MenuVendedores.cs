using Proyecto8Zon.Model.Entities;
using Proyecto8Zon.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Menus
{
    public class MenuVendedores : Menu
    {
        MyLinkedList<Vendedor> ListaVendedores;

        MyLinkedList<Comprador> ListaCompradores;
        public MenuVendedores(MyLinkedList<Vendedor> listaVendedores, MyLinkedList<Comprador> listaCompradores)
        {
            this.ListaVendedores = listaVendedores;

            this.ListaCompradores = listaCompradores;

            bool seguirMenuVendedores = true;

            while (seguirMenuVendedores)
            {
                Console.Clear();

                Console.WriteLine(ListaVendedores);

                int opcionMenuVendedores = ObtenerOpcionMenu("Ingrese 1 si desea agregar un vendedor\nIngrese 2 si desea editar un vendedor\nIngrese 0 si no desea seguir en la vista de vendedores", 2);

                switch (opcionMenuVendedores)
                {
                    case 0:
                        seguirMenuVendedores = false;
                        break;
                    case 1:
                        AgregarVendedor();
                        break;
                    case 2:
                        EditarVendedor();
                        break;
                }
            }
        }

        private void AgregarVendedor()
        {
            Console.Clear();

            string nombre = ObtenerEntrada("Ingrese nombre del vendedor");

            string id = ObtenerEntrada("Ingrese numero de identificacion del vendedor");

            Vendedor nuevoVendedor = new(nombre, id);

            ListaVendedores.Add(nuevoVendedor);
        }

        private void EditarVendedor()
        {
            Console.Clear();

            bool SeguirEditandoVendedor = true;

            if (ListaVendedores.IsEmpty())
            {
                Console.WriteLine("No hay vendedores registrados");
                Console.ReadLine();
             
                return;
            }

            int NumeroVendedor = ObtenerOpcionMenu("Ingrese el # del vendedor que desea editar", ListaVendedores.GetSize()-1);

            Vendedor vendedorActual = ListaVendedores.Get(NumeroVendedor);

            while (SeguirEditandoVendedor) 
            {
                Console.Clear();

                Console.WriteLine(vendedorActual);

                Console.WriteLine(vendedorActual.Catalogo.ToString());

                int OpcionEdicion = ObtenerOpcionMenu("Ingrese 1 si desea cambiar el nombre del vendedor\nIngrese 2 si desea cambiar el id del vendedor\nIngrese 3 si desea eliminar el vendedor\nIngrese 4 si desea añadir un producto al catalogo\nIngrese 5 si desea selecionar un producto\nIngrese 0 si desea salir del modo edición", 5);
                switch (OpcionEdicion)
                {
                    case 0:
                        SeguirEditandoVendedor = false;
                        break;
                    case 1:
                        Console.Clear();
                        string nuevoNombre = ObtenerEntrada("Ingrese el nuevo nombre del vendedor");
                        vendedorActual.Nombre = nuevoNombre;
                        break;
                    case 2:
                        Console.Clear();
                        string nuevoId = ObtenerEntrada("Ingrese el nuevo id del vendedor");
                        vendedorActual.Id = nuevoId;
                        break;
                    case 3:
                        Console.Clear();
                        ListaVendedores.Remove(NumeroVendedor);
                        SeguirEditandoVendedor = false;
                        break;
                    case 4:
                        AgregarProducto(vendedorActual);
                        break;
                    case 5:
                        SelecionarProducto(vendedorActual);
                        break;
                }
            }
                        
        }

        private void AgregarProducto(Vendedor vendedor)
        {
            Console.Clear();
            string nombre = ObtenerEntrada("Ingrese nombre del nuevo producto");
            Console.WriteLine("Ingrese precio del producto");
            double precio = ObtenerEntradaDouble();
            while (precio < 0)
            {
                Console.Clear();
                Console.WriteLine("Ingrese precio del producto");
                precio = ObtenerEntradaDouble();
            }
            Product nuevoProducto = new(nombre, precio);
            bool añadirCaract = true;
            while (añadirCaract)
            {
                Console.Clear();
                string nuevaCaracteristica = ObtenerEntrada("Ingrese caracteristica para el producto");
                nuevoProducto.AddFeature(nuevaCaracteristica);
                int decision = ObtenerOpcionMenu("Ingrese 0 si NO desea seguir añadiendo caracteristicas al producto, caso contrario ingrese 1", 1);
                if (decision == 0)
                {
                    añadirCaract = false;
                }
            }
            Console.WriteLine("Ingrese Cantidad de productos que desea añadir");
            int cantidadProductos = ObtenerEntradaInt();
            while (cantidadProductos < 0)
            {
                Console.Clear();
                Console.WriteLine("Cantidad invalidad");
                Console.WriteLine("Ingrese Cantidad de productos que desea añadir");
                cantidadProductos = ObtenerEntradaInt();
            }
            vendedor.Catalogo.IngresarProducto(nuevoProducto);
            cantidadProductos--;
            if(cantidadProductos == 0)
            {
                return;
            }
            vendedor.Catalogo.AumentarExistenciaProducto(cantidadProductos, vendedor.Catalogo.EncontrarProducto(nuevoProducto));
           
        }
        private void SelecionarProducto(Vendedor vendedor)
        {
            if (vendedor.Catalogo.GetSize() == 0)
            {
                Console.WriteLine("No hay productos para poder selecionar");
                Console.ReadLine();
                return;

            }
            int numeroProducto = ObtenerOpcionMenu("Ingrese # del producto que desea selecionar", vendedor.Catalogo.GetSize() - 1);

            vendedor.Catalogo.VerProducto(numeroProducto);
            Console.ReadLine();
            Console.Clear();
            int elecionProducto = ObtenerOpcionMenu("Ingrese 1 si desea añadir el producto a un carrito\ningrese 2 Si desea aumentar el inventario de un producto\nIngrese 0 para regresar", 2);
            switch (elecionProducto)
            {
                case 1:
                    AñadirProductoACarrito(vendedor.Catalogo.GetProduct(numeroProducto));
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Ingrese la cantidad del producto que desea ingresar al inventario");
                    int aumento = ObtenerEntradaInt();
                    while(aumento < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Valor ingresado invalido");
                        Console.WriteLine("Ingrese la cantidad del producto que desea ingresar al inventario");
                        aumento = ObtenerEntradaInt();
                    }
                    vendedor.Catalogo.AumentarExistenciaProducto(aumento,numeroProducto);
                    break;
                case 0:
                    return;
                    break;
            }
        }
        private void AñadirProductoACarrito(Product product)
        {
            Console.Clear();
            if (ListaCompradores.IsEmpty())
            {
                Console.WriteLine("No hay compradores registrados para ingresar a su carrito de compra");
                Console.ReadLine ();
                Console.Clear ();
                return;
            }
            Console.WriteLine(ListaCompradores.ToString());
            int CompradorElegido = ObtenerOpcionMenu("Ingrese # del comprador al que va a añadir el producto al carrito de compra", ListaCompradores.GetSize() - 1);
            Console.Clear();
            Console.WriteLine("Ingrese la cantidad del producto que va a ingresar al carrito");
            int cantidad = ObtenerEntradaInt();
            while(cantidad < 0)
            {
                Console.Clear();
                Console.WriteLine("Valor ingresado no valido");
                Console.WriteLine("Ingrese la cantidad del producto que va a ingresar al carrito");
                cantidad = ObtenerEntradaInt();
            }
            Comprador comprador = ListaCompradores.Get(CompradorElegido);
            comprador.CarritoCompra.AñadirItem(product,cantidad);
            Console.WriteLine("Producto añadido correctamente al carrito de compra");
            Console.ReadLine();
        }
    }
}

      
