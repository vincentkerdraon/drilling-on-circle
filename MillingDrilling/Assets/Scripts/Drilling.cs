using System;
using System.Collections.Generic;
using System.Numerics;

namespace Scripts
{
    //- assuming x,y trigonometric plan 
    //- assuming starting hole is in {0;d/2}. This is the top part of the circle.
    //- angleShift moves start hole to the right (now top part but on the right side.)

    [System.Serializable]
    public class Drilling
    {
        //X,Y in mm
        public Vector2 Coord;

        //Angle in degree: top position= {0;d/2} to circle center {0;0} to hole.
        //Not following trigonometric standard
        public double Angle;

        public override string ToString()
        {
            return "{Coord="+Coord.ToString()+", Angle="+Angle+"}";
        }
    }

    [System.Serializable]
    public class Drillings
    {
        const int digits = 3;

        public uint NbHoles;
                //in mm
        public double Diameter;
                //in degres
        public double AngleShift;

        public List<Drilling> AllDrillingsExact;
        public List<Drilling> AllDrillingsRounded;


        public static Drillings DrillingsFromExistingHole( uint nbHoles, Vector2 existingHole)
        {
            double diameter = 2*Math.Sqrt(existingHole.X * existingHole.X + existingHole.Y * existingHole.Y);
            double angleShift = Math.Atan(existingHole.X / existingHole.Y) * 180 / Math.PI;
            angleShift = angleShift % (360 / nbHoles);
            return new Drillings(nbHoles, diameter, angleShift);
        }

        public Drillings(uint nbHoles, double diameter, double angleShift)
        {
            this.NbHoles = nbHoles;
            this.Diameter = diameter;
            this.AngleShift = angleShift;

            AllDrillingsExact = new List<Drilling>((int)nbHoles);
            AllDrillingsRounded = new List<Drilling>((int)nbHoles);
            double angle = (90-angleShift ) % 360;
            for (uint i = 0; i < nbHoles; i++)
            {
                float x = (float)( diameter / 2 * Math.Cos(angle * Math.PI / 180));
                float y = (float)(diameter / 2 * Math.Sin(angle * Math.PI / 180));
                Drilling d = new Drilling();
                //not usual trigonometric angle
                d.Angle = (90 - angle) % 360;
                d.Coord = new Vector2(x,y);
                AllDrillingsExact.Add(d);

                Drilling dRounded = new Drilling();
                dRounded.Angle = Math.Round(d.Angle, digits);
                dRounded.Coord.X = (float)Math.Round(d.Coord.X, digits);
                dRounded.Coord.Y = (float)Math.Round(d.Coord.Y, digits);
                AllDrillingsRounded.Add(dRounded);

                angle -= (360 / (double)nbHoles) % 360;
            }
        }

        public override string ToString()
        {
            string debug = "{Diameter=" + Diameter + ", NbHoles=" + NbHoles + ", AngleShift=" + AngleShift + ", Holes=[";
            for (int i = 0; i < AllDrillingsExact.Count; i++)
            {
                debug += AllDrillingsExact[i].ToString()+", ";
            }
            debug += "]";
            return debug;
        }
    }
}
