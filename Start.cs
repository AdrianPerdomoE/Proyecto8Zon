

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
            listaCompradores.Add(new Comprador("Prueba", "123213", "111", "Correo"));
            MyLinkedList<Transportador> listaTransportadores = new();
            MenuVendedores menuVendedores = new(listaVendedores, listaCompradores); 
        }
    }
}