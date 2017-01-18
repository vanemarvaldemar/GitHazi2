using System;

namespace GitHazi2
{
    public class Adatellenorzo : IAdatEllenorzo
    {
        public bool ErvenyesE(string inputValue, out int tipp)
        {

            if (!int.TryParse(inputValue, out tipp))
            {
                Console.WriteLine("Nem szám!");
                return false;
            }
            if (tipp < 0 || tipp > 1000)
            {
                Console.WriteLine("Mondom 1 és 1000 között!");
                return false;
            }
            return true;
        }

        public TippEllenorzesEredmeny TalaltE(int kitalalando, int tipp)
        {
            switch (Math.Sign(tipp - kitalalando))
            {
                case -1:
                    return TippEllenorzesEredmeny.Ala;
                case 1:
                    return TippEllenorzesEredmeny.Fole;
                case 0:
                    return TippEllenorzesEredmeny.Talalt;
            }
            return TippEllenorzesEredmeny.Ala;
        }
    }
}