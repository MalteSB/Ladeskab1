using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    public class TimeProvider : ITimeProvider
    {
        public string DT { get; set; }

        public string getTime()
        {
            DT=Convert.ToString(DateTime.Now);
            return DT;
        }

    }

}
