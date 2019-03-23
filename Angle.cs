﻿

namespace Nums {

    /// <summary>
    /// Represents an angle
    /// </summary>
    public struct Angle {

        /// <summary>
        /// Radians to degrees conversion constant
        /// </summary>
        public const double Rad2Deg = 180d / System.Math.PI;
        /// <summary>
        /// Degrees to radians conversion constant
        /// </summary>
        public const double Deg2Rad = System.Math.PI / 180d;


        private double _radValue;

        /// <summary>
        /// This angle in radians
        /// </summary>
        public double Radians {
            get => _radValue;
            set => _radValue = NormalizeRadianAngle(value);
        }

        /// <summary>
        /// This angle in degrees
        /// </summary>
        public double Degrees {
            get => Rad2Deg * Radians;
            set => Radians = Deg2Rad * value;
        }

        /// <summary>
        /// Creates an instance from a radian value 
        /// </summary>
        /// <param name="rad">The radian value</param>
        public Angle(double rad) => _radValue = NormalizeRadianAngle(rad);
        /// <summary>
        /// Creates an Angle from a radian value
        /// </summary>
        /// <param name="rad"></param>
        /// <returns></returns>
        public static Angle FromRad(double rad) => new Angle { Radians = rad };
        /// <summary>
        /// Creates an Angle from a degree value
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        public static Angle FromDeg(double deg) => new Angle { Degrees = deg };

        /// <summary>
        /// Parses the string to an angle
        /// </summary>
        /// <param name="str">The string to be parsed</param>
        /// <returns></returns>
        public static Angle Parse(string str) {
            var trim = str.Trim();
            if(double.TryParse(trim.Substring(0, trim.Length - 3), out double d)) {
                if (trim.EndsWith("rad")) {
                    return FromRad(d);
                } else if (trim.EndsWith("deg")) {
                    return FromDeg(d);
                } else {
                    _error();
                }
            } else {
                _error();
            }
            void _error() {
                throw new System.FormatException("could not parse " + str + " as an angle");
            }
            return 0;
        }


        /// <summary>
        /// Normalizes the radian value in the range 0-tau
        /// </summary>
        /// <param name="rad"></param>
        /// <returns></returns>
        public static double NormalizeRadianAngle(double rad) {
            double t = rad / Consts.Tau;
            return (t - System.Math.Floor(t)) * Consts.Tau;
        }


        /// <summary>
        /// Implicit cast from double to new Angle. using degrees
        /// </summary>
        /// <param name="d"></param>
        public static implicit operator Angle(double d) => FromDeg(d);

        /// <summary>
        /// Implicit cast from Angle to double in radians
        /// </summary>
        /// <param name="a"></param>
        public static implicit operator double(Angle a) => a.Radians;


        /// <summary>
        /// Returns this angle in degrees as a string 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Degrees + "°";

    }
}