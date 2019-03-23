




namespace Nums.Geometry.Generic {

    /// <summary>
    /// Just like a cube, but better!
    /// </summary>
    public struct Cuboid : Nums.Geometry.IShape {

        /// <summary>
        /// This cuboids width
        /// </summary>
        public float Width;
        /// <summary>
        /// This cuboids height
        /// </summary>
        public float Height;
        /// <summary>
        /// This cuboids depth
        /// </summary>
        public float Depth;

        /// <summary>
        /// Creates a cuboid
        /// </summary>
        /// <param name="size">The cuboids size</param>
        public Cuboid(float size) => Width = Height = Depth = size;
        /// <summary>
        /// Creates a cuboid
        /// </summary>
        /// <param name="w">The cuboids width</param>
        /// <param name="h">The cuboids height</param>
        /// <param name="d">The cuboids depth</param>
        public Cuboid(float w, float h, float d) { Width = w; Height = h; Depth = d; }

        /// <summary>
        /// This Cuboids volume
        /// </summary>
        public float Volume {
            get => Width * Height * Depth;
            set {
                throw new System.NotImplementedException();
            }
        }
        /// <summary>
        /// This cuboids surface area
        /// </summary>
        public float Surface { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public float FurthestLengthFromPivot() {
            throw new System.NotImplementedException();
        }

        public Vectors.Vec3 RandomPoint() {
            throw new System.NotImplementedException();
        }

        public Vectors.Vec3 RandomSurfacePoint() {
            throw new System.NotImplementedException();
        }

        public void Scale(float scaler) {
            throw new System.NotImplementedException();
        }
    }

}
