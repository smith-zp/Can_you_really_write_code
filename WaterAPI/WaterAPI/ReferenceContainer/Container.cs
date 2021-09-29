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
   }
}
