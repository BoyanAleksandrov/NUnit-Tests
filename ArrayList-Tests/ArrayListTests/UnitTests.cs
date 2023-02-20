using System;
using NUnit.Framework;
using UnitTesting;

namespace ArrayListTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Constructor()
        {
            ArrayList TestList = new ArrayList();
            
            Assert.AreEqual(0, TestList.Count);
        }

        [Test]
        public void Test_AddToArrayList()
        {
            ArrayList TestList = new ArrayList();
            TestList.Add(1);
            TestList.Add(2);
            TestList.Add(3);
            
            Assert.AreEqual(3, TestList.Count);
        }

        [Test]
        public void Test_FreePositions()
        {
            ArrayList TestList = new ArrayList();
            TestList.Add(1);
            TestList.Add(2);
            TestList.Add(3);
            
            Assert.AreEqual(1, TestList.CountFreePositions());
        }

        [Test]
        public void Test_CutItemsFromArrayList()
        {
            ArrayList TestList = new ArrayList();
            TestList.Add(1);
            TestList.Add(2);
            TestList.Add(3);
            
            TestList.Cut(2);
            
            Assert.AreEqual(1, TestList.Count);
        }

        [Test]
        public void Test_WhichIndexIsChanged()
        {
            ArrayList TestList = new ArrayList();
          
            TestList.Add(1);
            TestList.Add(2);
            TestList.Add(3);

            Assert.AreEqual(2, TestList.Change(3, 85));
        }



    }
}