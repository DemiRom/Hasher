using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    class DeHasher
    {
        String letters = "acdegilmnoprstuw";

        System.IO.StreamWriter writer;
        
        public String DeHash(long key, long length, String knownLetters)
        {
            var test = new int[length];
            long testKey = key;
            
            //Open a new file to log the process
            try
            {
                writer = new System.IO.StreamWriter("output.txt");
            }
            catch(Exception e)
            {
                Console.Write(e.StackTrace);
            }

            //to speed up the process add letters to test array
            if(knownLetters.Length == length){
                for (int i = 0; i < length; i++)
                {
                    test[i] = letters.IndexOf(knownLetters[i]);
                }               
            }

            //keep testing!
            try
            {

                while (test.Sum(i => i) != test.Length * letters.Length)
                {
                    var testString = String.Join("", test.Select(i => letters[i].ToString()).ToArray());

                    Console.WriteLine(testString);

                    writer.Write(hash(testString).ToString()+" ");
                    writer.WriteLine(testString);

                    if (hash(testString) == testKey)
                    {
                        writer.Write("Answer: " +testString);
                        writer.Close();
                        return testString;
                    }

                    test[test.Length - 1]++;

                    for (int i = test.Length - 1; i >= 0; i--)
                    {
                        if (test[i] >= letters.Length)
                        {
                            test[i] = 0;
                            test[i - 1]++;
                        }
                        else
                            break;
                    }
                }
                writer.Close();
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public long hash(string s)
        {
            long h = 7;

            for (int i = 0; i < s.Length; i++)
            {
                h = h * 37 + letters.IndexOf(s[i]);
            }

            return h;
        }
    }
}
