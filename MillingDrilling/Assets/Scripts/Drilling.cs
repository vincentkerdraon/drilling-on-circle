using System;
using System.Collections.Generic;

namespace Scripts
{

    //- assuming x,y plan
    //- assuming starting boring is in {0,d/2}. This is the top part of the circle.
    //- angleShift moves start boring to the right (now top part but on the right.)

    [System.Serializable]
    public class Drillings
    {

        [System.Serializable]
        public class Drilling
        {
            //X in mm
            public double X;
            //X in mm
            public double Y;
            //Angle in degree
            public double Angle;
        }

        public List<Drilling> ListDrillings { get; }

        public Drillings(double diameter, uint nbDrillings, double angleShift)
        {
            ListDrillings = new List<Drilling>((int)nbDrillings);
            double angle = (angleShift+90) % 360;
            for (uint i = 0; i < nbDrillings; i++)
            {
                double x = (double)diameter / 2 * Math.Cos(angle * Math.PI / 180);
                double y = (double)diameter / 2 * Math.Sin(angle * Math.PI / 180);
                Drilling b = new Drilling();
                b.Angle = angle;
                b.X = x;
                b.Y = y;
                ListDrillings.Add(b);

                angle -= (360 / (double)nbDrillings) % 360;
            }
        }
    }
} 
