using System.Collections.Generic;
using NUnit.Framework;
using Scripts;
using System.Numerics;

namespace Tests
{
    public class DrillingTest
    {
        [Test]
        public void TestWhen1()
        {
            List<Drilling> drillings = new Drillings(1, 10, 0).AllDrillingsRounded;
            Assert.AreEqual(1, drillings.Count);
            Drilling d = drillings[0];
            Assert. AreEqual (0,d.Angle);
            Assert.AreEqual(0,d.Coord.X);
            Assert.AreEqual(5,d.Coord.Y);
        }

        [Test]
        public void TestWhen2Tilted()
        {
            List<Drilling> drillings = new Drillings(2, 10, 90).AllDrillingsRounded;
            Assert.AreEqual(2,drillings.Count);
            Drilling d = drillings[0];
            Assert.AreEqual(90,d.Angle);
            Assert.AreEqual(5,d.Coord.X );
            Assert.AreEqual(0,d.Coord.Y);

            d = drillings[1];
            Assert.AreEqual(270,d.Angle);
            Assert.AreEqual(-5,d.Coord.X);
            Assert.AreEqual(0,d.Coord.Y);
        }

        [Test]
        public void TestWhen4FromCoord()
        {
            List<Drilling> drillings = Drillings.DrillingsFromExistingHole(4,new Vector2(-5,0)).AllDrillingsRounded;
            Assert.AreEqual(4, drillings.Count);
            Drilling d = drillings[0];
            Assert.AreEqual(0, d.Angle);
            Assert.AreEqual(0, d.Coord.X);
            Assert.AreEqual(5, d.Coord.Y);

            d = drillings[1];
            Assert.AreEqual(90, d.Angle);
            Assert.AreEqual(5, d.Coord.X);
            Assert.AreEqual(0, d.Coord.Y);
        }
    }
}
