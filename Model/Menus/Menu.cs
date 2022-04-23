using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Menus
{
    public abstract class Menu
    {
        internal int ObtenerOpcionMenu(string texto, int opciones)
        {
            Console.WriteLine(texto);
            int opcion = ObtenerEntradaInt();
            while(opcion < 0 || opcion > opciones)
            {
                Console.Clear();
                Console.WriteLine("Error, valor ingresado no concuerda con alguna de las opciones validas");
                Console.WriteLine(texto);
                opcion = ObtenerEntradaInt();
            }
            return opcion;
        }
        internal string ObtenerEntrada(string texto)
        {
            Console.WriteLine(texto);
            Console.Write(":");
            string entrada =Console.ReadLine();
            while (entrada == null || entrada =="")
            {
                Console.Clear();
                Console.WriteLine(texto);
                Console.Write(":");
                entrada = Console.ReadLine();
            }
            return entrada;
        }
        internal int ObtenerEntradaInt()
        {
            try
            {
                Console.Write(":");
                int entrada = Int32.Parse(Console.ReadLine());
                return entrada;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        internal double ObtenerEntradaDouble()
        {
            try
            {
                Console.Write(":");
                double entrada = double.Parse(Console.ReadLine());
                return entrada;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
    }
}
