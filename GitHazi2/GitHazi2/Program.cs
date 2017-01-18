using System;
using System.Text;


namespace GitHazi2
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var szam = random.Next(0, 1000);

//            var engine = new Engine(new Adatellenorzo());
            var engine = new Engine(null);
            engine.Start(szam);
        }

        internal class Engine
        {
            private readonly IAdatEllenorzo _adatellEnorzo;

            bool fuss = true;
            StringBuilder buffer = new StringBuilder();

            public Engine(IAdatEllenorzo adatEllenorzo)
            {
                _adatellEnorzo = adatEllenorzo;
            }

            public void Start(int kitalalandoSzam)
            {
                Console.WriteLine("Gondoltam egy számra 1 és 1000 között. Tippelj!");
                while (fuss)
                {
                    var key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.Escape:
                            fuss = false;
                            break;
                        case ConsoleKey.Enter:
                            string tippString = buffer.ToString();
                            int tipp;
                            buffer.Clear();
                            Console.Clear();
                            if (!_adatellEnorzo.ErvenyesE(tippString, out tipp))
                            {
                                Console.WriteLine("Érvénytelen szám!");
                            }
                            else
                            {
                                switch (_adatellEnorzo.TalaltE(kitalalandoSzam,tipp))
                                {
                                    case TippEllenorzesEredmeny.Talalt:
                                        Console.WriteLine("Talált!");
                                        fuss = false;
                                        break;
                                    case TippEllenorzesEredmeny.Ala:
                                        Console.WriteLine("Alá!");
                                        break;
                                    case TippEllenorzesEredmeny.Fole:
                                        Console.WriteLine("Fölé!");
                                        break;
                                }
                            }

                            break;
                        default:
                            buffer.Append(key.KeyChar);
                            break;
                    }
                }

                Console.WriteLine("Vége. Nyomj gombot.");
                Console.ReadKey();
            }
        }
        }

    //Test implementation
    //internal class Adatellenorzo : IAdatEllenorzo
    //{

    //    public bool ErvenyesE(string inputValue, out int tipp)
    //    {
 
    //        if (!int.TryParse(inputValue, out tipp))
    //        {
    //            Console.WriteLine("Nem szám!");
    //            return false;
    //        }
    //        if (tipp < 0 || tipp > 1000)
    //        {
    //            Console.WriteLine("Mondom 1 és 1000 között!");
    //            return false;
    //        }
    //        return true;
    //    }

    //    public TippEllenorzesEredmeny TalaltE(int kitalalando, int tipp)
    //    {
    //        switch (Math.Sign(tipp - kitalalando))
    //        {
    //            case -1:
    //                return TippEllenorzesEredmeny.Ala;
    //            case 1:
    //                return TippEllenorzesEredmeny.Fole;
    //            case 0:
    //                return TippEllenorzesEredmeny.Talalt;
    //        }
    //        return TippEllenorzesEredmeny.Ala;
    //    }
    //}
}
