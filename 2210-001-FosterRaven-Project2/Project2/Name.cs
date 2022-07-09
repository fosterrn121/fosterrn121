/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///        
///     Project:    Project 2 - NameList GUI
///     File Name:  Name.cs
///     Description:  Accepts string object and organizes it first to last or last to first
///     Course:     CSCI 2210-001 - Data Structures
///     Author:     Raven Foster, fosterrn@etsu.edu, Department of computing, East Tennessee State University
///     Created:    3/12/2020
///     Copyright:  Raven Foster, 2020
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;

namespace Project2
{

    /// <summary>
    /// Creates a name object and organizes them first to last or last to first.
    /// </summary>
    public class Name : IEquatable<Name>, IComparable<Name>
    {
        public string Name1 { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string RestOfName { get; set; }
        /// <summary>
        /// Parameterized constructor: default constructor sets all variables.
        /// </summary>
        public Name()
        {
            Name1 = String.Empty;
            RestOfName = String.Empty;
            LastName = String.Empty;
            Suffix = String.Empty;
        }



        /// <summary>Initializes a new instance of the Name class.</summary>
        /// <param name="other">The other.</param>
        public Name(String other)
        {
            string temp = other.Replace(" ", String.Empty);
            Name1 = other;
            int firstComma = Name1.IndexOfAny(",".ToCharArray());
            int firstSpace = Name1.IndexOfAny(" ".ToCharArray());
            int lastSpace = Name1.LastIndexOfAny(" ".ToCharArray());
            int lastComma = temp.LastIndexOfAny(",".ToCharArray());

            if(firstSpace < 0)
            {
                LastName = "";
                Suffix = "";
                RestOfName = temp;
                return;

            }

            if(firstComma < 0)
            {
                LastName = Name1.Substring(lastSpace + 1);
                RestOfName = Name1.Substring(0, lastSpace);
                Suffix = String.Empty;

            }
            else if(firstComma > firstSpace)
            {
                Suffix = Name1.Substring(firstComma + 1).Trim();
                RestOfName = Name1.Substring(0, firstComma).Trim();

                lastSpace = RestOfName.LastIndexOfAny(" ".ToCharArray());
                LastName = RestOfName.Substring(lastSpace + 1).Trim();
                RestOfName = RestOfName.Substring(0, lastSpace).Trim();
            }
            else
            {
                if(lastComma > firstComma)
                {
                    Suffix = temp.Substring(lastComma + 1).Trim();
                    temp = temp.Substring(0, lastComma).Trim();

                }

                RestOfName = temp.Substring(firstComma + 1).Trim();
                LastName = temp.Substring(0, firstComma).Trim();
            }

        }



        /// <summary>
        /// Creates a copy of name variables.
        /// </summary>
        /// <param name="copy">hold a copy of a name object</param>
        public Name(Name copy)
        {
            this.Name1 = copy.Name1;
            this.RestOfName = copy.RestOfName;           
            this.LastName = copy.LastName;
            this.Suffix = copy.Suffix;
        }

        /// <summary>  Determines if two name object are equal to each other.</summary>
        /// <param name="n">The n.</param>
        /// <returns>true if equal false if not</returns>
        bool IEquatable<Name>.Equals(Name n)
        {
            if(LastName.Equals(n.LastName, StringComparison.InvariantCultureIgnoreCase))
            {
                if(RestOfName.Equals(n.RestOfName, StringComparison.InvariantCultureIgnoreCase))
                {
                    if(Suffix.Equals(n.Suffix, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }
        /// <summary>
        /// Determines whether the object is null or is a name object.
        /// </summary>
        /// <param name="obj">holds a obj to see if its a name object <see cref="T:NameList.Name"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="T:NameList.Name"/>;
        /// otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return base.Equals(obj);

            if (!(obj is Name))
                throw new ArgumentException($"can't compare a Name object to a {obj.GetType() } object");
            else
                return Equals(obj as Name);
        }
        /// <summary>
        /// Serves as a hash function for a Name object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return Name1.GetHashCode();
        }
        /// <summary>
        /// Compares a name.
        /// </summary>
        /// <returns>returns 1 if true or 0 if false</returns>
        /// <param name="other">name being compared.</param>
        public int CompareTo(Name other)
        {
            if (string.Compare(LastName, other.LastName, StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                if(string.Compare(RestOfName, other.RestOfName, StringComparison.CurrentCultureIgnoreCase) == 0)
                {
                    if(string.Compare(Suffix, other.Suffix, StringComparison.CurrentCultureIgnoreCase) == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }
        /// <summary>
        /// Takes a name object and rearranges it first to last.
        /// </summary>
        /// <returns>a formatted string<see langword="async"/> return a rearranged string name </returns>
        /// <param name="nm">name object</param>
        public string FormatFirstLast()
        {
            String firstLastName = String.Empty;
            
                if (!String.IsNullOrEmpty(Suffix))
                {
                    firstLastName = $"{ RestOfName} { LastName}, { Suffix}";
                }
                else
                {
                    firstLastName = $"{RestOfName} {LastName}";
                }

            return firstLastName;
        }
        /// <summary>
        /// Formats a name last, first middle suffix.
        /// </summary>
        /// <returns>a rearranged string</returns>
        /// <param name="last">name object</param>
        public string FormatLast()
        {
            string lastFirst = String.Empty;
            if (!String.IsNullOrEmpty(Suffix))
            {
                lastFirst = $"{LastName}, {RestOfName}, {Suffix}";
            }
            else
            {
                lastFirst = $"{LastName}, {RestOfName}";
            }
            return lastFirst;
        }

       
    }
}

