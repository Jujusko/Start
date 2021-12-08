﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start
{
    public abstract class AbstractCard
    {
        public abstract int Balance { get; set; }
        public abstract string Name { get; set;}

        public AbstractCard()
        {

        }

        public abstract void ChangeBalancePlus(int money);
        public abstract void ChangeBalanceMinus(int money);

    }
}
