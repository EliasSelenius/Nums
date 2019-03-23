

using Nums.Vectors;

namespace Nums.Geometry.Generic {

    /// <summary>
    /// This is a rectangle
    /// </summary>
    public struct Rect : IShape {

        /// <summary>
        /// This rectangles width
        /// </summary>
        public float Width;
        /// <summary>
        /// This rectangles height
        /// </summary>
        public float Height;

        /// <summary>
        /// Creates a rectangle
        /// </summary>
        /// <param name="size">The size of the rectangle</param>
        public Rect(float size) => Width = Height = size;
        /// <summary>
        /// Creates a rectangle
        /// </summary>
        /// <param name="w">The rectangles width</param>
        /// <param name="h">The rectangles height</param>
        public Rect(float w, float h) { Width = w; Height = h; }

        /// <summary>
        /// This is 0...
        /// </summary>
        public float Volume { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        /// <summary>
        /// This rectangles surafec area
        /// </summary>
        public float Surface {
            get => Width * Height;
            set => throw new System.NotImplementedException();
        }

        public float FurthestLengthFromPivot() {
            throw new System.NotImplementedException();
        }

        public Vec3 RandomPoint() {
            throw new System.NotImplementedException();
        }

        public Vec3 RandomSurfacePoint() {
            throw new System.NotImplementedException();
        }

        public void Scale(float scaler) {
            throw new System.NotImplementedException();
        }
    }

}