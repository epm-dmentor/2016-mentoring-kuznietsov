using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleListener
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleReader r1 = new ConsoleReader();
            r1.OnQuitPressEvent += OnQuitMethod;
            r1.Read();
            
        }

        private static void OnQuitMethod(object sender, OnQuitPressEventArgs args)
        {
            Console.WriteLine($"This class {sender.GetType().Name} just recived {args.word} keyword. Raising an Event");
            Console.ReadLine();
        }

        
    }

   
}
