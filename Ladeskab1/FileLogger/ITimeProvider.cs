using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
   public interface ITimeProvider
   {
        public string DT { get; set; }
       string getTime();

   }
}
