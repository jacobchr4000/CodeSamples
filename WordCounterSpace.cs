using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounterSpace
{
    public class WordCounter
    {
        private string[] words;
        private string[] unicWords;
        private int[] numOccurences;
        private int numUnicWords = 0;
        
        public WordCounter()
        {
        }

        public string count(string sentence)
        {
            sentence = sentence.Replace(Environment.NewLine, "");
            words = sentence.Split(' ', '.', '!', '?');
            int limit = words.Length;
            unicWords = new string[limit];
            numOccurences = new int[limit];

            bool found;
            foreach (string word in words)
            {
                found = false;
                for (int i = 0; i <= numUnicWords; i++)
                {
                    if (word == unicWords[i])
                    {
                        found = true;
                        numOccurences[i]++;
                    }
                }
                if (!found)
                {
                    numUnicWords++;
                    unicWords[numUnicWords - 1] = word;
                    numOccurences[numUnicWords - 1] = 1;
                }
            }

            string result = "";
            for (int i = 0; i < numUnicWords; i++)
            {
                result = result + numOccurences[i] + ": " + unicWords[i] + Environment.NewLine;
            }

            return result;
        }
    }
}
