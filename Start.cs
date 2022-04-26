

using Proyecto8Zon.Model.Entities;
using Proyecto8Zon.Model.Menus;
using Proyecto8Zon.Model.Structures;

namespace Proyecto8Zon
{
    public static class Start
    {
        static void Main(string[] args)
        {
            MyLinkedList<Vendedor> listaVendedores = new();
            MyLinkedList<Comprador> listaCompradores = new();
            LinkedQueue<Transportador> colaTransportadores = new();
            MyLinkedList<Pedido> listaPedidos = new();
            MyLinkedList<Envio> listaEnvios = new();
            MenuPrincipal menuPrincipal = new(listaCompradores, listaVendedores, colaTransportadores, listaPedidos, listaEnvios); 
        }
    }
}