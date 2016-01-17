using System;

namespace MyHashTable
{
    public class HashTable : IHashTable
    {
        //Variables
        private int Hash { get; set; }
        private int TableSize { get; }    
        private ListElement[] TableArray { get; }

        //Constructos
        public HashTable(int size)
        {
            TableSize = size;
            TableArray = new ListElement[TableSize];
            for (var i = 0; i < TableSize; i++)
            {
                TableArray[i] = new ListElement();
            }
        }

        //Bucket class
        private class ListElement
        {
            internal object Key { get; set;  }
            internal object Value { get; set; }
            internal ListElement NextElement { get; set; }

            public ListElement()
            {
                Key = "EMPTY";
                Value = "EMPTY";
                NextElement = null;
            }
        }

        //Internal Methods
        private int GetHash (object key)
        {
            var hash = key.GetHashCode();
            Hash = Math.Abs(hash % TableSize);
            return Hash;
        }

        //Interface
        //IHashTable implementation

        public bool Contains(object key)
        {
            var index = GetHash(key);
            if (!Equals(TableArray[index].Key.ToString(), "EMPTY"))
            {
                var pointer = TableArray[index];
                while (pointer != null)
                {
                    if (Equals(pointer.Key, key))
                    {
                        return true;
                    }
                    pointer = pointer.NextElement;
                }
                return false;
            }
            return false;
        }

        public void Add(object key, object value)
        {
            var index = GetHash(key);
            if (Contains(key) && value != null)
            {
                throw new Exception("Such key already exists in the table!");
            }

            if (Equals(TableArray[index].Key.ToString(), "EMPTY"))
            {
                TableArray[index].Key = key;
                TableArray[index].Value = value;
            }
            else
            {
                var pointer = TableArray[index];
                var newElement = new ListElement { Key = key, Value = value, NextElement = null };
                while (pointer.NextElement != null)
                {
                    pointer = pointer.NextElement;
                }

                pointer.NextElement = newElement;
            }
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
                if (!Contains(key)) throw new Exception("Key not found");
                var index = GetHash(key);
                object keyValue;
                if (!Equals(TableArray[index].ToString(), key.ToString()))
                {
                    var pointer = TableArray[index];
                    while (pointer != null)
                    {
                        if (Equals(pointer.Key, key))
                        {
                            keyValue = pointer.Value;
                            return keyValue;
                        }
                        pointer = pointer.NextElement;
                    }
                }
                keyValue = TableArray[index].Value;
                return keyValue;
            }

            set
            {
                if (value == null && Contains(key))
                {
                    var index = GetHash(key);
                    ListElement pointer = TableArray[index];
                    while (!Equals(pointer.Key, key))
                    {
                        pointer = pointer.NextElement;
                    }
                    pointer.Key = "EMPTY";
                    pointer.Value = "EMPTY";
                }
                else
                    Add(key, value);

            }
        }


    }
}

//operator overloading
//equals + gethascode
//