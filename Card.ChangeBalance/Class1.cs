using System;

namespace Card.ChangeBalance
{
    public class Class1
    {
        public double Balance { get; set; }
        public string Name { get; set; }

        public void ChangeBalance(double money)
        {
            Balance = Balance + money;
        }
    }
}
