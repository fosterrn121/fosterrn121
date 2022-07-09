using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Dependent : Person
    {
        public Dependent() : base()
        {
            Random ran = new Random();
            int lowestYear = 10 * 365;
            BirthDate = DateTime.Today.AddDays(ran.Next(lowestYear));
        }
    }
}
