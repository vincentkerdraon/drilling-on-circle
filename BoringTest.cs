using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Holing;
using NUnit.Framework;

namespace HolingTests
{

    [TestClass]
    class BoringsTests
    {
        [TestMethod]
        public void TestWhen1()
        {
            List<Borings.Boring> borings = new Borings(10, 1, 0).borings;
            Assert.Len(borings, 1);
            Borings.Boring boring = borings[0];
            Assert.AreEqual(boring.Angle, 0);
            Assert.AreEqual(boring.X, 0);
            Assert.AreEqual(boring.Y, 10);
        }

        [TestMethod]
        public void TestWhen2Tilted()
        {
            List<Borings.Boring> borings = new Borings(10, 2, 90).borings;
            Assert.Len(borings, 2);
            Borings.Boring boring = borings[0];
            Assert.AreEqual(boring.Angle, 90);
            Assert.AreEqual(boring.X, 10);
            Assert.AreEqual(boring.Y, 0);

            boring = borings[1];
            Assert.AreEqual(boring.Angle, 270);
            Assert.AreEqual(boring.X, -10);
            Assert.AreEqual(boring.Y, 0);
        }
    }
}
