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
        MyLinkedList<Transportador> ListaTransportadores;
        public MenuPrincipal(MyLinkedList<Comprador> listaCompradores,MyLinkedList<Vendedor> listaVendedores, MyLinkedList<Transportador> listaTransportadores)
        {
            ListaCompradores = listaCompradores;
            ListaVendedores = listaVendedores;
            ListaTransportadores = listaTransportadores;
            bool seguirMenuPrincipal = true;
            while (seguirMenuPrincipal)
            {
                Console.Clear();
                int opcionMenuPrincipal = ObtenerOpcionMenu("Ingrese 1 para ver los compradores\nIngrese 2 para ver los vendedores\nIngrese 3 para ver los transportadores\nIngrese 0 para salir de la aplicación",3);
                switch (opcionMenuPrincipal)
                {
                    case 0:
                        seguirMenuPrincipal=false;
                        break;
                    case 1:
                        MenuCompradores menuCompradores = new(listaCompradores);
                        break;
                    case 2:
                        MenuVendedores menuVendedores = new(listaVendedores, listaCompradores);
                        break;
                    case 3:
                        MenuTransportadores menuTransportadores = new(listaTransportadores);
                        break;
                }
            }
        }
    }
}
