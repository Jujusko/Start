using System;

namespace Start
{
	class Program
	{
		static void Main(string[] args)
		{
			//Dinar.Categories.CategoryInfo   EdaInfo = new(10, 5, 2021, 520, "Еда");
			//Dinar.Categories.CategoryInfo   TaxiInfo = new(24, 12, 2021, 230, "Такси");
			//Dinar.Categories.Categories		AllCats = new(EdaInfo, Dinar.Categories.Categories.Flags.Food);

			//AllCats.NewCategory(TaxiInfo);
			//AllCats.PutToConsole("Еда");
			//AllCats.AddNewPurchaseByDate("11.11.2021", 220, "Еда");
			//Console.WriteLine();
			//AllCats.AddNewPurchaseByDate("09.05.2021", 120, "Еда");
			//Console.WriteLine();
			//AllCats.PutToConsole("Еда");
			//AllCats.AddNewPurchaseByDate("22.12.2021", 120, "Еда");
			//AllCats.AddNewPurchaseByDate("22.12.2021", 50000, "Такси");
			//Console.WriteLine();
			//AllCats.PutToConsole("Еда");
			//AllCats.PutToConsole("Такси");
			//         Console.WriteLine();
			//AllCats.PrintCats();
			//AllCats.NewCategory("Побрякушки", 340);

			//AllCats.PrintCats();
			//AllCats.AddNewPurchaseByDate("13.3.2020", 438, "Побрякушки");
			//         Console.WriteLine();
			//AllCats.PutToConsole("Побрякушки");
			//AllCats.NewCategory("Собаки", 800);
			//         Console.WriteLine();
			//         Console.WriteLine();
			//AllCats.PutToConsole("Собаки");
			//         Console.WriteLine();
			//AllCats.AddNewPurchaseByDate("01.4.2021", 1458, "Собаки");
			//AllCats.PutToConsole("Собаки");
			//         Console.WriteLine();
			//AllCats.PutToConsole("Еда");
			Dinar.Categories.Categories cats = new();
			cats.NewOrAdd("eda", "12/11/2021", 230);
			cats.NewOrAdd("eda", "12/10/2021", 123);
			cats.NewOrAdd("eda", "12/12/2021", 321);
            Console.WriteLine(cats.PutToConsole("eda"));
		}
	}
}
