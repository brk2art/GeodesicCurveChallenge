using System;

namespace GeodesicCurveChallenge.Business.Models
{
    public class HaversineDistance : Distance
    {
        public override double Calculate(GeodesicCurve model)
        {
            double differenceLatitude = Radians(model.CityTwo.Latitude - model.CityOne.Latitude);
            double differenceLongitude = Radians(model.CityTwo.Longitude - model.CityOne.Longitude);
            double a = Math.Sin(differenceLatitude / 2) * Math.Sin(differenceLatitude / 2) + Math.Cos(Radians(model.CityOne.Latitude)) * Math.Cos(Radians(model.CityTwo.Latitude)) * Math.Sin(differenceLongitude / 2) * Math.Sin(differenceLongitude / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }
    }
}
