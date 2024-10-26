using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles_V1._0
{
    internal class RandomCirclePoint //a helper class to generates a random point in a circle about the origin
        //this will be used as the x and y values in the vector of the particle
    {
         public static (float X, float Y) GenerateRandomPoint(double radius, Random random)
    {
        // Generate random angle (theta) between 0 and 2π
        double theta = random.NextDouble() * 2 * Math.PI;

        // Calculate corresponding radius (r) using inverse CDF of uniform distribution
        double r = Math.Sqrt(random.NextDouble());

        // Convert polar coordinates (r, theta) to Cartesian coordinates (x, y)
        double x = radius * r * Math.Cos(theta);
        double y = radius * r * Math.Sin(theta);

        return ((float)x,(float)y);
    }
    }
}
