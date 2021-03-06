﻿using System;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using MyHashTable;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MyHashTableTests
{
    [TestFixture]
    public class HashTableTests
    {
        [Test()]
        public void ContainsTest()
        {
            var testTable = new HashTable(5);
            testTable.Add(18081985, "Thats my birthday");
            Assert.IsTrue(testTable.Contains(18081985));
        }

        [Test(), Description("Test of Add method")]
        public void AddTest()
        {
            //Test to check if values are added correctly
            HashTable testTable = new HashTable(5);
            testTable.Add(1, "ONE");
            testTable.Add(2, "TWO");
            testTable.Add(3, "THREE");

            //Check if getter works with added items
            Assert.AreEqual(testTable[1], "ONE");
            Assert.AreEqual(testTable[2], "TWO");
            Assert.AreEqual(testTable[3], "THREE");

            //Test for collision handling
            var testTable1 = new HashTable(1);
            for (int i = 1; i < 6; i++)
            {
                testTable1.Add(i, "TEST");
            }
            Assert.AreEqual(testTable1[1], "TEST");
            Assert.AreEqual(testTable1[2], "TEST");
            Assert.AreEqual(testTable1[3], "TEST");
            Assert.AreEqual(testTable1[4], "TEST");
            Assert.AreEqual(testTable1[5], "TEST");
        }

        [Test(), Description("Test to check if exceptions are thrown")]
        public void ExceptionTest()
        {
            HashTable testTable = new HashTable(5);
            testTable.Add(3, "Thats a THREE");
            Assert.Throws<Exception>(() => testTable.Add(3, 5));
            Assert.Throws<Exception>(() =>
            {
                var temp = testTable[5];
            });

        }

        [Test]
        public void GetSetTest()
        {
            var testTable = new HashTable(5);
            //Get/Set test
            testTable[5] = "FIVE";
            testTable.Add(1808, "Birthday date");
            Assert.AreEqual(testTable[5], "FIVE");
            Assert.AreEqual(testTable[1808], "Birthday date");
            //Delete if value = null test
            testTable[5] = null;
            testTable[1808] = null;
            Assert.IsFalse(testTable.Contains(5));
            Assert.IsFalse(testTable.Contains(1808));
            

        }

        [Test]
        public void TryGetTest()
        {
            var testTable = new HashTable(5);
            testTable[1] = "TESTVALUE";
            object keyValue;
            testTable.TryGet(1, out keyValue);
            Assert.AreEqual(keyValue.ToString(), "TESTVALUE");

        }
    }
}