using System;
using System.Collections.Generic;
using System.Text;

namespace Holing
{

    //- assuming x,y plan
    //- assuming starting boring is in {0,d/2}. This is the top part of the circle.
    //- angleShift moves start boring to the right (now top part but on the right.)


    class Borings
    {
        public class Boring
        {
            //X in mm
            public double X;
            //X in mm
            public double Y;
            //Angle in degree
            public double Angle;
        }

        public List<Boring> borings { get; }

        public Borings(double diameter, uint nbBorings, double angleShift)
        {
            borings = new List<Boring>((int)nbBorings);
            double angle = angleShift % 360;
            for (uint i = 0; i < nbBorings; i++)
            {
                double x = (double)diameter / 2 * Math.Cos(angle * Math.PI / 180);
                double y = (double)diameter / 2 * Math.Sin(angle * Math.PI / 180);
                Boring b = new Boring();
                b.Angle = angle;
                b.X = x;
                b.Y = y;
                borings.Add(b);

                angle -= (360 / (double)nbBorings) % 360;
            }
        }
    }
} 
