using System;

namespace Start
{
	class Program
	{
		static void Main(string[] args)
		{
			Dinar.Categories.CategoryInfo   EdaInfo = new(10, 5, 2021, 520, 0);
			Dinar.Categories.CategoryInfo   TaxiInfo = new(24, 12, 2021, 230, 1);
			Dinar.Categories.Category		AllCats = new(EdaInfo, Dinar.Categories.Category.Flags.Food);

			AllCats.NewCategory(TaxiInfo, Dinar.Categories.Category.Flags.Taxi);
			AllCats.PutToConsole(Dinar.Categories.Category.Flags.Food);
			AllCats.AddNewPurchaseByDate("11.11.2021", 220,0);
			Console.WriteLine();
			AllCats.AddNewPurchaseByDate("09.05.2021", 120, 0);
			Console.WriteLine();
			AllCats.PutToConsole(Dinar.Categories.Category.Flags.Food);
			AllCats.AddNewPurchaseByDate("22.12.2021", 120, Dinar.Categories.Category.Flags.Food);
			AllCats.AddNewPurchaseByDate("22.12.2021", 50000, Dinar.Categories.Category.Flags.Taxi);
			Console.WriteLine();
			AllCats.PutToConsole(Dinar.Categories.Category.Flags.Food);
			AllCats.PutToConsole(Dinar.Categories.Category.Flags.Taxi);
		}
	}
}
