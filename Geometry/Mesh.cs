
using System.Collections.Generic;
using Nums.Vectors;

namespace Nums.Geometry {


    public class Mesh : IShape {
        public List<Vec3> Vertices = new List<Vec3>();
        public List<int> Indices = new List<int>();


        #region IShape impl
        public float Volume { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float Surface { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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
        #endregion
    } 
}