
namespace GitHazi2
{
    public enum TippEllenorzesEredmeny
    {
        Ala,
        Fole,
        Talalt
    }
    interface IAdatEllenorzo
    {
        bool ErvenyesE (string inputValue, out int tipp);
        TippEllenorzesEredmeny TalaltE(int kitalalandoSzam, int tipp);
    }
}
