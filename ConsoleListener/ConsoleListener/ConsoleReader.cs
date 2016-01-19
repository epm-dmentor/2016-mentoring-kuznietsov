using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleListener
{
    class ConsoleReader
    {
        private string _keyWord;

        public string KeyWord
        {
            get { return _keyWord; }
            set
            {
                if (value == "quit")
                {
                    OnQuitPressEventArgs args = new OnQuitPressEventArgs();
                    args.word = value;
                    if (OnQuitPressEvent != null) OnQuitPressEvent(this, args);
                }
                _keyWord = value;
            }
        }
        
        public delegate void WordReader(object obj, OnQuitPressEventArgs args);

        public event WordReader OnQuitPressEvent;

        public ConsoleReader()
        {
            KeyWord = null;
        }

        public string Read()
        {
            KeyWord = Console.ReadLine();
            while (KeyWord != "quit")
            {
                KeyWord = Console.ReadLine();
            }
            return KeyWord;
        }


    }
}
