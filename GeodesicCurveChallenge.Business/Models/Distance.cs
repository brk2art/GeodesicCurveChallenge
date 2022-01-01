using System;

namespace GeodesicCurveChallenge.Business.Models
{
    public abstract class Distance
    {
        public const double R = 6371; // km

        public double Radians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public abstract double Calculate(GeodesicCurve model);
    }
}
