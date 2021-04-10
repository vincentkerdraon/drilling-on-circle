using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Scripts;

namespace Tests
{
    public class DrillingTest
    {
        [Test]
        public void TestWhen1()
        {
            List<Drillings.Drilling> borings = new Drillings(10, 1, 0).ListDrillings;
            Assert.AreEqual(borings.Count, 1);
            Drillings.Drilling boring = borings[0];
            Assert.AreEqual(boring.Angle, 0);
            Assert.AreEqual(boring.X, 0);
            Assert.AreEqual(boring.Y, 10);
        }

        [Test]
        public void TestWhen2Tilted()
        {
            List<Drillings.Drilling> borings = new Drillings(10, 2, 90).ListDrillings;
            Assert.AreEqual(borings.Count, 2);
            Drillings.Drilling boring = borings[0];
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
