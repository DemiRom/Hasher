using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            String input;
            String letters;

            long key;
            long length;

            Console.WriteLine("Please Select: A - DeHash, B - Hash");
            input = Console.ReadLine();

            if(input.Equals("A")){
                DeHasher dehash = new DeHasher();

                Console.WriteLine("Please Enter the Hash Key");
                if(long.TryParse(Console.ReadLine(), out key)){
                    Console.WriteLine("Please Enter the String Length");
                    if(long.TryParse(Console.ReadLine(), out length)){
                        Console.WriteLine("If you know some of the letters please input them here - any letters that you don't know just put an 'a' in its place! else just dont enter anything");
                        letters = Console.ReadLine();
                        Console.WriteLine("DeHashing...");
                        Console.WriteLine("Answer: "+dehash.DeHash(key, length, letters));
                        Console.WriteLine("Press Any Key...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry, Exiting, press any key");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Entry, Exiting, press any key");
                    Console.ReadKey();
                }
            }
            else
            {
                Hasher hash = new Hasher();

                Console.WriteLine("Please Enter the code to be hashed");

                input = Console.ReadLine();

                long keyOut = hash.hasher(input);

                Console.WriteLine("Hashing...");

                Console.WriteLine(keyOut.ToString());

                Console.Write("Press Any Key...");
                Console.ReadKey();
            }

            
        }
    }
}
