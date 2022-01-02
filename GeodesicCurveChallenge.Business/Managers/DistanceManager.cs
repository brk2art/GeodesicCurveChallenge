using GeodesicCurveChallenge.Business.Managers.Interfaces;
using GeodesicCurveChallenge.Business.Models;

namespace GeodesicCurveChallenge.Business.Managers
{
    public class DistanceManager : IDistanceManager
    {
        DistanceFactory _factory;

        public DistanceManager(DistanceFactory factory)
        {
            _factory = factory;
        }

        public double Calculate(GeodesicCurve model)
        {
            if (model == null) return 0;
            if (model.CityOne == null) return 0;
            if (model.CityTwo == null) return 0;
            if (model.CityOne?.Latitude == null) return 0;
            if (model.CityOne?.Longitude == null) return 0;
            if (model.CityTwo?.Latitude == null) return 0;
            if (model.CityTwo?.Longitude == null) return 0;
            if (model.CityOne?.Latitude < -90 || model.CityOne.Latitude > 90) return 0;
            if (model.CityOne?.Longitude < -180 || model.CityOne.Longitude > 180) return 0;
            if (model.CityTwo?.Latitude < -90 || model.CityTwo.Latitude > 90) return 0;
            if (model.CityTwo?.Longitude < -180 || model.CityTwo.Longitude > 180) return 0;

            Distance distance = _factory.createDistance("Cosines");
            if(distance != null)
            {
                return distance.Calculate(model);
            }
            return 0;
        }
    }
}
