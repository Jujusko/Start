namespace Start
{
    public class CashBackByCategory
    {
        public string CatName { get; set; }
        public int Percent { get; set; }

        public CashBackByCategory(string Category, int percent)
        {
            CatName = Category;
            Percent = percent;
        }
    }
}
