using System;
using System.Collections.Generic;

namespace Virevox.application.core
{
    public class ProductComparer<T> : IComparer<T>
    {
        public int Compare(T left, T right)
        {
            Product pLeft  = left as Product;
            Product pRight  = right as Product;

            if (pLeft == null || pRight == null)
                throw new ArgumentException("Objects are not type of Product");

            if (pLeft.AnnualCosts > pRight.AnnualCosts)
                return 1;
            else if (pLeft.AnnualCosts < pRight.AnnualCosts)
                return -1;
            
            return 0;
        }
    }
}