using System;

namespace Start
{
	class Program
	{
		static void Main(string[] args)
		{
			Dinar.Categories.Categories Categs = new();

			Categs.NewCategory("Eda", 100, null);
            Console.WriteLine(Categs.PutToConsole("Eda"));
			Categs.NewCategory("Taxi", 100, null);
			Console.WriteLine(Categs.PutToConsole("Taxi"));

			User aaaa = new User("Alex");
		}
	}
}
