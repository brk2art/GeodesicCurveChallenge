using System;

namespace GeodesicCurveChallenge.Business.Models
{
    public class CosinesDistance : Distance
    {
        public override double Calculate(GeodesicCurve model)
        {
            double sinLatitude1 = Math.Sin(Radians(model.CityOne.Latitude));
            double sinLatitude2 = Math.Sin(Radians(model.CityTwo.Latitude));
            double cosLatitude1 = Math.Cos(Radians(model.CityOne.Latitude));
            double cosLatitude2 = Math.Cos(Radians(model.CityTwo.Latitude));
            double cosLongitude = Math.Cos(Radians(model.CityOne.Longitude) - Radians(model.CityTwo.Longitude));

            double cosDistance = sinLatitude1 * sinLatitude2 + cosLatitude1 * cosLatitude2 * cosLongitude;

            double distance = Math.Acos(cosDistance);

            return R * distance;
        }
    }
}
