using System.Collections.Generic;

namespace Virevox.application.core
{
    public interface IProductBuilder
    {
        Product [] Build();
        void SetConsumption(long consumption);
    }
}