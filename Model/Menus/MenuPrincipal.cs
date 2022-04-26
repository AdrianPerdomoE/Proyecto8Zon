using Proyecto8Zon.Model.Entities;
using Proyecto8Zon.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Menus
{
    public class MenuPrincipal:Menu
    {
        MyLinkedList<Comprador> ListaCompradores;
        MyLinkedList<Vendedor> ListaVendedores;
        LinkedQueue<Transportador> ColaTransportadores;
        MyLinkedList<Pedido> ListaPedidos;
        MyLinkedList<Envio> ListaEnvios;
        public MenuPrincipal(MyLinkedList<Comprador> listaCompradores,MyLinkedList<Vendedor> listaVendedores, LinkedQueue<Transportador> colaTransportadores, MyLinkedList<Pedido> listaPedidos, MyLinkedList<Envio> listaEnvios)
        {
            ListaCompradores = listaCompradores;
            ListaVendedores = listaVendedores;
            ColaTransportadores = colaTransportadores;
            ListaPedidos = listaPedidos;
            ListaEnvios = listaEnvios;
            bool seguirMenuPrincipal = true;
            while (seguirMenuPrincipal)
            {
                Console.Clear();
                int opcionMenuPrincipal = ObtenerOpcionMenu("Ingrese 1 para ver los compradores\nIngrese 2 para ver los vendedores\nIngrese 3 para ver los transportadores\nIngrese 4 para ver los pedidos\nIngrese 5 para ver los envios\nIngrese 6 para ver los productos\nIngrese 0 para salir de la aplicación", 6);
                switch (opcionMenuPrincipal)
                {
                    case 0:
                        seguirMenuPrincipal=false;
                        break;
                    case 1:
                        MenuCompradores menuCompradores = new(ListaCompradores);
                        break;
                    case 2:
                        MenuVendedores menuVendedores = new(ListaVendedores, ListaCompradores);
                        break;
                    case 3:
                        MenuTransportadores menuTransportadores = new(ColaTransportadores);
                        break;
                    case 4:
                        MenuPedidos menuPedidos = new(ListaPedidos, ListaCompradores,ListaVendedores,ListaEnvios,ColaTransportadores);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("ENVIOS");
                        Console.WriteLine(ListaEnvios);
                        Console.ReadLine();
                        Console.Clear();    
                        break;
                    case 6:
                        MenuProductos menuProductos = new(ListaCompradores,ListaVendedores);
                        break;
                }
            }
        }
    }
}
