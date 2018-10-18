using System;

namespace Nums
{
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
        


    }
}
