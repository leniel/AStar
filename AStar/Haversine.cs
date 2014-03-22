using System;

namespace AStar
{
    /// <summary>
    /// The distance type to return the results in.
    /// </summary>
    public enum DistanceType { ml, km };

    class Haversine
    {
        /// <summary>
        /// Returns the distance in miles or kilometers of any two
        /// latitude / longitude points.
        /// </summary>
        /// <param name=”node1″></param>
        /// <param name=”node2″></param>
        /// <param name=”type”></param>
        /// <returns></returns>
        public static double Distance(Node node1, Node node2, DistanceType type)
        {
            double R = (type == DistanceType.ml) ? 3960 : 6371;
            
            double dLat = ToRadian(node2.Latitude - node1.Latitude);
            
            double dLon = ToRadian(node2.Longitude - node1.Longitude);
            
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRadian(node1.Latitude)) * Math.Cos(ToRadian(node2.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            
            double d = R * c;
            
            return d;
        }

        /// <summary>
        /// Convert to Radians.
        /// </summary>
        /// <param name=”val”></param>
        /// <returns></returns>
        private static double ToRadian(double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}
