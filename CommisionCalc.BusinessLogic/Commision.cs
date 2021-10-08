using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommisionCalc.BusinessLogic.Interfaces;

namespace CommisionCalc.BusinessLogic
{
    public class Commision : ICommision
    {
        private int _minValue;
        private int _maxValue;
        private int _commValue;
        private readonly ICommision _commision;
        private List<ICommision> _commisionsList;

        public Commision()
        {
            _commisionsList = new List<ICommision>();
        }

        public int MinValue
        {
            get => _minValue;
            set => _minValue = value;
        }

        public int MaxValue
        {
            get => _maxValue;
            set => _maxValue = value;
        }

        public int CommisionValue
        {
            get => _commValue;
            set => _commValue = value;
        }

        public List<ICommision> Add(ICommision commision)
        {
            _commisionsList.Add(commision);
            return _commisionsList;
        }

        public int Calculate(int sales)
        {
            int totalcommision = 0;
            int remaindersales = sales;
            _commisionsList = _commisionsList.OrderByDescending(c => c.MaxValue).ToList();
            foreach (Commision eachcommision in _commisionsList)
            {
                if (remaindersales >= eachcommision.MinValue)
                {
                    int SalesCountedInCurrentCriteria = (remaindersales - (eachcommision.MinValue-1));
                    totalcommision += (SalesCountedInCurrentCriteria * eachcommision.CommisionValue);
                    remaindersales -= SalesCountedInCurrentCriteria;
                }
            }
            return totalcommision;
        }

        public List<ICommision> GetAll()
        {
            return _commisionsList;
        }
    }
}
