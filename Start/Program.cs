using System;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            Dinar.Categories.CategoryInfo EdaInfo = new(10, 5, 2021, 520, "Еда");
            Dinar.Categories.Category Eda = new(EdaInfo);
            Eda.PutToConsole();
            Eda.AddNewPurchaseByDate("11.11.2021", 220, "Еда");
            Console.WriteLine();
            Eda.AddNewPurchaseByDate("09.05.2021", 120, "Еда");
            Console.WriteLine();
            Eda.PutToConsole();
            Eda.AddNewPurchaseByDate("22.12.2021", 120, "Еда");
            Console.WriteLine();
            Eda.PutToConsole();
        }
    }
}
