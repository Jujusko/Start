using System;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime er = DateTime.Now;
            DateTime we = new(2021, 10, 20);
            TimeSpan sum = er - we;

        }
    }
}
