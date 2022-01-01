namespace GeodesicCurveChallenge.Business.Models
{
    public class DistanceFactory
    {
        public Distance createDistance(string type)
        {
            Distance distance = null;
            if (type.Equals("Cosines"))
            {
                distance = new CosinesDistance();
            }
            else if (type.Equals("Haversine"))
            {
                distance = new HaversineDistance();
            }
            else if (type.Equals("Pythagoras"))
            {
                distance = new PythagorasDistance();
            }
            return distance;
        }
    }
}
