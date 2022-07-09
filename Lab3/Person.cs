using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Person
    {
        private string[] _arrayOfFirstNames = { "Raven", "Ron", "Jase", "Ryshand", "Jon", "Aqua", "Feyra", "Cassian", "Nesta", "Mor" };
        private Dependent[] _dependents = new Dependent[10];
        Random ran = new Random();


        public string FirstName { get; set; }
        public string LastName { get; set; }

        public SSN SSN { get; set; }

        public Phone Phone { get; set; }

        public  DateTime BirthDate { get; set; }

        public Person()
        {
            var lNameArr = Enum.GetValues(typeof(LastName));
            FirstName = _arrayOfFirstNames[ran.Next(_arrayOfFirstNames.Length)];
            LastName = (string)lNameArr.GetValue(ran.Next(lNameArr.Length)).ToString();
            SSN = new SSN();
            Phone = new Phone();
            int highestYear = 18 * 365;
            int lowestYear = 80 * 365;
            BirthDate = DateTime.Today.AddDays(-ran.Next(highestYear, lowestYear));
        }

        public int Age()
        {
            TimeSpan age = DateTime.Today - BirthDate;
            return (int)Math.Abs(age.Days / 365);
        }

        public void AddDependent()
        {
            Dependent depend = new Dependent();
            for(int i  = 0; i < _dependents.Length; i++)
            {
                if (_dependents[i] == null)
                {
                    _dependents[i] = depend;
                    break;
                }
            }
        }

        public override string ToString()
        {
            return $"{FirstName} + \n{LastName} + \n{BirthDate} + \n{Age()} + \n{SSN} + \n{Phone.Format()} + \n{_dependents}";
        }
    }
}
