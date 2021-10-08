using System;
using System.Collections.Generic;
using System.Text;

namespace CommisionCalc.BusinessLogic.Interfaces
{
    public interface ICommision
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int CommisionValue { get; set; }

        public List<ICommision> GetAll();
        public List<ICommision> Add(ICommision commision);

        public int Calculate(int sales);
    }
}
