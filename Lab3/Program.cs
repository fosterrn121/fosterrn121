using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int output = 0;
            List<Person> PersonL= new List<Person>();
            Random ran = new Random();
            while(output != 7)
            {
                Console.WriteLine("Welcome please type the number of what you would like to do first."
                    + "\n1. Create a person object"
                    + "\n2. Display a person object"
                    + "\n3. remove a person object"
                    + "\n4. receive a random last name"
                    + "\n5. receive a random SSN"
                    + "\n6. receive a random phone number"
                    + "\n7. Exit program");
                int.TryParse(Console.ReadLine(), out output);

                switch(output)
                {
                    case 1:
                        Console.WriteLine("what number of people would you like to create?");
                        int numCreated = 0;
                        int.TryParse(Console.ReadLine(), out numCreated);
                        for(int i = 0; i < numCreated; i++)
                        {
                            Person human = new Person();
                            PersonL.Add(human);
                        }

                        break;
                    case 2:
                        if (PersonL.Count > 0)
                        {
                            foreach (Person person in PersonL)
                            {
                                Console.WriteLine(person.ToString());
                            }
                        }
                        else
                        {
                            Person Random = new Person();
                            PersonL.Add(Random);
                            Console.WriteLine(Random.ToString());
                        }
                        break;
                    case 3:
                        Console.WriteLine("What is the position of the person you would like to delete?");
                        int removeNum = 0;
                        int.TryParse(Console.ReadLine(), out removeNum);
                        PersonL.RemoveAt(removeNum);
                        break;
                    case 4:
                        int lName = ran.Next(PersonL.Count);
                        Console.WriteLine(PersonL[lName].LastName);
                        break;
                    case 5:
                        int ranSSN = ran.Next(PersonL.Count);
                        Console.WriteLine(PersonL[ranSSN].SSN);
                        break;
                    case 6:
                        int ranPhone = ran.Next(PersonL.Count);
                        Console.WriteLine(PersonL[ranPhone].Phone);
                        break;
                }

                
            }

            
        }
    }
}
