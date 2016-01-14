using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHashTable
{
    public class HashTable : IHashTable
    {
        //Variables
        private int _hash { get; set; }
        private int _tableSize { get; set; }    
        private LinkedList<_listElement>[] _tableArray { get; set; }    


        //Constructos
        public HashTable(int size)
        {
            _tableSize = size;
            _tableArray = new LinkedList<_listElement>[_tableSize];
            for (int i = 0; i < _tableSize; i++)
            {
                _tableArray[i] = new LinkedList<_listElement>();
            }
        }

        //List node structure
        private struct _listElement
        {
            internal object Key { get; set; }
            internal object Value { get; set; }  

            //Struct CTOR
            public _listElement(object sKey, object sValue)
            {
                Key = sKey;
                Value = sValue;
            }
        }

        //Internal Methods
        private int GetHash (object key)
        {
            int hash = key.GetHashCode();
            _hash = Math.Abs(hash % _tableSize);
            return _hash;
        }


        //Interface
        //IHashTable implementation

        public bool Contains(object key)
        {
            return this[key] != null; //Returns boolean result of comparison

            //int listIndex = GetHash(key);
            //if (_tableArray[listIndex].Count > 0)
            //{
            //    LinkedList<_listElement> listPointer = _tableArray[listIndex];
            //    foreach (_listElement node in listPointer)
            //    {
            //        if (node.Key == key)
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;
        }

        public void Add(object key, object value)
        {
            _listElement newNode = new _listElement (key, value);  //Create node for insertion
            int listIndex = GetHash(key);   //Find hash

                if (Contains(key))
                {
                    LinkedListNode<_listElement> current = _tableArray[listIndex].First;
                    while (current != null)
                    {
                        if (current.Value.Key == newNode.Key)
                        {
                            if (newNode.Value == null)
                            {
                                _tableArray[listIndex].Remove(current);
                            }
                            else
                            current.Value = newNode;
                            return;
                        }
                        current = current.Next;
                    }
                }   
                else
                    _tableArray[listIndex].AddLast(newNode);
        }

        public bool TryGet(object key, out object value)
        {
            value = this[key];
            return Contains(key);
        }

        public object this[object key]
        {
            get
            {
                object keyValue = null;
                int listIndex = GetHash(key);
                if (_tableArray[listIndex].Count >0)
                {
                    LinkedListNode<_listElement> current = _tableArray[listIndex].First;
                    while (current != null)
                    {
                        if (current.Value.Key == key)
                        {
                            keyValue = current.Value.Value;
                            return keyValue;
                        }
                        current = current.Next;
                    }
                }
                return keyValue;
            }

            set
            {
                Add(key, value);
            }
        }


    }
}
