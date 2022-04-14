using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto8Zon.Model.Structures;
namespace Proyecto8Zon.Model.Entities
{
    public class Product
    {
        public string Name;

        public double Price;

        public MyLinkedList<string> Features { get;}    
       
        public Product(string name, double price)
        {
            Name = name;

            Price = price;
        }

        public void AddFeature(string text)
        {
            Features.Add(text); 
        }
        
    }
}
