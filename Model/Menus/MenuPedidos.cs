using Proyecto8Zon.Model.Entities;
using Proyecto8Zon.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Menus
{
    public class MenuPedidos : Menu
    {
        MyLinkedList<Pedido> ListaPedidos;
        MyLinkedList<Comprador> ListaCompradores;
        MyLinkedList<Vendedor> ListaVendedores;
        MyLinkedList<Envio> ListaEnvios;
        LinkedQueue<Transportador> ColaTransportadores;
        public MenuPedidos(MyLinkedList<Pedido> listaPedidos, MyLinkedList<Comprador> listaCompradores, MyLinkedList<Vendedor> listaVendedores, MyLinkedList<Envio> listaEnvios, LinkedQueue<Transportador> colaTransportadores)
        {
            ListaCompradores = listaCompradores;
            ListaPedidos = listaPedidos;
            ListaVendedores = listaVendedores;
            ListaEnvios = listaEnvios;
            ColaTransportadores = colaTransportadores;
            bool SeguirMenuPedidos = true;
            while (SeguirMenuPedidos)
            {
                Console.Clear();
                Console.WriteLine(ListaPedidos);
                int  opcionMenuPedidos= ObtenerOpcionMenu("Ingrese 1 para añadir un pedido\nIngrese 2 para confirmar una compra y realizar el envio\nIngrese 0 para salir del menu de pedidos", 2);
                switch (opcionMenuPedidos)
                {
                    case 1:
                        AgregarPedido();
                        break;
                    case 2:
                        CompletarCompra();
                        break;
                    case 0:
                        SeguirMenuPedidos = false;
                        break;
                }
            }
        }
        public void CompletarCompra()
        {
            Console.Clear();
            if (ListaPedidos.IsEmpty())
            {
                Console.WriteLine("No hay pedidos registrados");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            Console.WriteLine(ListaPedidos);
            int numeroPedido = ObtenerOpcionMenu("Ingrese # del pedido que desea validar", ListaPedidos.GetSize() - 1);
            Pedido pedidoActual = ListaPedidos.Get(numeroPedido);
            if (pedidoActual.Enviado)
            {
                Console.Clear();
                Console.WriteLine("Este pedido ya ha sido validado y enviado");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            Transportador  transportador = ValidarTrasportador(pedidoActual);
            if (transportador == null)
            {
                Console.WriteLine("No hay un trasportador disponible en su ciudad");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            GenerarEnvio(pedidoActual);
            if (!pedidoActual.Enviado)
            {
                return;
            }
            Envio envio = new(transportador,pedidoActual);
            for(int i = 0; i < pedidoActual.ShoppingCar.GetSize(); i++)
            {
                AlistarEnvio(envio, pedidoActual.ShoppingCar.BuscarProducto(i));
            } 
            ListaEnvios.Add(envio); 
        }
        public void AlistarEnvio(Envio envio,ItemCarrito item)
        {
            for (int vendedor = 0; vendedor < ListaVendedores.GetSize(); vendedor++)
            {
                int index = ListaVendedores.Get(vendedor).Catalogo.EncontrarProducto(item.Producto);
                if (index != -1)
                {
                   for(int i = 0; i < item.Cantidad; i++)
                    {
                        envio.productos.Add(ListaVendedores.Get(vendedor).Catalogo.SacarProducto(index));
                    }   
                }
            }
            
        }
        public void GenerarEnvio(Pedido pedido)
        {
            bool validacion = ValidarExistenciaProductos(pedido);
            if (!validacion)
            {
                return;
            }
            pedido.ConfirmarEnvio();
        }

        public Transportador ValidarTrasportador(Pedido pedido)
        {
            
            for(int transportador = 0; transportador < ColaTransportadores.GetSize(); transportador++)
            {
                MyLinkedList<string> ciudades = ColaTransportadores.Get(transportador).ciudades;
                for(int ciudad = 0;ciudad < ciudades.GetSize(); ciudad++)
                {
                    if(ciudades.Get(ciudad)  == pedido.Comprador.Ciudad)
                    {
                        Transportador transportadorFinal = ColaTransportadores.Remove(transportador);
                        ColaTransportadores.Add(transportadorFinal);
                        return transportadorFinal;
                    }  
                }
            }
            return null;
        }
        private bool ValidarExistenciaProductos(Pedido pedido)
        {
            bool validacionExistencia = true;
            for (int item = 0; item < pedido.ShoppingCar.GetSize(); item++)
            {
                for (int vendedor = 0; vendedor < ListaVendedores.GetSize(); vendedor++)
                {
                    int index = ListaVendedores.Get(vendedor).Catalogo.EncontrarProducto(pedido.ShoppingCar.BuscarProducto(item).Producto);
                    if(index != -1)
                    {
                        bool existencia = ListaVendedores.Get(vendedor).Catalogo.validarExistencia(index, pedido.ShoppingCar.BuscarProducto(item).Cantidad);
                        if (!existencia)
                        {
                            validacionExistencia = false;
                            Console.WriteLine($"No hay suficientes unidades del producto {pedido.ShoppingCar.BuscarProducto(item).Producto}");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
            }
            return validacionExistencia;
        }
        public void AgregarPedido()
        {
            MyLinkedList<Comprador> ListaCompradoresDisponibles = new MyLinkedList<Comprador>();
            Console.Clear();
            if (ListaCompradores.IsEmpty())
            {
                Console.WriteLine("No hay compradores registrados");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            int carritosDisponibles = 0;
            for(int i = 0; i < ListaCompradores.GetSize(); i++)
            {
                if(!ListaCompradores.Get(i).CarritoCompra.IsEmpty())
                {
                    Console.Write($"# {carritosDisponibles} ");
                    carritosDisponibles++;
                    ListaCompradoresDisponibles.Add(ListaCompradores.Get(i));
                    Console.WriteLine(ListaCompradores.Get(i));
                    Console.WriteLine(ListaCompradores.Get(i).CarritoCompra);
                    
                }
            }
            if(carritosDisponibles == 0)
            {
                Console.WriteLine("No hay carros de compra disponibles para generar un pedido");
                Console.ReadLine();
                Console.Clear ();
                return;
            }
            int carritoPedido = ObtenerOpcionMenu($"Hay {carritosDisponibles} para generar un pedido ingrese # del comprador al que le quiere generar un pedido", ListaCompradoresDisponibles.GetSize() - 1);
            GenerarPedido(carritoPedido,ListaCompradoresDisponibles);
        }

        private void GenerarPedido(int index, MyLinkedList<Comprador> listacompradores)
        {
            Comprador CompradorPedido = listacompradores.Get(index);
            Pedido nuevoPedido = new(CompradorPedido, CompradorPedido.CarritoCompra);
            ListaPedidos.Add(nuevoPedido);
            Console.WriteLine("Se ha generado el pedido correctamente");
            Console.ReadLine();
            CompradorPedido.RenovarCarro();
        }
    }
}
