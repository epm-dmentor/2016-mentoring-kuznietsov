using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable myTable = new HashTable(100);
            string test = "УПЧК";
            myTable.Add(test, "Упячка! Пыщь, Пыщь трололо! Лучи поноса");
            Console.WriteLine(myTable.Contains("УПЧК"));
            Console.ReadLine();

            myTable.Add(test, "Жырчик, Чакэ! Пыщь пыщь ололол!!211!!");
            Console.WriteLine(myTable[test]);
            Console.ReadLine();

            myTable[test] = "Pyshch Pyshch ololol upchk!!111111!!111";
            Console.WriteLine(myTable[test]);
            Console.ReadLine();
        }
    }
}
