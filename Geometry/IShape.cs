using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nums.Geometry {
    /// <summary>
    /// This interface contains all properties that any shape should have
    /// </summary>
    public interface IShape {
        /// <summary>
        /// This shapes volume
        /// </summary>
        float Volume { get; set; }
        /// <summary>
        /// This shapes surface area
        /// </summary>
        float Surface { get; set; }
        /// <summary>
        /// The lenght from its pivot to the point furthest away from its pivot
        /// </summary>
        /// <returns>A float representing the length</returns>
        float FurthestLengthFromPivot();
        /// <summary>
        /// Gets a random point inside the shape
        /// </summary>
        /// <returns>A Vec3 representing the position of the random point</returns>
        Vectors.Vec3 RandomPoint();
        /// <summary>
        /// Gets a random point on the surface of the shape
        /// </summary>
        /// <returns></returns>
        Vectors.Vec3 RandomSurfacePoint();
        /// <summary>
        /// Scales the size of this shape
        /// </summary>
        /// <param name="scaler">The scaling factor</param>
        void Scale(float scaler);


    }
}
