using GeodesicCurveChallenge.Business.Models;

namespace GeodesicCurveChallenge.Business.Managers.Interfaces
{
    public interface IDistanceManager
    {
        double Calculate(GeodesicCurve model);
    }
}
