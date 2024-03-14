using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATABAZEK
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Nazev { get; set; }
        public int DodavatelId { get; set; }
        public Dodavatel Dodavatel { get; set; }
        public ICollection<PolozkaObjednavky> PolozkyObjednavky { get; set; }
    }
}
