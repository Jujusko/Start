using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start
{
    public class Tranz
    {
        public string CatName { get; set; }
        public DateTime DateTranz { get; set; }
        public int Sum { get; set; }

        //idk need or not
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Tranz(DateTime day, string category, int sum)
        {
            DateTranz = day;
            CatName = category;
            Sum = sum;
        }

        public static Tranz GetTranzaction(string info, string categName)
        {
            Tranz toRet;

            string[] all = info.Split("\n");
            int sum = Convert.ToInt32(all[1]);
            DateTime dateTranz = Convert.ToDateTime(all[0]);
            toRet = new(dateTranz, categName, sum);
            return toRet;
        }

        public override string ToString()
        {
            string s = "";
            s = CatName + " " + DateTranz + Sum;
            return s;
        }
        public override bool Equals(object obj)
        {
            Tranz tmp = (Tranz)obj;
            if (tmp.CatName != this.CatName || tmp.DateTranz != this.DateTranz
                || tmp.Sum != this.Sum)
                return false;
            return true;
        }
    }
}
