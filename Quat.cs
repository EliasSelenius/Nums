using System;

namespace Nums
{
    public struct Quat {
        public float x, y, z, w;

        public const int ByteSize = sizeof(float) * 4;

        public Quat(float X, float Y, float Z, float W) {
            x = X; y = Y; z = Z; w = W;
        }

        public Vec3 xyz { get { return new Vec3(x, y, z); } set { x = value.x; y = value.y; z = value.z; } }

        public static Quat FromEuler(float ex, float ey, float ez) {
            float cy = (float)Math.Cos(ez * .5f);
            float sy = (float)Math.Sin(ez * .5f);
            float cr = (float)Math.Cos(ex * .5f);
            float sr = (float)Math.Sin(ex * .5f);
            float cp = (float)Math.Cos(ey * .5f);
            float sp = (float)Math.Sin(ey * .5f);

            return new Quat(cy * sr * cp - sy * cr * sp,
                                cy * cr * sp + sy * sr * cp,
                                sy * cr * cp - cy * sr * sp,
                                cy * cr * cp + sy * sr * sp);
        }
        public static Quat FromEuler(Vec3 eul) {
            return FromEuler(eul.x, eul.y, eul.z);
        }
        public static Vec3 ToEuler(float x, float y, float z, float w) { throw new NotImplementedException(); }
        public static Vec3 ToEuler(Quat quat) { throw new NotImplementedException(); }
        public Vec3 Euler => ToEuler(this);

        public static Quat FromAxisAngle(float x, float y, float z, float angle) { throw new NotImplementedException(); }
        public static Quat FromAxisAngle(Vec3 axis, float angle) { throw new NotImplementedException(); }
        public static Vec4 ToAxisAngle(float x, float y, float z, float w) {
            return ToAxisAngle(new Quat(x, y, z, w));
        }
        public static Vec4 ToAxisAngle(Quat quat) {
            if (Math.Abs(quat.w) > 1f) {
                quat.Normalize();
            }

            Vec4 res = new Vec4 {
                w = 2f * (float)Math.Acos(quat.w)
            };
            float den = (float)Math.Sqrt(1f - quat.w * quat.w);
            if (den > 0.0001f) {
                res.xyz = quat.xyz / den;
            } else {
                res.xyz = Vec3.UnitX;
            }

            return res;
        }
        public Vec4 AxisAngle => ToAxisAngle(this);


        public void Set(float X, float Y, float Z, float W) { x = X; y = Y; z = Z; w = W; }


        public static readonly Quat Identity = new Quat(0, 0, 0, 1);


        public static Quat operator *(Quat a, Quat q) {
            float nw = a.w * q.w - (a.x * q.x + a.y * q.y + a.y * q.z);

            float nx = a.w * q.x + q.w * a.x + a.y * q.z - a.z * q.y;
            float ny = a.w * q.y + q.w * a.y + a.z * q.x - a.x * q.z;
            float nz = a.w * q.z + q.w * a.z + a.x * q.y - a.y * q.x;

            return new Quat(nx, ny, nz, nw);
        }


        public void Normalize() {
            float norme = (float)Math.Sqrt(x * x + y * y + z * z + w * w);
            if(norme == 0.0f) {
                x = y = z = 0f;
                w = 1f;
            } else {
                float recip = 1f / norme;
                x *= recip;
                y *= recip;
                z *= recip;
                w *= recip;
            }
        }
    }
}
