using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterAPI.ReferenceContainer
{
   public class Container 
    {
        private HashSet<Container> group;
       private double amount;

       public Container()
       {
           @group = new HashSet<Container>();
           @group.Add(this);
       }

        public void AddWater(double amount)
        {
            double amountPerContainer = amount / @group.Count;
            for (int i = 0; i < @group.Count; i++)
            {
                var item = @group.ToArray()[i];
                item.amount = amountPerContainer;
            }
        }

        public void ConnectTo(Container other)
        {
            if(@group==other.@group) return;
            int size1 = @group.Count,
                size2 = other.@group.Count;
            double tot1 = amount * size1,
                tot2 = other.amount * size2,
                newAmount = (tot2 + tot1) / (size1 + size2);
            
            foreach (var item in other.@group)
            {
                @group.Add(item);
            }

            for (int i = 0; i < other.@group.Count; i++)
            {
                var item = other.@group.ToArray()[i];
                item.@group = @group;
                item.amount = newAmount;
            }

        }

        public double GetAmount()
        {
            return amount;
        }
    }
}
