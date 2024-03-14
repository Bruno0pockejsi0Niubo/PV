using System;
using System.Collections.Generic;

namespace DATABAZEK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MojeDatabaze())
            {
                try
                {
                    // priklad vytvoreni dodavatele
                    var dodavatel = new Dodavatel { Jmeno = "XXX" };
                    db.Dodavatele.Add(dodavatel);
                    db.SaveChanges();

                    // priklad vytvoreni zakaznika
                    var zakaznik = new Zakaznik { Jmeno = "Jan Novak" };
                    db.Zakaznici.Add(zakaznik);
                    db.SaveChanges();

                    // priklad vytvoreni objednavky
                    var objednavka = new Objednavka
                    {
                        DatumObjednani = DateTime.Now,
                        PolozkyObjednavky = new List<PolozkaObjednavky>
                        {
                            new PolozkaObjednavky { ProduktId = 1, Mnozstvi = 2 },
                            new PolozkaObjednavky { ProduktId = 2, Mnozstvi = 1 }
                        }
                    };
                    db.Objednavky.Add(objednavka);
                    db.SaveChanges();

                    //mpriklad smazani dodavatele
                    var dodavatelKeSmazani = db.Dodavatele.Find(1); // ID dodavatele ktery chcete smazat
                    if (dodavatelKeSmazani != null)
                    {
                        db.Dodavatele.Remove(dodavatelKeSmazani);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Chyba pri ukladani do databaze: " + ex.Message);
                }
            }
        }
    }
}
