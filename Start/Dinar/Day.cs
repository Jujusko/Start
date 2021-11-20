using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.Dinar
{
    class Day:Node<int[]>
    {
        public override int[] Content { get; set; }
        public override Node<int[]> Next { get; set; }

    }
}
