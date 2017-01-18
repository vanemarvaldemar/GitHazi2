using System;


namespace GitHazi2
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var szam = random.Next(0, 1000);

            var engine = new Engine(null);
            engine.Start(szam);
        }

        internal class Engine
        {
            public Engine(IAdatEllenorzo adatEllenorzo)
            {
            }

            public void Start(int kitalalandoSzam)
            {
            }
        }
        }
}
