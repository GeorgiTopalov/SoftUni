using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public interface IFeedable
    {
        public abstract void FeedAnimal(string food, int foodQuantity);
       
    }
}
