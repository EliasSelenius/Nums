using System;

using Nums.Vectors;

namespace Nums
{/*
    public class Transform {

        // Fields:
        public Vec3 Position = Vec3.Zero;
        public Vec3 Scale = Vec3.One;
        public Quat Rotation = Quat.Identity;




        // Props:
        public Mat4 Matrix => new Mat4(Scale.x, 0, 0, 0,
                                       0, Scale.y, 0, 0,
                                       0, 0, Scale.z, 0,
                                       Position.x, Position.y, Position.z, 1) * Mat4.FromQuaternion(Rotation); 

        // Transformations:
        // translations
        public void Translate(Vec3 v) => Position += v;
        public void Translate(float X, float Y, float Z) => Position += new Vec3(X, Y, Z);
        // Rotations
        public void Rotate(float x, float y, float z) => Rotation *= Quat.FromEuler(x, y, z);
        public void Rotate(Vec3 Euler) => Rotate(Quat.FromEuler(Euler));
        public void Rotate(Quat quat) => Rotation *= quat;
        


    }*/


    /// <summary>
    /// Wrapps a Mat4 and treats it as a transformation matrix
    /// </summary>
    public class Transform {

        /// <summary>
        /// This Transform's transformation matrix 
        /// </summary>
        public Mat4 Matrix = Mat4.Identity;


        #region Props


        /// <summary>
        /// Gets or sets the transformation matrix position
        /// </summary>
        public Vec3 Position {
            get => Matrix.Row3.xyz;
            set => Matrix.Row3.xyz = value;
            //set {
            //    var col = Matrix.Col3;
            //    col.xyz = value;
            //    Matrix.Col3 = col;
            //}
        }

        public Vec3 Scale {
            get => new Vec3(Matrix[0, 0], Matrix[1, 1], Matrix[2, 2]);
            set {
                Matrix[0, 0] = value.x; Matrix[1, 1] = value.y; Matrix[2, 2] = value.z;
            }
        }

        #endregion


        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Transform() {

        }

        /// <summary>
        /// Instantiates a Transform with given position
        /// </summary>
        /// <param name="pos">The transform's position</param>
        public Transform(Vec3 pos) {

        }
        #endregion


        public Vec3 TransformPoint(Vec3 a) {
            // todo: return a * Matrix
            throw new NotImplementedException();
        }

    }
}
