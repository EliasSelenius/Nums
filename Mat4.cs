using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nums {
    public class Mat4 {

        public const int ByteSize = Vec4.ByteSize * 4;

        // [row, col]
        //private float m00, m10, m20, m30,
        //              m01, m11, m21, m31,
        //              m02, m12, m22, m32,
        //              m03, m13, m23, m33;


        public Vec4 Row0, Row1, Row2, Row3;

        public Vec4 Col0 => new Vec4(Row0.x, Row1.x, Row2.x, Row3.x);
        public Vec4 Col1 => new Vec4(Row0.y, Row1.y, Row2.y, Row3.y);
        public Vec4 Col2 => new Vec4(Row0.z, Row1.z, Row2.z, Row3.z);
        public Vec4 Col3 => new Vec4(Row0.w, Row1.w, Row2.w, Row3.w);


        public float Get(int row, int col) {
            throw new NotImplementedException();
        }

        public override string ToString() {
            return $"{Row0.ToString()} \n" +
                   $"{Row1.ToString()} \n" +
                   $"{Row2.ToString()} \n" +
                   $"{Row3.ToString()}";
        }


        public Mat4() {
            Row0 = Identity.Row0;
            Row1 = Identity.Row1;
            Row2 = Identity.Row2;
            Row3 = Identity.Row3;
        }

        public Mat4(Vec4 r0, Vec4 r1, Vec4 r2, Vec4 r3) {
            Row0 = r0;
            Row1 = r1;
            Row2 = r2;
            Row3 = r3;
        }
        public Mat4(float a, float b, float c, float d,
                    float e, float f, float g, float h,
                    float i, float j, float k, float l,
                    float m, float n, float o, float p) {
            Row0 = new Vec4(a, b, c, d);
            Row1 = new Vec4(e, f, g, h);
            Row2 = new Vec4(i, j, k, l);
            Row3 = new Vec4(m, n, o, p);
        }

        public static readonly Mat4 Identity = new Mat4(1, 0, 0, 0,
                                                        0, 1, 0, 0,
                                                        0, 0, 1, 0,
                                                        0, 0, 0, 1);

        public static Mat4 FromPositon(Vec3 pos) {
            Mat4 res = Identity;
            res.Row3 = new Vec4(pos.x, pos.y, pos.z, 1);
            return res;
        }
        public static Mat4 FromScale(Vec3 scale) {
            return new Mat4(scale.x, 0, 0, 0,
                            0, scale.y, 0, 0,
                            0, 0, scale.z, 0,
                            0, 0, 0, 1);
        }
        public static Mat4 FromQuaternion(Quat quat) {
            Vec4 axisAngle = Quat.ToAxisAngle(quat);
            return FromAxisAngle(axisAngle.xyz, axisAngle.w);
        }
        public static Mat4 FromAxisAngle(Vec3 axis, float angle) {
            // normalize and create a local copy of the vector.
            axis.Normalize();
            float axisX = axis.x, axisY = axis.y, axisZ = axis.z;

            // calculate angles
            float cos = (float)Math.Cos(-angle);
            float sin = (float)Math.Sin(-angle);
            float t = 1.0f - cos;

            // do the conversion math once
            float tXX = t * axisX * axisX,
                tXY = t * axisX * axisY,
                tXZ = t * axisX * axisZ,
                tYY = t * axisY * axisY,
                tYZ = t * axisY * axisZ,
                tZZ = t * axisZ * axisZ;

            float sinX = sin * axisX,
                sinY = sin * axisY,
                sinZ = sin * axisZ;

            Mat4 res = new Mat4();

            res.Row0.x = tXX + cos;
            res.Row0.y = tXY - sinZ;
            res.Row0.z = tXZ + sinY;
            res.Row0.w = 0;
            res.Row1.x = tXY + sinZ;
            res.Row1.y = tYY + cos;
            res.Row1.z = tYZ - sinX;
            res.Row1.w = 0;
            res.Row2.x = tXZ - sinY;
            res.Row2.y = tYZ + sinX;
            res.Row2.z = tZZ + cos;
            res.Row2.w = 0;
            res.Row3 = Vec4.UnitW;

            return res;
        }
        public static Mat4 FromEuler(Vec3 euler) => FromQuaternion(Quat.FromEuler(euler));

        public static Mat4 operator *(Mat4 m0, Mat4 m1) {

            throw new NotImplementedException();

            Mat4 m = new Mat4();

            return m;
        }
        public static Vec3 operator *(Mat4 m, Vec3 v) {

            Vec3 res;

            throw new NotImplementedException();
        }



        public float[] Array => new float[] { Row0.x, Row0.y, Row0.z, Row0.w,
                                              Row1.x, Row1.y, Row1.z, Row1.w,
                                              Row2.x, Row2.y, Row2.z, Row2.w,
                                              Row3.x, Row3.y, Row3.z, Row3.w };

    }
}
