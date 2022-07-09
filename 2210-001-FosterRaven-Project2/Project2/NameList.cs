/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///        
///     Project:    Project 2 - NameList GUI
///     File Name:  NameList.cs
///     Description:  holds methods to edit a class list such as add, remove and rearrange.
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
    /// Holds methods to edit a class list such as add, remove and rearrange.
    /// </summary>
    public class NameList
    {
       

        private List<Name> Names { get; set; }
        /// <summary>  Create a list of names</summary>
        public NameList()
        {
            Names = new List<Name>();
        }
        /// <summary>
        /// Gets or sets the Name object at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public Name this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                {
                    throw new IndexOutOfRangeException($"{index} is not between 0 and {Count} the valid range of subscripts for this list.");
                }
                return Names[index];
            }
            set
            {
                if (index < 0 || index > Count)
                {
                    throw new IndexOutOfRangeException($"{index} is not between 0 and {Count} the valued range of subscripts for this list.");
                }
                Names[index] = value;
            }
        }
        /// <summary>
        /// Gets the count of Names.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return Names.Count;
            }
        }


        /// <summary>
        /// Adds a NameList object to a Name object, yielding a new NameList.
        /// </summary>
        /// <param name="n">NameList holds a NameList</param>
        /// <param name="name">Name holds name object Name to add.</param>
        /// <returns>The <see cref="T:NameList.NameList"/> that is the sum of the values of <c>n</c> and <c>name</c>.</returns>
        public static NameList operator +(NameList n, Name name)
        {
            n.Names.Add(name);
            return n;
        }
        /// <summary>
        /// Removes a name from a name list
        /// </summary>
        /// <param name="n">The NameList to subtract from .</param>
        /// <param name="i">int i number of position in list to be removed.</param>
        /// <returns>The <see cref="T:NameList.NameList"/> that is the <c>n</c> minus <c>i</c>.</returns>
        public static NameList operator -(NameList n, int i)
        {
            if (n.Count > 0 && i <= n.Names.Count)
            {
                n.Names.RemoveAt(i - 1);
                return n;
            }
            else
            {
                throw new IndexOutOfRangeException($" number out of range of Name list");
            }
        }
        /// <summary>
        /// Sorts names first middle last suffix
        /// </summary>
        /// <returns>a list of organized string.</returns>
        /// <param name="name">list of string names</param>
        public  List<string> SortedFirst()
        {
            List<string> sortedFirstList = new List<string>();
            for (int i = 0; i < Names.Count; i++)
            {
                Name nm = new Name(Names[i]);
                string formated = nm.FormatFirstLast();
                sortedFirstList.Add(formated);
            }
            return sortedFirstList;
        }
        /// <summary>
        /// Sorts names last, first middle suffix
        /// </summary>
        /// <returns>reorganized name</returns>
        /// <param name="nm">Nm.</param>
        public List<String> SortedLast()
        {
            List<string> sortedLastList = new List<string>(Names.Count);
            for (int i = 0; i < Names.Count; i++)
            {
                Name last = new Name(Names[i]);
                string format = last.FormatLast();
                sortedLastList.Add(format);
            }
            return sortedLastList;
        }
    }
}
