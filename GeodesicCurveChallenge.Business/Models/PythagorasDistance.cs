using System;

namespace GeodesicCurveChallenge.Business.Models
{
    public class PythagorasDistance : Distance
    {
        public override double Calculate(GeodesicCurve model)
        {
            double distanceLatitude = Radians(model.CityTwo.Latitude - model.CityOne.Latitude);
            double distanceLongitude = Radians(model.CityTwo.Longitude - model.CityOne.Longitude);
            double a = distanceLongitude * Math.Cos((Radians(model.CityOne.Latitude) + Radians(model.CityTwo.Latitude)) / 2);
            double distance = Math.Sqrt(a * a + distanceLongitude * distanceLongitude) * R;
            return distance;
        }
    }
}
