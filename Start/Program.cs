using System;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractCard sber = new RealCard(10000, "Моя карта");
            sber.WriteBalance();
        }
    }
}
