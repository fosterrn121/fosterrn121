using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4
{
    class TextManipulator
    {
        public string filePath { get; set; }
        public List<string> sentenceList { get; set; }
        public string randomSent { get; set; }
        private Random ran = new Random();
        public TextManipulator(string path)
        {
            var rootOfProjectString = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            var usrPath = rootOfProjectString + path;
            sentenceList = new List<string>();
            if(!File.Exists(usrPath))
            {
                Console.WriteLine("File path does not exist");
            }

            using (StreamReader reader = File.OpenText(usrPath))
            {
                char[] delims = { '.', '!', '?' };
                string sent;
                while((sent = reader.ReadLine()) != null)
                {
                    
                    string[] holdList = sent.Split(delims, StringSplitOptions.RemoveEmptyEntries);

                    string delimSent = "";
                    for(int i = 0; i < holdList.Length; i++)
                    {
                        delimSent = "";
                    }

                    string[] puncList = sent.Split(delimSent.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    int counter = 0;

                    foreach(string sentence in holdList)
                    {
                        string complete = sentence + puncList[counter];
                        sentenceList.Add(complete);
                        counter++;
                    }

                }


            }
            RandomSentence();
        }

        public void RandomSentence()
        {
            randomSent = sentenceList[ran.Next(sentenceList.Count)];
        }

        public int RandomCount()
        {
            char[] delim = { '!', '?', '.', ' ' };
            string[] wordCount = randomSent.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            return wordCount.Length;
        }

        public string Trimmed(string delimiters)
        {
            string[] sentTrim = randomSent.Split(delimiters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string result = "";
            for(int i = 0; i < sentTrim.Length; i++)
            {
                result += sentTrim[i] + " ";
            }
            return result;
        }

        public Dictionary<string, int> DictionaryWord()
        {
            Dictionary<string, int> rDictionary = new Dictionary<string, int>();
            foreach(char letter in randomSent)
            {
                if(rDictionary.ContainsKey(letter.ToString()))
                {
                    rDictionary[letter.ToString()]++;
                }
                else
                {
                    rDictionary.Add(letter.ToString(), 1);
                }
            }
            return rDictionary;
        }


    }
}
