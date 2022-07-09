using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Phone
    {
        public string PhoneNumber { get; set; }

        public Phone()
        {
            StringBuilder built = new StringBuilder(10);
            Random ran = new Random();
            built.Append(ran.Next(2, 9).ToString());
            for(int i = 0; i < 9; i++)
            {
                built.Append(ran.Next(0, 9).ToString());
            }

            PhoneNumber = built.ToString();

        }

        public String Format()
        {
            StringBuilder format = new StringBuilder(PhoneNumber);
            format.Insert(3, "-");
            format.Insert(7, "-");
            return format.ToString();

        }
    }
}
