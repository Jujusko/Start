using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
