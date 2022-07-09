using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Information on invalid social security numbers came from this website
    /// https://secure.ssa.gov/poms.nsf/lnx/0110201035
    /// </summary>

    class SSN
    {
        public string Social { get; set; }

        public SSN()
        {
            StringBuilder built = new StringBuilder();
            Random ran = new Random();
            switch(ran.Next(1,3))
            {
                case 1:
                    switch(ran.Next(1,3))
                    {
                        case 1:
                            built.Append("000");
                            built.Append(ran.Next(01, 99).ToString("00"));
                            built.Append(ran.Next(0001, 9999).ToString("0000"));
                            break;
                        case 2:
                            built.Append("666");
                            built.Append(ran.Next(01, 99).ToString("00"));
                            built.Append(ran.Next(0001, 9999).ToString("0000"));
                            break;
                        case 3:
                            built.Append(ran.Next(900, 999));
                            built.Append(ran.Next(01, 99).ToString("00"));
                            built.Append(ran.Next(0001, 9999).ToString("0000"));
                            break;

                    }

                    break;
                case 2:
                    built.Append(ran.Next(001, 999).ToString("000"));
                    built.Append("00");
                    built.Append(ran.Next(0001, 9999).ToString("0000"));
                    break;
                case 3:
                    built.Append(ran.Next(001, 999).ToString("000"));
                    built.Append(ran.Next(0001, 9999).ToString("00"));
                    built.Append("0000");
                    break;
            }

            Social = built.ToString();
        }

        public override string ToString()
        {
            StringBuilder format = new StringBuilder(Social);
            format.Insert(3, "-");
            format.Insert(6, "-");

            return format.ToString();
        }
    }
}
